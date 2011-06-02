using System;
using System.ComponentModel.DataAnnotations;

namespace CP.FluentlyPersistent.Web.Models.Domain
{
    public class Customer : Entity
    {
        [Required, StringLength(40)]
        public virtual string FirstName { get; set; }

        [Required, StringLength(20)]
        public virtual string LastName { get; set; }

        [StringLength(70)]
        public virtual string Company { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }
        public virtual PhoneInfo PhoneInfo { get; set; }

        [Required, StringLength(60)]
        public virtual string Email { get; set; }

        public virtual Employee SupportRep { get; set; }
       
    }

    public class Employee : Entity
    {
        [StringLength(20)]
        public virtual string FirstName { get; set; }

        [StringLength(20)]
        public virtual string LastName { get; set; }

        [StringLength(30)]
        public virtual string Title { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }
        public virtual PhoneInfo PhoneInfo{ get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual DateTime HireDate { get; set; }
        public virtual Employee ReportsTo { get; set; }

        [StringLength(60)]
        public virtual string Email { get; set; }

    }

    public class AddressInfo : IComponent
    {
        [StringLength(70)]
        public virtual string Address { get; set; }

        [StringLength(40)]
        public virtual string City { get; set; }

        [StringLength(40)]
        public virtual string State { get; set; }

        [StringLength(40)]
        public virtual string Country { get; set; }

        [StringLength(10)]
        public virtual string PostalCode { get; set; }
    }

    public class PhoneInfo : IComponent
    {
        [StringLength(24)]
        public virtual string Phone { get; set; }

        [StringLength(24)]
        public virtual string Fax { get; set; }
    }
}