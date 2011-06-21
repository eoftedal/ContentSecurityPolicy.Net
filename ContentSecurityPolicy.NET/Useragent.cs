using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentSecurityPolicy.Net
{
    public class Useragent
    {
        private readonly string UseragentString;
        public Useragent(string useragent)
        {
            UseragentString = useragent;
        }

        public bool IsChrome()
        {
            return UseragentString.Contains("Chrome/");
        }
        public bool IsFirefox()
        {
            return UseragentString.Contains("Firefox/");
        }

        public bool IsFirefox4()
        {
            return UseragentString.Contains("Firefox/4");
        }
    }
}
