using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class StringLengthConvention : AttributePropertyConvention<StringLengthAttribute>
    {
        protected override void Apply(StringLengthAttribute attribute, IPropertyInstance instance)
        {
            instance.Length(attribute.MaximumLength);
        }
    }
}