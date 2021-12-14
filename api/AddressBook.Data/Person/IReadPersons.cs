namespace AddressBook.Data.Person
{
  public interface IReadPersons
  {
    Task<IEnumerable<PersonRecord>> GetPersonsAsync(PersonFilters filters);
    Task<bool> DoesPersonExistAsync(string personId);
    Task<PersonRecord?> GetPersonAsync(string personId);
  }
}