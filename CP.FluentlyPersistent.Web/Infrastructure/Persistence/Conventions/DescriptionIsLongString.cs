using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class DescriptionIsLongString : IPropertyConvention, IPropertyConventionAcceptance
    {
        public bool Accept(IPropertyInspector propertyMapping)
        {
            return propertyMapping.Type == typeof(string) && 
                propertyMapping.Property.Name.ToLower() == "description";
        }

        public void Apply(IPropertyInstance propertyMapping)
        {
            propertyMapping.Length(4000);
        }

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x=>Accept(x));
        }

    }
}
