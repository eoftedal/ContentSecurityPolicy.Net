using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ContentSecurityPolicy.Net.Config
{
    public class ScriptDirectiveElement : UnsafeInlineDirectiveElement
    {
        [ConfigurationProperty("unsafeAllowEval")]
        public bool UnsafeAllowEval
        {
            get { return (bool)this["unsafeAllowEval"]; }
        }
        public override PolicyDirective ToDirective(string name)
        {
            var directive = new ScriptPolicyDirective
                                {
                                    UnsafeAllowEval = UnsafeAllowEval,
                                    UnsafeAllowInline = UnsafeAllowInline
                                };
            AddSourcesAndSelf(directive);
            return directive;
        }
    }
}
