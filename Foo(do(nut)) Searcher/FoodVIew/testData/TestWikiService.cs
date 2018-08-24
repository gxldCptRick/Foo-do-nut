using DataAccessLib.services.interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using WikiData;

namespace FoodVIew.testData
{
    internal class TestWikiService : IWikiService
    {
        public IEnumerable<WikiPage> GetAllPages()
        {
            using (FileStream fsStream = new FileStream("./TestData.json", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fsStream))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        while (jsonReader.Read())
                        {
                            if (jsonReader.TokenType == JsonToken.StartObject)
                            {
                                JObject obj = JObject.Load(jsonReader);
                                yield return WikiPage.FromJson(obj.ToString());
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<WikiPage> GetSpecificPagesBasedOnString(string query)
        {
            return GetAllPages();
        }
    }
}
