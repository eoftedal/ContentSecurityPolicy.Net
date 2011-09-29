using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentSecurityPolicy.Net
{
    public enum CspVersion
    {
        Ff4To7 = 0,
        Latest = 1
    }

    public abstract class PolicyDirective
    {
        public string DirectiveName { get; protected set; }
        public abstract string ToHeaderString(CspVersion version);
    }

    public class UriPolicyDirective : PolicyDirective
    {
        private readonly List<Source> _allowedSourceList = new List<Source>();
        public bool IncludeSelf { get; set; }

        public UriPolicyDirective(string directiveName)
        {
            DirectiveName = directiveName;
        }
        public override string ToHeaderString(CspVersion version)
        {
            if (HasNoSources()) return "";
            return DirectiveName 
                + (IncludeSelf ? " 'self' " : " ")
                + ImplodeSources();
        }

        protected bool HasNoSources()
        {
            return !IncludeSelf && _allowedSourceList.Count() == 0;
        }

        protected string ImplodeSources()
        {
            if (_allowedSourceList.Count() == 0) return "";
            return _allowedSourceList
                .Select(s => s.HostPattern)
                .Aggregate((s1, s2) => s1 + " " + s2);
        }

        public void AddSource(Source source)
        {
            _allowedSourceList.Add(source);
        }
    }
    public class UnsafeInlinePolicyDirective : UriPolicyDirective
    {
        public bool UnsafeAllowInline { get; set; }

        public UnsafeInlinePolicyDirective(String name) 
            :base(name)
        {
        }

        public string ToHeaderString()
        {
            if (UnsafeAllowInline == false && HasNoSources()) return "";
            return DirectiveName + " " + 
                (UnsafeAllowInline ? "'unsafe-inline' " : "")
                   + ImplodeSources();
        }
    }

    public class ScriptPolicyDirective : UnsafeInlinePolicyDirective
    {
        public bool UnsafeAllowEval { get; set; }

        public ScriptPolicyDirective() :
            base("script-src")
        {
        }

        public override string ToHeaderString(CspVersion version)
        {
            if (version == CspVersion.Ff4To7)
            {
                String header = "";
                if (UnsafeAllowEval || UnsafeAllowInline)
                {
                    header = "options " + (UnsafeAllowEval ? "eval-script " : "") +
                             (UnsafeAllowInline ? "inline-script" : "") + ";";
                }
                if (HasNoSources()) return header;
                return header + DirectiveName + " " + ImplodeSources();
            }
            if (!UnsafeAllowInline && !UnsafeAllowEval && HasNoSources()) return "";
            return DirectiveName + " "
                   + (UnsafeAllowInline ? "'unsafe-inline' " : "")
                   + (UnsafeAllowEval ? "'unsafe-eval' " : "")
                   + ImplodeSources();
        }
    }


}
