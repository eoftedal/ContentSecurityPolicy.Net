using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.UI;
using ContentSecurityPolicy.Net.Config;

namespace ContentSecurityPolicy.Net
{
    public class Policy
    {
        private const string _policyHeaderChrome = "X-WebKit-CSP";
        private const string _policyHeader = "X-Content-Security-Policy";
        private const string _reportingOnlyPolicyHeader = "-Report-Only";
        private readonly List<PolicyDirective> _policyDirectives = new List<PolicyDirective>();
        public Uri ReportUri { get; set; }
        public bool ReportOnlyMode { get; set; }

        public void AddDirective(PolicyDirective directive)
        {
            if (directive == null) return;
            _policyDirectives.Add(directive);
        }

        public KeyValuePair<string, string> GetHeader(string useragent)
        {
            return new KeyValuePair<string, string>(
                GetHeaderName(useragent),
                GetHeaderValue(useragent)
                );
        }

        
        public string GetHeaderName(string useragent)
        {
            if (new Useragent(useragent).IsChrome())
            {
                return _policyHeaderChrome + GetReportingPart();
            }  
            return _policyHeader + GetReportingPart();   
        }



        private string GetReportingPart()
        {
            return ReportOnlyMode ? _reportingOnlyPolicyHeader : "";
        }

        public string GetHeaderValue(string useragent)
        {
            var agent = new Useragent(useragent);
            return _policyDirectives
                .OrderBy(p => p.DirectiveName == "options" ? "1" : ("2" + p.DirectiveName))
                .Select(p => AsString(p, agent))
                .Where(s => !string.IsNullOrEmpty(s))
                .Aggregate((s1, s2) => s1 + "; " + s2)
                + ReportUriPart;

        }
        private static string AsString(PolicyDirective directive, Useragent useragent)
        {
            return directive.ToHeaderString(useragent.IsFirefox() ? CspVersion.Ff4To7 : CspVersion.Latest);
        }

        

        private string ReportUriPart
        {
            get { return ReportUri == null ? "" : "; report-uri " + ReportUri; }
        }

        public static Policy LoadFromConfig()
        {
            var section = (ContentSecurityPolicySection)ConfigurationManager.GetSection("contentSecurityPolicy");
            return section.ToPolicy();
        }
    }
}
