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
            get { return (bool)this["reportOnly"]; }
        }
        [ConfigurationProperty("reportUri")]
        public Uri ReportUri
        {
            get { return (Uri)this["reportUri"]; }
        }


        [ConfigurationProperty("allowedSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedSources
        {
            get { return (PolicyDirectiveElement)this["allowedSources"]; }
        }
        [ConfigurationProperty("allowedScriptSources", IsRequired = false)]
        public ScriptDirectiveElement AllowedScriptSources
        {
            get { return (ScriptDirectiveElement)this["allowedScriptSources"]; }
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
        [ConfigurationProperty("allowedConnectSources", IsRequired = false)]
        public PolicyDirectiveElement AllowedConnectSources
        {
            get { return (PolicyDirectiveElement)this["allowedConnectSources"]; }
        }
        [ConfigurationProperty("allowedFrameAncestors", IsRequired = false)]
        public PolicyDirectiveElement AllowedFrameAncestors
        {
            get { return (PolicyDirectiveElement)this["allowedFrameAncestors"]; }
        }
        [ConfigurationProperty("allowedStyleSources", IsRequired = false)]
        public UnsafeInlineDirectiveElement AllowedStyleSources
        {
            get { return (UnsafeInlineDirectiveElement)this["allowedStyleSources"]; }
        }

   

        
        
        public Policy ToPolicy()
        {

            
            
            var policy = new Policy {ReportOnlyMode = ReportOnly, ReportUri = ReportUri};
            policy.AddDirective(AllowedSources.AsDirective("default-src"));
            policy.AddDirective(AllowedFontSources.AsDirective("font-src"));
            policy.AddDirective(AllowedFrameAncestors.AsDirective("frame-ancestors"));
            policy.AddDirective(AllowedFrameSources.AsDirective("frame-src"));
            policy.AddDirective(AllowedImageSources.AsDirective("img-src"));
            policy.AddDirective(AllowedMediaSources.AsDirective("media-src"));
            policy.AddDirective(AllowedObjectSources.AsDirective("object-src"));
            policy.AddDirective(AllowedStyleSources.AsDirective("style-src"));
            policy.AddDirective(AllowedConnectSources.AsAliasedDirective("connect-src", "xhr-src"));
            policy.AddDirective(AllowedScriptSources.AsDirective("script-src"));
            return policy;
        }
    }
}