using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Web.Persistence.Conventions
{
    public class NumericConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.CustomSqlType("numeric");
            instance.Precision(10);
            instance.Scale(2);
        }

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x=>x.Type==typeof(decimal));
        }
    }
}