using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentSecurityPolicy.Net
{
    public abstract class PolicyDirective
    {
        public string DirectiveName { get; protected set; }
    }

    public class UriPolicyDirective : PolicyDirective
    {
        private readonly List<Source> _allowedSourceList = new List<Source>();
        public bool IncludeSelf { get; set; }

        public UriPolicyDirective(string directiveName)
        {
            DirectiveName = directiveName;
        }
        public override string ToString()
        {
            if (HasNoSources()) return "";
            return DirectiveName 
                + (IncludeSelf ? " 'self'" : "")
                + ImplodeSources();
        }

        private bool HasNoSources()
        {
            return !IncludeSelf && _allowedSourceList.Count() == 0;
        }

        private string ImplodeSources()
        {
            if (_allowedSourceList.Count() == 0) return "";
            return " " + _allowedSourceList
                .Select(s => s.HostPattern)
                .Aggregate((s1, s2) => s1 + " " + s2);
        }

        public void AddSource(Source source)
        {
            _allowedSourceList.Add(source);
        }
    }

    public class OptionsDirective : PolicyDirective
    {
        public bool AllowInlineScript { get; set; }
        public bool AllowEvalScript { get; set; }

        public OptionsDirective()
        {
            DirectiveName = "options";
        }

        public override string  ToString()
        {
 	        if (!AllowInlineScript && !AllowEvalScript) return "";
            return DirectiveName + " "
                + (AllowInlineScript ? "disable-xss-protection" : "")
                + (AllowEvalScript ? "eval-script" : "");
        }
    }


}
