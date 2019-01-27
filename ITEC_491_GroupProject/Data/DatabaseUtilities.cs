using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace ITEC_491_GroupProject.Utils
{
    public static class DatabaseUtilities
    {
        public static Database LoadData()
        {
            string data;
            string path = AppContext.BaseDirectory;
            DirectoryInfo dir = new DirectoryInfo(path);
            string filepath = path + "\\data.txt";
            FileInfo[] TXTFiles = dir.GetFiles("data.txt");
            if (TXTFiles.Length == 0)
            {
                WorkContext.database = new Database();
                data = JsonConvert.SerializeObject(WorkContext.database);
                File.AppendAllText(filepath,data);
                data = ReadFile();
                WorkContext.database = JsonConvert.DeserializeObject<Database>(data);
                return WorkContext.database;

            }
            else
            {
                foreach (var file in TXTFiles)
                {
                    if (file.Exists)
                    {
                        data = ReadFile();
                        WorkContext.database = JsonConvert.DeserializeObject<Database>(data);
                        return WorkContext.database;
                    }
                    else
                    {
                        data = JsonConvert.SerializeObject(WorkContext.database);
                        File.AppendAllText(filepath, data);
                        data = ReadFile();
                        WorkContext.database = JsonConvert.DeserializeObject<Database>(data);
                        return WorkContext.database;
                    }
                }
            }
            return WorkContext.database;
        }
        public static string ReadFile()
        {
            string path = AppContext.BaseDirectory;
            string filepath = path + "\\data.txt";
            string text;
            var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            return text;
        }
        public static void Save(Database db)
        {
            string path = AppContext.BaseDirectory;
            string filepath = path + "\\data.txt";
            string data;
            data = JsonConvert.SerializeObject(db);
            File.WriteAllText(filepath, string.Empty);
            File.AppendAllText(filepath, data);
        }

    }
}
