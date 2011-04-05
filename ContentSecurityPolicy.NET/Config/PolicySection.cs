using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ContentSecurityPolicy.Net.Config
{
    public class ContentSecurityPolicySection : ConfigurationSection
    {
        [ConfigurationProperty("ReportOnly")]
        public bool ReportOnly
        {
            get { return "true".Equals(this["ReportOnly"]); }
        }
        [ConfigurationProperty("ReportUri")]
        public string ReportUri
        {
            get { return (string)this["ReportUri"]; }
        }


        [ConfigurationProperty("Options", IsRequired = false)]
        public OptionsElement Options
        {
            get { return (OptionsElement)this["Options"]; }
        }

        [ConfigurationProperty("AllowedSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedSources
        {
            get { return (PolicyDirectiveElement)this["AllowedSources"]; }
        }
        [ConfigurationProperty("AllowedScriptSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedScriptSources
        {
            get { return (PolicyDirectiveElement)this["AllowedScriptSources"]; }
        }
        [ConfigurationProperty("AllowedImageSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedImageSources
        {
            get { return (PolicyDirectiveElement)this["AllowedImageSources"]; }
        }
        [ConfigurationProperty("AllowedMediaSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedMediaSources
        {
            get { return (PolicyDirectiveElement)this["AllowedMediaSources"]; }
        }
        [ConfigurationProperty("AllowedObjectSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedObjectSources
        {
            get { return (PolicyDirectiveElement)this["AllowedObjectSources"]; }
        }
        [ConfigurationProperty("AllowedFrameSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedFrameSources
        {
            get { return (PolicyDirectiveElement)this["AllowedFrameSources"]; }
        }
        [ConfigurationProperty("AllowedFontSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedFontSources
        {
            get { return (PolicyDirectiveElement)this["AllowedFontSources"]; }
        }
        [ConfigurationProperty("AllowedXhrSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedXhrSources
        {
            get { return (PolicyDirectiveElement)this["AllowedXhrSources"]; }
        }
        [ConfigurationProperty("AllowedFrameAncestors", IsRequired = false)]
        public PolicyDirectiveElement AllowedFrameAncestors
        {
            get { return (PolicyDirectiveElement)this["AllowedFrameAncestors"]; }
        }
        [ConfigurationProperty("AllowedStyleSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedStyleSources
        {
            get { return (PolicyDirectiveElement)this["AllowedStyleSources"]; }
        }

        public Policy ToPolicy()
        {
            var policy = new Policy();
            policy.ReportOnlyMode = ReportOnly;
            policy.ReportUri = ReportUri;
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