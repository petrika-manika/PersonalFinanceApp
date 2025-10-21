namespace PersonalFinanceApp.Application.Common.Settings;

/// <summary>
/// Configuration settings for JWT authentication.
/// Maps to the "JwtSettings" section in appsettings.json.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// The configuration section name in appsettings.json.
    /// </summary>
    public const string SectionName = "JwtSettings";

    /// <summary>
    /// Secret key used for signing JWT tokens.
    /// Should be a strong, random string (minimum 256 bits / 32 characters recommended).
    /// </summary>
    public string Secret { get; set; } = string.Empty;

    /// <summary>
    /// The issuer of the JWT token (typically your application name).
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// The intended audience of the JWT token (typically your application name).
    /// </summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// Token expiration time in minutes.
    /// Default is 60 minutes (1 hour).
    /// </summary>
    public int ExpirationInMinutes { get; set; } = 60;
}
