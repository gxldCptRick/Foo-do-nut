﻿using DataAccessLib.services.interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using WikiData;

namespace DataAccessLib.services
{
    public class WikiService : IWikiService
    {
        private const string BaseUrl = "http://localhost:8080/wiki/food/";

        private IEnumerable<WikiPage> GetPagesByUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            
            using (WebResponse response = request.GetResponse())
            {
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                using (var dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(dataStream))
                    {
                        using (var jsonReader = new JsonTextReader(reader))
                            while (jsonReader.Read())
                            {
                                if (jsonReader.TokenType == JsonToken.StartObject)
                                {
                                    var jobj = JObject.Load(jsonReader);
                                    var page = WikiPage.FromJson(jobj.ToString());
                                    yield return page;
                                }
                            }
                    }
                }
            }
        }

        public IEnumerable<WikiPage> GetAllPages()
        {
            return GetPagesByUrl(BaseUrl);
        }

        public IEnumerable<WikiPage> GetSpecificPagesBasedOnString(string query)
        {
            IEnumerable<WikiPage> pages = new List<WikiPage>();
            if(Regex.IsMatch(query, @"^[a-zA-Z0-9_]+$"))
                pages =  GetPagesByUrl(BaseUrl + query);
            return pages;
        }
    }
}
