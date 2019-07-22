using BookLibrary.Domain.Data.Infrastructure;

namespace BookLibrary.Domain.Data.Models
{
    public class FullName : ValueObject<FullName>
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        protected override bool EqualsCore(FullName compareTo)
        {
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return FirstName.Equals(compareTo.FirstName) && LastName.Equals(compareTo.LastName);
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}