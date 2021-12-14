using AddressBook.Utils.DependencyInjection;

namespace AddressBook.Data.Person
{
  [InjectTransient]
  public class PersonRepository : IReadPersons, ICreatePersons
  {
    private readonly MockDatabase _mockDatabase;

    public PersonRepository(MockDatabase mockDatabase)
    {
      _mockDatabase = mockDatabase ?? throw new ArgumentNullException(nameof(mockDatabase));
    }

    public Task<bool> DoesPersonExistAsync(string personId)
    {
      var table = _mockDatabase.PersonTable;

      return Task.FromResult(table.Exists(x => x.PersonId == personId));
    }

    public Task<PersonRecord?> GetPersonAsync(string personId)
    {
      var table = _mockDatabase.PersonTable;

      return Task.FromResult(table.FirstOrDefault(person => person.PersonId == personId));
    }

    public Task<IEnumerable<PersonRecord>> GetPersonsAsync(PersonFilters filters)
    {
      var table = _mockDatabase.PersonTable;

      var results = (
        filters.Column switch
        {
          PersonSortableColumn.FirstName => filters.IsAscending
            ? table.OrderBy(x => x.FirstName)
            : table.OrderByDescending(x => x.FirstName),

          PersonSortableColumn.LastName => filters.IsAscending
            ? table.OrderBy(x => x.LastName)
            : table.OrderByDescending(x => x.LastName),

          _ => filters.IsAscending
            ? table.OrderBy(x => x.LastName)
            : table.OrderByDescending(x => x.LastName),
        }).Skip(filters.TakeAmount * (filters.Page - 1))
        .Take(filters.TakeAmount);

      return Task.FromResult(results);
    }

    public Task<PersonRecord> InsertPersonAsync(PersonRecord person)
    {
      var table = _mockDatabase.PersonTable;

      person.PersonId = Guid.NewGuid().ToString();
      table.Add(person);
      return Task.FromResult(person);
    }
  }
}
