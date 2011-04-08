using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;

namespace ContentSecurityPolicy.Net.Config
{
    public class PolicyDirectiveElement : ConfigurationElementCollection
    {
        [ConfigurationProperty("allowSelf")]
        public bool AllowSelf
        {
            get { return (bool)this["allowSelf"]; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new SourceElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SourceElement)element).Source;
        }
    }
    internal static class PolicyDiretiveElementHelper {
        public static PolicyDirective AsDirective(this PolicyDirectiveElement element, string name)
        {
            if (element == null) return null;
            var directive =  new UriPolicyDirective(name);
            foreach (SourceElement source in element)
            {
                directive.AddSource(source.Source);
            }
            directive.IncludeSelf = element.AllowSelf;
            return directive;
        }
    }

   
}
