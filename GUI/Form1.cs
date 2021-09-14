using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const string prefsPath = @"prefs.txt";
        const string backupsDir = @"backups";

        string gameDir = "";
        string patchDir = "";

        Prefs prefs = new Prefs();

        readonly string[] gamePaths = // where the vpk folder is likely to be, used for autofilling
        {
            Path.Combine("Origin Games|Origin", "Titanfall2", "vpk"),
            Path.Combine("Steam|SteamLibrary|Steam Library", "steamapps", "common", "Titanfall2", "vpk")
        };

        private void btnSelectGame_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            fd.Description = "Select Your Game Folder";

            if (fd.ShowDialog() != DialogResult.OK) return;

            gameDir = fd.SelectedPath;

            foreach (string subdirString in gamePaths)
            {
                string foundDir = FindDir(gameDir, Path.Combine("..", "Titanfall2.exe"), subdirString);  // attempt to find the vpk folder, verify with tf2.exe one folder up
                if (foundDir != string.Empty)
                {
                    gameDir = foundDir;
                    break; 
                }
            }

            txtTo.Text = gameDir;  // update textbox

            if (patchDir != string.Empty)
            {
                btnPatch.Enabled = true;  // enable patching if both fields are filled
            }
        }

        private void btnSelectPatch_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            fd.Description = "Select Your Patch Folder";

            if (fd.ShowDialog() != DialogResult.OK) return;

            string selectedPath = fd.SelectedPath;

            if (!selectedPath.EndsWith("_dir"))
            {
                MessageBox.Show("Invalid patch folder name.", "Error");
                return;
            }

            patchDir = selectedPath;  // name of selected folder

            txtFrom.Text = patchDir;
            if (gameDir != string.Empty)
            {
                btnPatch.Enabled = true;  // enable patching if both fields are filled
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var selectedItems = lvBackups.SelectedItems[0].SubItems;  // { name, date, time } displayed in listview
            string vpkShortName = selectedItems[0].Text;
            string backupDate = selectedItems[1].Text;
            string backupTime = selectedItems[2].Text;

            string backupFolder = Path.Combine(backupsDir, vpkShortName, backupDate + "_" + backupTime.Replace(":", "-"));

            if (!Directory.Exists(backupFolder))
            {
                MessageBox.Show("Selected backup not found", "Error");
                return;
            }

            string vpkName = FullVPKname(vpkShortName);
            string vpkPath = Path.Combine(gameDir, vpkName);

            if (!File.Exists(Path.Combine(backupFolder, vpkName)))
            {
                MessageBox.Show("Selected backup not found", "Error");
                return;
            }

            string archName = vpkName.Replace("english", string.Empty).Replace("_dir.vpk", "_228.vpk");
            string archPath = Path.Combine(gameDir, archName);

            File.Copy(Path.Combine(backupFolder, vpkName), vpkPath, true);
            
            if (File.Exists(Path.Combine(backupFolder, archName)))  // don't error if false, it's possible to have no _228
            {
                File.Copy(Path.Combine(backupFolder, archName), archPath, true);
            }

            MessageBox.Show($"Restored {vpkShortName} backup from {backupDate} {backupTime}", "Success");
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            string vpkName = new DirectoryInfo(patchDir).Name + ".vpk";  // name of vpk is name of patch folder with a .vpk extension
            string vpkPath = Path.Combine(gameDir, vpkName);

            if (!File.Exists(vpkPath))
            {
                if (MessageBox.Show("The selected directory does not have the VPK you are trying to patch. Do you have a backup?", "Error", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    MessageBox.Show("Consider repairing your game.", "Error");
                    return;
                }

                var fd = new OpenFileDialog();
                fd.Title = "Select Your Base VPK";
                fd.Filter = "VPK files (*.vpk)|*.vpk";

                if (fd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string selectedVPK = fd.FileName;
                if (!selectedVPK.EndsWith(vpkName))
                {
                    MessageBox.Show("This VPK does not match the name of your patch folder.", "Error");
                    return;
                }

                File.Copy(selectedVPK, vpkPath, true);  // put backup into game dir
            }

            string archName = vpkName.Replace("english", string.Empty).Replace("_dir.vpk", "_228.vpk");
            string archPath = Path.Combine(gameDir, archName);

            btnPatch.Enabled = false;
            btnRestore.Enabled = false;

            if (cbBackup.Checked)
            {
                string backupFolder = Path.Combine(backupsDir, ShortVPKname(vpkName), File.GetLastWriteTime(vpkPath).ToString("yyyy-MM-dd_HH-mm-ss"));  // create folder in \backups\vpkname\ with the backup's last edit time
                Directory.CreateDirectory(backupFolder);

                File.Copy(vpkPath, Path.Combine(backupFolder, vpkName), true);

                if (File.Exists(archPath))
                {
                    File.Copy(archPath, Path.Combine(backupFolder, archName), true);
                }

                LoadBackups();  // reload listview
            }

            RSPNVPK.RSPNVPK.PatchVPK(vpkPath, patchDir);  // patch vpk and create _228

            if (cbShowConfirm.Checked)
            {
                MessageBox.Show($"Patched\n    {vpkName}\nin {gameDir}", "Success");
            }

            btnPatch.Enabled = true;
        }

        private string ShortVPKname(string vpkName)  // used for backups folder and listview display
        {
            return vpkName.Replace("englishclient_", string.Empty).Replace(".bsp.pak000_dir.vpk", string.Empty);
        }

        private string FullVPKname(string shortName)  // used to reverse listview short names
        {
            return "englishclient_" + shortName + ".bsp.pak000_dir.vpk";
        }

        // very overengineered
        private string FindDir(string path, string containedFile, string subdirs, string end = "")  // returns the path of the directory containing a given file if it can find it in any of the given subdirectories. end appends a subdirectory automatically, mostly used for recursing.
        {
            string searchPath = end;  // start appending subdirectories *before* end

            if (File.Exists(Path.Combine(path, searchPath, containedFile))) { return Path.Combine(path, searchPath); }  // if already in the dir no work needs to be done

            List<string> unsearchedSubdirs = subdirs.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (unsearchedSubdirs.Count > 0)
            {
                string subdir = unsearchedSubdirs.Last();  // work from last subdir back to first
                unsearchedSubdirs.RemoveAt(unsearchedSubdirs.Count - 1);

                if (subdir.Contains('|'))  // special character indicating to recurse over multiple options
                {
                    string[] branches = subdir.Split('|');  // get each option

                    foreach (string branch in branches)
                    {
                        string recSubdirs = Path.Combine(unsearchedSubdirs.ToArray());  // feed the remaining subdirs we haven't searched to the recursed function
                        string recEnd = Path.Combine(branch, searchPath);  // append the currently searched subdirs to the recursed search (so we don't have to search them all again)

                        string recResult = FindDir(path, containedFile, recSubdirs, recEnd);  // search the rest of the subdirs with the current branch
                        if (recResult != string.Empty) { return recResult; }  // found directory we're looking for
                    }
                }

                searchPath = Path.Combine(subdir, searchPath);  // prepend the subdir that's being searched

                if (File.Exists(Path.Combine(path, searchPath, containedFile))) { return Path.Combine(path, searchPath); }  // found file, return location
            }

            return string.Empty;  // didn't find file, return ""
        }


        private void LoadPrefs()  // load saved options
        {
            prefs.SetPrefsFromFile(prefsPath);

            gameDir = prefs.gameDir;
            patchDir = prefs.patchDir;
            cbShowConfirm.Checked = prefs.showConfirm;
            cbBackup.Checked = prefs.backup;
        }

        private void LoadBackups()  // read backups folder to populate backups listview
        {
            lvBackups.Items.Clear();

            if (!Directory.Exists(backupsDir)) return;

            var allBackupInfo = new List<string[]>();

            foreach (var backupName in Directory.EnumerateDirectories(backupsDir))  // \backups\frontend, \backups\mp_common, etc
            {
                string shortName = new DirectoryInfo(backupName).Name;

                foreach (var backupFolder in Directory.EnumerateDirectories(backupName))  // timestamped folders
                {
                    string backupData = new DirectoryInfo(backupFolder).Name;

                    if (!backupData.Contains("_")) continue;

                    string[] backupSections = backupData.Split("_");
                    string date = backupSections[0];
                    string time = backupSections[1].Replace("-", ":");
                    
                    if (!DateTime.TryParse(date + " " + time, out var _)) continue;

                    allBackupInfo.Add(new string[] { shortName, date, time });
                }
            }

            foreach (string[] backupInfoArray in allBackupInfo)
            {
                lvBackups.Items.Add(new ListViewItem(backupInfoArray));  // short name, date, time
            }

            lvBackups.Sort();
        }

        class ListViewDateComparer : IComparer
        { 
            public int Compare(object x, object y)
            {
                var xx = (ListViewItem)x;
                var yy = (ListViewItem)y;

                if (!DateTime.TryParse(xx.SubItems[1].Text + " " + xx.SubItems[2].Text, out DateTime t1))
                {
                    return int.MaxValue;
                }

                if (!DateTime.TryParse(yy.SubItems[1].Text + " " + yy.SubItems[2].Text, out DateTime t2))
                {
                    return int.MinValue;
                }
                
                return -1 * DateTime.Compare(t1, t2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPrefs();

            lvBackups.ListViewItemSorter = new ListViewDateComparer();
            LoadBackups();

            txtFrom.Text = patchDir;
            txtTo.Text = gameDir;

            if (patchDir != string.Empty && gameDir != string.Empty)
            {
                btnPatch.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            prefs.gameDir = gameDir;
            prefs.patchDir = patchDir;
            prefs.showConfirm = cbShowConfirm.Checked;
            prefs.backup = cbBackup.Checked;

            prefs.WritePrefsToFile(prefsPath);
        }

        private void lvBackups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBackups.SelectedIndices.Count == 0)
            {
                btnRestore.Enabled = false;
                return;
            }

            btnRestore.Enabled = true;
        }
    }

    public class Prefs
    {
        public string gameDir   = "";
        public string patchDir  = "";
        public bool showConfirm = true;
        public bool backup      = true;

        public void SetPrefsFromFile(string path)
        {
            if (File.Exists(path))
            {
                string[] prefsLines = File.ReadAllLines(path);

                if (prefsLines.Length >= 4)
                {
                    gameDir = prefsLines[0];
                    patchDir = prefsLines[1];
                    if (bool.TryParse(prefsLines[2], out bool tmpSC)) { showConfirm = tmpSC; }
                    if (bool.TryParse(prefsLines[3], out bool tmpBack)) { backup = tmpBack; }
                }
            }
        }

        public void WritePrefsToFile(string path)
        {
            File.WriteAllText(path, string.Join("\n", gameDir, patchDir, showConfirm, backup));
        }
    }
}
