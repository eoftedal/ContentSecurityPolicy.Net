using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Globalization;

namespace ContentSecurityPolicy.Net.Config
{
    public class SourceElement : ConfigurationElement
    {
        [ConfigurationProperty("source", IsRequired = true)]
        [TypeConverter(typeof(SourceConverter))]
        public Source Source
        {
            get { return (Source)this["source"]; }
        }
    }

    internal class SourceConverter : ConfigurationConverterBase
    {
        public override bool CanConvertFrom(ITypeDescriptorContext ctx, Type type)
        {
            return (type == typeof(string));
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return new Source(value as string);
        }

        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            return Source.IsValidSource(value as string);
        }
    }
}
