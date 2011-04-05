using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ContentSecurityPolicy.Net.Config
{
    public class OptionsElement : ConfigurationElement
    {
        [ConfigurationProperty("AllowInlineScripts")]
        public bool AllowInlineScripts
        {
            get { return "true".Equals(this["AllowInlineScripts"]); }
        }
        [ConfigurationProperty("AllowScriptEval")]
        public bool AllowScriptEval
        {
            get { return "true".Equals(this["AllowScriptEval"]); }
        }

        public OptionsDirective AsDirective()
        {
            return new OptionsDirective { AllowEvalScript = AllowScriptEval, AllowInlineScript = AllowInlineScripts };
        }
    }
}
