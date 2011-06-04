using System.Collections;
using System.Collections.Generic;
using CP.FluentlyPersistent.Web.Models.Domain;

namespace CP.FluentlyPersistent.Test.Comparers
{
    internal class PhoneInfoComparer : IEqualityComparer<PhoneInfo>, IEqualityComparer
    {
        public bool Equals(PhoneInfo x, PhoneInfo y)
        {
            if (ReferenceEquals(null, x)) return false;
            if (ReferenceEquals(null, y)) return false;
            if (ReferenceEquals(x, y)) return true;
            return Equals(x.Phone, y.Phone) && Equals(x.Fax, y.Fax);
        }

        public int GetHashCode(PhoneInfo obj)
        {
            return ((obj.Phone != null ? obj.Phone.GetHashCode() : 0) * 397) ^ (obj.Fax != null ? obj.Fax.GetHashCode() : 0);
        }

        public bool Equals(object x, object y)
        {
            return Equals((PhoneInfo) x, (PhoneInfo) y);
        }

        public int GetHashCode(object obj)
        {
            return GetHashCode((PhoneInfo)obj);
        }
    }
}