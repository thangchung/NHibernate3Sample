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
    }
}