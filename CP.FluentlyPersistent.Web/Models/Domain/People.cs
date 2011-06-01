using System;

namespace CP.FluentlyPersistent.Web.Models.Domain
{

    public class Customer : Person
    {
        public virtual string Company { get; set; }
    }

    public class Employee : Person
    {
        public virtual string Title { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual DateTime HireDate { get; set; }
        public virtual Employee ReportsTo { get; set; }
    }

    public class Person : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
    }
}