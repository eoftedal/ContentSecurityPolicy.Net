﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using ContentSecurityPolicy.Net.Config;

namespace ContentSecurityPolicy.Net
{
    public class PolicyModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.PreRequestHandlerExecute += ApplyPolicy;
        }
        public void ApplyPolicy(object sender, EventArgs args)
        {
            var app = sender as HttpApplication;
            if (app != null)
            {
                var section = (ContentSecurityPolicySection)ConfigurationManager.GetSection("ContentSecurityPolicy");
                var policy = section.ToPolicy();
                app.Context.Response.AddHeader(policy.GetHeaderName(), policy.GetHeaderValue());
            }
        }

        public void Dispose()
        {

        }
    }
}
