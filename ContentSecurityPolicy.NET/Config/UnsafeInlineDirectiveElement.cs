using System.Configuration;

namespace ContentSecurityPolicy.Net.Config
{
    public class UnsafeInlineDirectiveElement : PolicyDirectiveElement
    {
        [ConfigurationProperty("unsafeAllowInline")]
        public bool UnsafeAllowInline
        {
            get { return (bool)this["unsafeAllowInline"]; }
        }
        public bool HasUnsafeAllowInline
        {
            get { return this["unsafeAllowInline"] != null; }
        }


        public override PolicyDirective ToDirective(string name)
        {
            var directive = new UnsafeInlinePolicyDirective(name) {UnsafeAllowInline = UnsafeAllowInline};
            AddSourcesAndSelf(directive);
            return directive;
        }
    }
}
