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
        public virtual PolicyDirective ToDirective(String name)
        {
            var  directive = new UriPolicyDirective(name);
            AddSourcesAndSelf(directive);
            return directive;

        }

        protected void AddSourcesAndSelf(UriPolicyDirective directive)
        {
            foreach (SourceElement source in this)
            {
                directive.AddSource(source.Source);
            }
            directive.IncludeSelf = AllowSelf;
        }
    }
    internal static class PolicyDiretiveElementHelper {
        public static PolicyDirective AsDirective(this PolicyDirectiveElement element, string name)
        {
            if (element == null) return null;
            return element.ToDirective(name);
        }
    }

   
}
