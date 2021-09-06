using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace RSPNVPK
{
    public class RSPNVPK
    {
        public static void PatchVPK(string VPKpath, string patchDir)
        {
            var vpkdir = VPKpath;
            if(!vpkdir.EndsWith("_dir.vpk"))
            {
                Console.WriteLine($"Invalid directory file {vpkdir}");
                Console.ReadLine();
                return;
            }

            var vpkarch = vpkdir.Replace("_dir.vpk", "_228.vpk").Replace("english", "");
            var directory = patchDir;

            Console.WriteLine($"VPK directory: {vpkdir}\n" +
                $"VPK archive: {vpkarch}\n" +
                $"Directory: {directory}");

            var filesList = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories).Select(path => path.Replace(directory, "").Replace(Path.DirectorySeparatorChar, '/')).ToList();
            var filesEdit = new List<string>();
            var filesDelete = new List<string>();

            foreach(var file in filesList)
            {
                if (file.EndsWith(".delete"))
                {
                    filesDelete.Add(file.Replace(".delete", null)); // Efficiency! ecksde
                }
                else
                {
                    filesEdit.Add(file);
                }
            }
            filesList = null; // Dispose ecksde

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var edit in filesEdit)
            {
                Console.WriteLine($"\t[+]{edit}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var edit in filesDelete)
            {
                Console.WriteLine($"\t[-]{edit}");
            }
            Console.ResetColor();

            var dirFstream = new FileStream(vpkdir, FileMode.Open, FileAccess.ReadWrite);
            var archFstream = new FileStream(vpkarch, FileMode.OpenOrCreate, FileAccess.Write);
            archFstream.Position = 0;
            archFstream.SetLength(0);

            var writer = new BinaryWriter(dirFstream);
            var vpk = new VPK.DirFile(dirFstream);
            Console.WriteLine($"{vpk.Header.DirectorySize:X4} | {vpk.Header.EmbeddedChunkSize:X4}");

            var list = vpk.EntryBlocks.ToList();

            for (var i = 0; i < list.Count; i++)
            {
                var block = list[i];
                string edited = null;

                foreach (var edit in filesEdit)
                {
                    if (edit == block.Path)
                    {
                        var bak = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Replacing {edit}...");
                        Console.ForegroundColor = bak;

                        var fb = File.ReadAllBytes(directory + edit);
                        if (fb.Length == 0)
                            throw new Exception("Brih");

                        list[i] = new VPK.DirEntryBlock(fb, (ulong)archFstream.Position, 228, 0x101, 0, block.Path);

                        archFstream.Write(fb);
                        archFstream.Flush();

                        edited = edit;
                        break;
                    }
                }

                if (edited != null)
                    filesEdit.Remove(edited);
                else
                {
                    foreach(var edit in filesDelete)
                    {
                        if (edit == block.Path)
                        {
                            var bak = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Deleting {edit}...");
                            Console.ForegroundColor = bak;

                            list.RemoveAt(i);
                            i--; // Negate ++

                            edited = edit;

                            break;
                        }
                    }

                    if (edited != null)
                        filesDelete.Remove(edited);
                }
            }

            // if there are still files left...
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var edit in filesEdit)
            {
                Console.WriteLine($"Adding {edit}...");

                var fb = File.ReadAllBytes(directory + edit);
                if (fb.Length == 0)
                    throw new Exception("Brih");

                list.Add(new VPK.DirEntryBlock(fb, (ulong)archFstream.Position, 228, 0x101, 0, edit));

                archFstream.Write(fb);
                archFstream.Flush();
            }
            Console.ResetColor();

            writer.BaseStream.Position = 0;
            VPK.DirFile.Write(writer, list.ToArray());

            writer.Close();  // these don't get closed in the original version for some reason lol
            dirFstream.Close();
            archFstream.Close();

        }
    }
}
