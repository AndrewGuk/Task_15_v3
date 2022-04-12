using System;
using System.IO.Compression;
using System.Collections.Specialized;


namespace Search_and_Archive
{
    public class SearchAndArchive
    {
        StringCollection log = new StringCollection();
        public string NameSearchFile { get; set; }
        public string DirectoryFile  { get; set; }
        //принимающий файл:
        // @"D:\floder\"
        public SearchAndArchive(string NameSearchFile, string DirectoryFile)
        {
            this.NameSearchFile = NameSearchFile;
            this.DirectoryFile = DirectoryFile;
            Walk(new DirectoryInfo(DirectoryFile), NameSearchFile);
        }

        async void Walk(DirectoryInfo root, string search)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            //Walk(new DirectoryInfo(path), search);
            //Console.WriteLine("files block:");
            //foreach (string item in log)
            //{
            //    Console.WriteLine(item);
            //}

            //получаем все файлыв текущем каталоге
            try
            {
                files = root.GetFiles("*.*");
                if (files.Length > 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Name.Contains(search))
                        {
                            ZipFile.CreateFromDirectory(files[0].DirectoryName, files[i].DirectoryName + ".zip");
                            Console.WriteLine($"Done!\nFile {files[i].Name} is zipped!" +
                                $"\nAdres : {files[i].Directory}");
                            return;
                        }
                    }
                    Console.WriteLine($"Sorry, i don't find file with name <{search}>");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                log.Add(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (files != null)
            {
                //выводим имена папок в консоль
                //foreach (FileInfo item in files)
                //{
                //    Console.WriteLine(item.FullName);
                //}

                //получаем все подкатегории
                subDirs = root.GetDirectories();

                //проходим по каждому каталогу
                foreach (DirectoryInfo item in subDirs)
                {
                    //рекурсия
                    Walk(item, search);
                }
            }
        }
    }
}