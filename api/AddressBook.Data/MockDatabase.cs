using AddressBook.Data.Address;
using AddressBook.Data.Person;
using AddressBook.Utils.DependencyInjection;

namespace AddressBook.Data
{
  [InjectSingleton]
  public class MockDatabase
  {
    public MockDatabase()
    {
      PersonTable = new List<PersonRecord>
      {
        new PersonRecord
        {
          PersonId = Guid.NewGuid().ToString(),
          CreationTime = DateTimeOffset.UtcNow,
          FirstName = "Manny",
          LastName = "Villa",
        }
      };

      AddressTable = new List<AddressRecord>
      {
        new AddressRecord
        {
          Address1 = "123",
          Address2 = string.Empty,
          AddressID = Guid.NewGuid().ToString(),
          City = "Dream City",
          CreationTime = DateTimeOffset.UtcNow,
          IsDefault = true,
          LastUpdatedTime = null,
          PersonID = PersonTable.First().PersonId,
          PostalCode = "123456",
          State = "Wisconsin"
        }
      };
    }

    public List<AddressRecord> AddressTable { get; init; }
    public List<PersonRecord> PersonTable { get; init; }
  }
}

