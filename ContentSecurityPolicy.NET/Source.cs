using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ContentSecurityPolicy.Net
{
    public class Source
    {
        private const string scheme = @"([a-zA-Z][a-zA-Z0-9\+\-\.]+:[/]{0,2})?";
        private const string host = @"(\*|(\*\.)?[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]+)+)";
        private const string port = @"(:[0-9]+)?";

        private static Regex _sourcePattern = new Regex("^" + scheme + host + port + "$");

        public string HostPattern { get; private set; }
        public Source(string hostPattern)
        {
            if (!_sourcePattern.IsMatch(hostPattern)) throw new ArgumentException("Not a valid source");
            HostPattern = hostPattern;
        }
        public static bool IsValidSource(string source)
        {
            return _sourcePattern.IsMatch(source);
        }
    }
}
