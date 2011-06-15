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

        public KeyValuePair<string, string> GetHeader()
        {
            return new KeyValuePair<string, string>(
                GetHeaderName(),
                GetHeaderValue()
                );
        }
        public KeyValuePair<string, string> GetHeaderChrome()
        {
            return new KeyValuePair<string, string>(
                GetHeaderNameChrome(),
                GetHeaderValue()
                );
        }

        public string GetHeaderNameChrome()
        {
            return _policyHeaderChrome + GetReportingPart();
        }
        
        public string GetHeaderName()
        {
            return _policyHeader + GetReportingPart();
        }

        private string GetReportingPart()
        {
            return ReportOnlyMode ? _reportingOnlyPolicyHeader : "";
        }

        public string GetHeaderValue()
        {
            return _policyDirectives
                .Select(p => p.ToString())
                .Where(s => !string.IsNullOrEmpty(s))
                .Aggregate((s1, s2) => s1 + "; " + s2)
                + (ReportUri == null ? "" : "; report-uri " + ReportUri);
        }
        public static Policy LoadFromConfig()
        {
            var section = (ContentSecurityPolicySection)ConfigurationManager.GetSection("contentSecurityPolicy");
            return section.ToPolicy();
        }
    }
}
