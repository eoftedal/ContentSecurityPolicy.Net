using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ContentSecurityPolicy.Net.Config
{
    public class ContentSecurityPolicySection : ConfigurationSection
    {
        [ConfigurationProperty("reportOnly")]
        public bool ReportOnly
        {
            get { return "true".Equals(this["reportOnly"]); }
        }
        [ConfigurationProperty("reportUri")]
        public string ReportUri
        {
            get { return (string)this["reportUri"]; }
        }


        [ConfigurationProperty("options", IsRequired = false)]
        public OptionsElement Options
        {
            get { return (OptionsElement)this["options"]; }
        }

        [ConfigurationProperty("allowedSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedSources
        {
            get { return (PolicyDirectiveElement)this["allowedSources"]; }
        }
        [ConfigurationProperty("allowedScriptSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedScriptSources
        {
            get { return (PolicyDirectiveElement)this["allowedScriptSources"]; }
        }
        [ConfigurationProperty("allowedImageSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedImageSources
        {
            get { return (PolicyDirectiveElement)this["allowedImageSources"]; }
        }
        [ConfigurationProperty("allowedMediaSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedMediaSources
        {
            get { return (PolicyDirectiveElement)this["allowedMediaSources"]; }
        }
        [ConfigurationProperty("allowedObjectSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedObjectSources
        {
            get { return (PolicyDirectiveElement)this["allowedObjectSources"]; }
        }
        [ConfigurationProperty("allowedFrameSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedFrameSources
        {
            get { return (PolicyDirectiveElement)this["allowedFrameSources"]; }
        }
        [ConfigurationProperty("allowedFontSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedFontSources
        {
            get { return (PolicyDirectiveElement)this["allowedFontSources"]; }
        }
        [ConfigurationProperty("allowedXhrSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedXhrSources
        {
            get { return (PolicyDirectiveElement)this["allowedXhrSources"]; }
        }
        [ConfigurationProperty("allowedFrameAncestors", IsRequired = false)]
        public PolicyDirectiveElement AllowedFrameAncestors
        {
            get { return (PolicyDirectiveElement)this["allowedFrameAncestors"]; }
        }
        [ConfigurationProperty("allowedStyleSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedStyleSources
        {
            get { return (PolicyDirectiveElement)this["allowedStyleSources"]; }
        }

        public Policy ToPolicy()
        {
            var policy = new Policy {ReportOnlyMode = ReportOnly, ReportUri = ReportUri};
            if (Options != null)
            {
                policy.AddDirective(Options.AsDirective());
            }
            policy.AddDirective(AllowedSources.AsDirective("allow"));
            policy.AddDirective(AllowedFontSources.AsDirective("font-src"));
            policy.AddDirective(AllowedFrameAncestors.AsDirective("frame-ancestors"));
            policy.AddDirective(AllowedFrameSources.AsDirective("frame-src"));
            policy.AddDirective(AllowedImageSources.AsDirective("img-src"));
            policy.AddDirective(AllowedMediaSources.AsDirective("media-src"));
            policy.AddDirective(AllowedObjectSources.AsDirective("object-src"));
            policy.AddDirective(AllowedScriptSources.AsDirective("script-src"));
            policy.AddDirective(AllowedStyleSources.AsDirective("style-src"));
            policy.AddDirective(AllowedXhrSources.AsDirective("xhr-src"));
            return policy;
        }
    }
}