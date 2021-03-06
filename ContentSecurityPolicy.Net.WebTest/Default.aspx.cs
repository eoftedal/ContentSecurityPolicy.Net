﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContentSecurityPolicy.Net.Config;

namespace ContentSecurityPolicy.Net.WebTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var policy = Policy.LoadFromConfig();
            Content.Text = policy.GetHeaderName(Request.UserAgent) + ": " + policy.GetHeaderValue(Request.UserAgent);
        }
    }
}