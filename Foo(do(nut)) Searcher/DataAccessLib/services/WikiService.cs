using DataAccessLib.services.interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using WikiData;

namespace DataAccessLib.services
{
    public class WikiService : IWikiService
    {
        public IEnumerable<WikiPage> GetAllPages() {
            WebRequest request = WebRequest.Create("http://127.0.0.1:8080/wiki/food/");
            request.Credentials = CredentialCache.DefaultCredentials;
            using (WebResponse response = request.GetResponse())
            {
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                using (var dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(dataStream))
                    {
                        using(var jsonReader = new JsonTextReader(reader))
                        while (jsonReader.Read())
                        {
                           var jobj = new JObject(jsonReader);
                           var page  = WikiPage.FromJson(jobj.ToString());
                            yield return page;
                        }
                    }
                }
            }
        }

        public IEnumerable<WikiPage> GetSpecificPagesBasedOnString(string query){
            WebRequest request = WebRequest.Create($"http://127.0.0.1:8080/wiki/food/{query}");
            request.Credentials = CredentialCache.DefaultCredentials;
            using (WebResponse response = request.GetResponse())
            {
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        while (!reader.EndOfStream)
                        {
                            var json = reader.ReadLine();
                            var page = WikiPage.FromJson(json);
                            yield return page;
                        }
                    }
                }
            }
        }
    }
}
