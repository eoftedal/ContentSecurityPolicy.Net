using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ContentSecurityPolicy.Net.Config
{
    public class OptionsElement : ConfigurationElement
    {
        [ConfigurationProperty("allowInlineScript")]
        public bool AllowInlineScripts
        {
            get { return (bool)this["allowInlineScript"]; }
        }
        [ConfigurationProperty("allowScriptEval")]
        public bool AllowScriptEval
        {
            get { return (bool)this["allowScriptEval"]; }
        }

    }
}
