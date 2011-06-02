using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CP.FluentlyPersistent.Web.Models.Domain
{
    public class Invoice : Entity
    {
        [Required]
        public virtual Customer Customer { get; set; }

        public virtual AddressInfo BillingAddressInfo { get; set; }

        public virtual DateTime InvoiceDate { get; set; }

        public virtual IList<InvoiceLine> InvoiceLines { get; set; }

        [Required]
        public virtual decimal Total { get; set; }

        public virtual decimal CalculateTotal()
        {
            return InvoiceLines.Sum(x => x.Subtotal);
        }
    }

    public class InvoiceLine : Entity
    {
        [Required]
        public virtual Invoice Invoice { get; set; }

        [Required]
        public virtual Track Track { get; set; }

        [Required]
        public virtual int Quantity { get; set; }

        [Required]
        public virtual decimal UnitPrice { get; set; }

        public virtual decimal Subtotal
        {
            get { return Quantity*UnitPrice; }
        }
    }
}