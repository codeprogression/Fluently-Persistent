using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CP.FluentlyPersistent.Web.Models.Domain
{
    public class EmployeeOverride : IAutoMappingOverride<Employee>
    {
        public void Override(AutoMapping<Employee> mapping)
        {
            mapping.References(x => x.ReportsTo).Column("ReportsTo");
        }
    }
}