using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace ContentSecurityPolicy.Net
{
    public class Policy
    {
        private const string _policyHeader = "X-Content-Security-Policy";
        private const string _reportingOnlyPolicyHeader = _policyHeader + "-Report-Only";
        private readonly List<PolicyDirective> _policyDirectives = new List<PolicyDirective>();
        public string ReportUri { get; set; }
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

        public string GetHeaderName()
        {
            return ReportOnlyMode ? _reportingOnlyPolicyHeader : _policyHeader;
        }
        public string GetHeaderValue()
        {
            return _policyDirectives
                .Select(p => p.ToString())
                .Where(s => !string.IsNullOrEmpty(s))
                .Aggregate((s1, s2) => s1 + "; " + s2);
        }
    }
}
