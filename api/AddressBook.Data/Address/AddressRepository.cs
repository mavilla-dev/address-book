using AddressBook.Utils.DependencyInjection;

namespace AddressBook.Data.Address
{
  [InjectTransient]
  public class AddressRepository : IReadAddresses, ICreateAddresses
  {
    private readonly MockDatabase _mockDatabase;

    public AddressRepository(MockDatabase mockDatabase)
    {
      _mockDatabase = mockDatabase ?? throw new ArgumentNullException(nameof(mockDatabase));
    }

    public Task<AddressRecord> CreateAddressAsync(AddressRecord addressRecord)
    {
      var table = _mockDatabase.AddressTable;

      addressRecord.AddressID = Guid.NewGuid().ToString();
      table.Add(addressRecord);
      return Task.FromResult(addressRecord);
    }

    public Task<IEnumerable<AddressRecord>> GetAddressesForPeopleAsync(IEnumerable<string> personIds)
    {
      var table = _mockDatabase.AddressTable;

      var results = table.Where(address => personIds.Contains(address.PersonID));

      return Task.FromResult(results);
    }

    public Task<IEnumerable<AddressRecord>> GetAddressesForPersonAsync(string personId, AddressFilters filters)
    {
      var table = _mockDatabase.AddressTable;

      var results = (
        filters.Column switch
        {
          AddressSortableColumn.City => filters.IsAscending
            ? table.OrderBy(x => x.City)
            : table.OrderByDescending(x => x.City),

          AddressSortableColumn.State => filters.IsAscending
            ? table.OrderBy(x => x.State)
            : table.OrderByDescending(x => x.State),

          AddressSortableColumn.PostalCode => filters.IsAscending
          ? table.OrderBy(x => x.PostalCode)
          : table.OrderByDescending(x => x.PostalCode),

          _ => filters.IsAscending
            ? table.OrderBy(x => x.CreationTime)
            : table.OrderByDescending(x => x.CreationTime),
        }).Where(x => x.PersonID == personId)
        .Skip(filters.TakeAmount * (filters.Page - 1))
        .Take(filters.TakeAmount);

      return Task.FromResult(results);
    }

    public Task<IEnumerable<AddressRecord>> GetAddressesForPersonAsync(string personId)
    {
      var table = _mockDatabase.AddressTable;

      var results = table.Where(x => x.PersonID == personId)
        .OrderBy(x => x.IsDefault)
        .AsEnumerable();

      return Task.FromResult(results);
    }
  }
}
