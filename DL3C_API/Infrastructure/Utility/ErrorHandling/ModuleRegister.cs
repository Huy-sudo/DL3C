namespace DL3C_API.Infrastructure.Utility.ErrorHandling;

/// <summary>
/// Inject services to service container for Error module.
/// </summary>
public static class ModuleRegister
{
    /// <summary>
    /// DI Service classes for error handling.
    /// </summary>
    /// <param name="services">Service container from Program.</param>
    public static void RegisterErrorHandling(this IServiceCollection services)
    {
        services.AddTransient<IErrorHandler, ErrorHandler>();
    }
}