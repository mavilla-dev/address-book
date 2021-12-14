using AddressBook.Utils.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Data
{
  public static class DataInjection
  {
    public static void InjectData(this IServiceCollection collection)
    {
      InjectionUtils.AddAssembly(collection, typeof(DataInjection).Assembly);
    }
  }
}
