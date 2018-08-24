using DataAccessLib.services.interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiData;

namespace FoodVIew.testData
{
    internal class TestWikiService : IWikiService
    {
        public IEnumerable<WikiPage> GetAllPages()
        {
            using (StreamReader reader = new StreamReader("./TestData.json")){
                using (var jsonReader = new JsonTextReader(reader)) {
                    while (jsonReader.Read())
                    {
                        var obj = new JObject(jsonReader);
                        yield return WikiPage.FromJson(obj.ToString());
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
