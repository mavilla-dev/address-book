namespace AddressBook.Data.Person
{
  public interface ICreatePersons
  {
    Task<PersonRecord> InsertPersonAsync(PersonRecord person);
  }
}