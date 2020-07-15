# DotNetCore.IoC

![Nuget](https://img.shields.io/nuget/dt/DotNetCore.IoC)

## ServiceCollectionExtensions

```cs
public static class Extensions
{
    public static void AddClassesInterfaces(this IServiceCollection services, params Assembly[] assemblies) { }

    public static string GetConnectionString(this IServiceCollection services, string name) { }
}
```
