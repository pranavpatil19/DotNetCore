# DotNetCore.Validation

![Nuget](https://img.shields.io/nuget/dt/DotNetCore.Validation)

## Validator

```cs
public abstract class Validator<T> : AbstractValidator<T>
{
    public new async Task<IResult> ValidateAsync(T instance, CancellationToken cancellation = default) { }
}
```
