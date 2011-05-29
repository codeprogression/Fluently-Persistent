using System;
using System.Collections.Generic;
using System.Linq;

namespace CP.FluentlyPersistent.Core.Domain
{
    public class Invoice : Entity
    {
        public virtual Customer Customer { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
        public virtual IList<InvoiceLine> InvoiceLines { get; set; } 
        public virtual double Total { get { return InvoiceLines.Sum(line => line.Subtotal); } }
    }

    public class InvoiceLine : Entity
    {
        public virtual Track Track { get; set; }
        public virtual int Quantity { get; set; }
        public virtual double UnitPrice { get; set; }

        public virtual double Subtotal
        {
            get { return Quantity * UnitPrice; }
        }
    }
}