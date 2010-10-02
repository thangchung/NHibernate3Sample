namespace NHibernate3Sample.Entity
{
    public class Address
    {
        public Address()
            : this("", "", "")
        {
        }

        public Address(string street, string ward, string district)
        {
            Street = street;
            Ward = ward;
            District = district;
        }

        public virtual string Street { get; private set; }

        public virtual string Ward { get; private set; }

        public virtual string District { get; private set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Address)) return false;
            return Equals((Address) obj);
        }

        public bool Equals(Address other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Street, Street) && Equals(other.Ward, Ward) && Equals(other.District, District);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Street != null ? Street.GetHashCode() : 0);
                result = (result*397) ^ (Ward != null ? Ward.GetHashCode() : 0);
                result = (result*397) ^ (District != null ? District.GetHashCode() : 0);
                return result;
            }
        }
    }
}