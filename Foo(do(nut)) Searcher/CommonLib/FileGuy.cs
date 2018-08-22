using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommonLib
{
    class FileGuy
    {
        public string filePath = "./searches/searches.txt";

        public ICollection<string> ReadFile()
        {
            ICollection<string> searches = new List<string>();
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
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var search in searches)
                {

                }
            }
        }

    }
}
