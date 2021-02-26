using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeRavn.Helpers
{ 
    //This class is a helper that allows to get desired data from URL.
    public class ParseUrlHelper
    {
        public ParseUrlHelper()
        {

        }
        public string GetIdFromURL(string url)
        {
            var urlParsed = url.Substring(0, url.Length - 1);
            var indexChar = urlParsed.LastIndexOf("/");
            return urlParsed.Substring(indexChar + 1);
        }

        public string GetPageIdFromURL(string url)
        {
            var indexChar = url.LastIndexOf("/");
            return url.Substring(indexChar + 1);
        }
    }
}
