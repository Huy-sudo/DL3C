namespace DL3C_API.Infrastructure.Utility.ErrorHandling.Object;

/// <summary>
/// exception message class.
/// </summary>
public class ErrorMessage
{
    /// <summary>
    /// Gets custom error message.
    /// </summary>
    public string Message { get; init; } = null!;

    /// <summary>
    /// Gets things meet error.
    /// </summary>
    public object Target { get; init; } = null!;
}