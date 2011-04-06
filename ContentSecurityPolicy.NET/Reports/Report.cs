using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ContentSecurityPolicy.Net.Reports
{
    [DataContract]
    public class Report
    {
        [DataMember(Name="request")]
        public string Request;
        [DataMember(Name = "request-headers")]
        public string RequestHeaders;
        [DataMember(Name = "blocked-uri")]
        public string BlockedUri;
        [DataMember(Name = "violated-directive")]
        public string ViolatedDirective;
        [DataMember(Name = "original-policy")]
        public string OriginalPolicy;
    }
    [DataContract]
    public class CspReport
    {
        [DataMember(Name = "csp-report")]
        public Report Report;
    }
}
