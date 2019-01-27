using ITEC_491_GroupProject;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC_491_GroupProject.Utils
{
    public static class DatabaseUtilities
    {
        public static Database LoadData()
        {
            string data;
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Dejan\Documents\Visual Studio 2015\Projects\ITEC_491_GroupProject\ITEC_491_GroupProject\Data");
            FileInfo[] TXTFiles = dir.GetFiles("data.txt");
            if (TXTFiles.Length == 0)
            {
                WorkContext.database = new Database();
                data = JsonConvert.SerializeObject(WorkContext.database);
                File.AppendAllText(@"C:\Users\Dejan\Documents\Visual Studio 2015\Projects\ITEC_491_GroupProject\ITEC_491_GroupProject\Data\data.txt",data);
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
                        File.AppendAllText(@"C:\Users\Dejan\Documents\Visual Studio 2015\Projects\ITEC_491_GroupProject\ITEC_491_GroupProject\Data\data.txt", data);
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
            string text;
            var fileStream = new FileStream(@"C:\Users\Dejan\Documents\Visual Studio 2015\Projects\ITEC_491_GroupProject\ITEC_491_GroupProject\Data\data.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            return text;
        }
        public static void Save(Database db)
        {
            string data;

            data = JsonConvert.SerializeObject(db);
            File.WriteAllText((@"C:\Users\Dejan\Documents\Visual Studio 2015\Projects\ITEC_491_GroupProject\ITEC_491_GroupProject\Data\data.txt"), string.Empty);
            File.AppendAllText(@"C:\Users\Dejan\Documents\Visual Studio 2015\Projects\ITEC_491_GroupProject\ITEC_491_GroupProject\Data\data.txt", data);
        }

    }
}
