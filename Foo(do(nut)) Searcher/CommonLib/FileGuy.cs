using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommonLib
{
    public class FileGuy
    {
        public string filePath = "./searches/searches.txt";

        public ICollection<string> ReadFile()
        {
            ICollection<string> searches = new List<string>();

            Directory.CreateDirectory("./searches");

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    searches.Add(line);
                    line = reader.ReadLine();
                }
            }
            return searches;
        }

        public void WriteFile(ICollection<string> searches)
        {
            if (File.Exists(filePath))
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    foreach (var search in searches)
                    {
                        writer.WriteLine(search);
                    }
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var search in searches)
                    {
                        writer.WriteLine(search);
                    }
                }
            }
        }

    }
}
