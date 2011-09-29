using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ContentSecurityPolicy.Net.Reports
{
    public abstract class AbstractReportHandler : IHttpHandler 
    {

        public bool IsReusable
        {
            get { return true; }
        }
        //"document-url=http%3A%2F%2Flocalhost%3A56536%2F&violated-directive=script-src+http%3A%2F%2Ferlend.oftedal.no"

        public void ProcessRequest(HttpContext context)
        {
            if (new Useragent(context.Request.UserAgent).IsFirefox())
            {
                var des = new DataContractJsonSerializer(typeof (CspReport));
                var wrappedReport = des.ReadObject(context.Request.InputStream) as CspReport;
                HandleReport(wrappedReport.Report);
            } else
            {
                var report = new Report();
                using(var reader = new StreamReader(context.Request.InputStream))
                {
                    var urlencodedReport = reader.ReadToEnd();
                    var parts = urlencodedReport.Split('&').Select(s => s.Split(new[] {'='}, 2)).ToDictionary(
                        s => s[0], s => HttpUtility.UrlDecode(s[1]));
                    report.ViolatedDirective = parts["violated-directive"];
                    report.Request = parts["document-url"];
                    HandleReport(report);
                }
            }
        }
        protected abstract void HandleReport(Report report);
    }
}
