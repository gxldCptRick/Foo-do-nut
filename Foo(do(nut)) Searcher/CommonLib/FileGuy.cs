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

        public ICollection<string> ReadFile(string filePath)
        {
            ICollection<string> searches = new HashSet<string>();

            Directory.CreateDirectory("./searches");

            if (File.Exists(filePath))
            {
                var fileStream = File.OpenRead(filePath);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        searches.Add(line);
                        line = reader.ReadLine();
                    }
                }
            }

            return searches;
        }

        public void WriteFile(ICollection<string> searches, string filePath)
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