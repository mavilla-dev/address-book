using AddressBook.Utils.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Domain
{
  public static class DomainInjection
  {
    public static void InjectDomain(this IServiceCollection collection)
    {
      InjectionUtils.AddAssembly(collection, typeof(DomainInjection).Assembly);
    }
  }
}
