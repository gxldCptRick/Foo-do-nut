using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WikiData;

namespace DataAccessLib.services
{
    public class WikiService
    {
        public List<WikiPage> GetAllPages() {

            WebRequest request = WebRequest.Create("http://127.0.0.1:8080/wiki/yes");
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
                            JObject wikiPageJObj = JObject.Parse(json);
                        }
                    }
                }


                return null;
            }
        }
    }
}
