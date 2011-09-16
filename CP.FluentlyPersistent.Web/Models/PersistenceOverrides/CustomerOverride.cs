using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace CP.FluentlyPersistent.Web.Models.Domain
{
    public class CustomerOverride : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping)
        {
            mapping.References(x => x.SupportRep);
        }
    }
}