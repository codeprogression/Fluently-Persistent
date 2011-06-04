using System.Collections;
using System.Collections.Generic;
using CP.FluentlyPersistent.Web.Models.Domain;

namespace CP.FluentlyPersistent.Test.Comparers
{
    internal class AddressInfoComparer : IEqualityComparer<AddressInfo>, IEqualityComparer
    {
        public bool Equals(AddressInfo x, AddressInfo y)
        {
            if (ReferenceEquals(null, x)) return false;
            if (ReferenceEquals(null, y)) return false;
            if (ReferenceEquals(x, y)) return true;
            return Equals(x.Address, y.Address) && Equals(x.City, y.City) && Equals(x.State, y.State) &&
                   Equals(x.Country, y.Country) && Equals(x.PostalCode, y.PostalCode);
        }

        public int GetHashCode(AddressInfo obj)
        {
            unchecked
            {
                int result = (obj.Address != null ? obj.Address.GetHashCode() : 0);
                result = (result * 397) ^ (obj.City != null ? obj.City.GetHashCode() : 0);
                result = (result * 397) ^ (obj.State != null ? obj.State.GetHashCode() : 0);
                result = (result * 397) ^ (obj.Country != null ? obj.Country.GetHashCode() : 0);
                result = (result * 397) ^ (obj.PostalCode != null ? obj.PostalCode.GetHashCode() : 0);
                return result;
            }
        }

        public bool Equals(object x, object y)
        {
            return Equals((AddressInfo) x, (AddressInfo) y);
        }

        public int GetHashCode(object obj)
        {
            return GetHashCode((AddressInfo)obj);
        }
    }
}