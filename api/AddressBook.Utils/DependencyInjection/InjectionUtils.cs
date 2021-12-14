using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AddressBook.Utils.DependencyInjection
{
  public static class InjectionUtils
  {
    public static void AddAssembly(IServiceCollection collection, Assembly assembly)
    {
      var assemblyTypes = assembly.ExportedTypes
       .Where(x => x.IsClass && !x.IsAbstract);

      var transients = assemblyTypes.Where(x => x.GetCustomAttributes(typeof(InjectTransientAttribute), false).Any());
      var singletons = assemblyTypes.Where(x => x.GetCustomAttributes(typeof(InjectSingletonAttribute), false).Any());

      InjectTransients(collection, transients);
      InjectSingletons(collection, singletons);
    }

    private static void InjectTransients(IServiceCollection collection, IEnumerable<Type> transients)
    {
      foreach (var type in transients)
      {
        collection.AddTransient(type, type);

        var interfaces = type.GetInterfaces().ToList();
        interfaces.ForEach(iface => collection.AddTransient(iface, type));
      }
    }

    private static void InjectSingletons(IServiceCollection collection, IEnumerable<Type> singletons)
    {
      foreach (var type in singletons)
      {
        collection.AddSingleton(type, type);

        var interfaces = type.GetInterfaces().ToList();
        interfaces.ForEach(iface => collection.AddSingleton(iface, type));
      }
    }
  }
}
