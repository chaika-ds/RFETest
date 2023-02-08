namespace RFETest.Settings;

/// <summary>
///     Configuration section of endpoints
/// </summary>
internal class RfeSettings : IRfeSettings
{
    public RfeSettings(IConfiguration configuration)
    {
        Direction = configuration.GetSection("Direction").Get<string[]>();
    }

    /// <summary>
    ///     Endpoint directions settings
    /// </summary>
    public string[] Direction { get; set; }
}