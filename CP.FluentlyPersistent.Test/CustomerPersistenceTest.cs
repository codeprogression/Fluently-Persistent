using CP.FluentlyPersistent.Test.Comparers;
using CP.FluentlyPersistent.Web.Models.Domain;
using FluentNHibernate.Testing;
using Machine.Specifications;

namespace CP.FluentlyPersistent.Test
{
    public class CustomerPersistenceTest
    {
        Because of = () =>
            {
                _spec = new PersistenceSpecification<Customer>(SpecificationContext.Session)
                    .CheckProperty(x => x.Id, 1)
                    .CheckProperty(x => x.FirstName, "Richard")
                    .CheckProperty(x => x.LastName, "Cirerol")
                    .CheckProperty(x => x.Email, null)
                    .CheckProperty(x => x.AddressInfo,
                                   new AddressInfo
                                       {
                                           Address = "123 My Street",
                                           City = "Boise",
                                           State = "Idaho"
                                       }, new AddressInfoComparer())
                    ;

            };
        It should_persist_correctly = () => _spec.VerifyTheMappings();
        static PersistenceSpecification<Customer> _spec;
    }
}