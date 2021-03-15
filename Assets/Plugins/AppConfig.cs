/// <summary>
/// Contain configuration of a specific App.
/// </summary>
static class AppConfig
{
    public static string AppUrl              = "wss://localhost:6868";
    public static string AppName             = "UnityApp";
    
    /// <summary>
    /// Name of directory where contain tmp data and logs file.
    /// </summary>
    public static string TmpAppDataDir       = "UnityApp";
    public static string ClientId            = "N0pIWXCctoL1XEZIe3Cu16VgvzI18FfccdrxMii7";
    public static string ClientSecret        = "vQzGf0hCxGWj7IAaTNXrLECfcQhnpEUdnBEJ38wUolBdxFZG42nrZa9ONha9oqPwbFU9xzaaFFMLZBT5Q1EEhDHY4MgzSNGJgGy9fFmjEbLSNk13R8XyUEs2gljkz1do";
    public static string AppVersion          = "1.0.1 Dev";
    
    /// <summary>
    /// License Id is used for App
    /// In most cases, you don't need to specify the license id. Cortex will find the appropriate license based on the client id
    /// </summary>
    public static string AppLicenseId        = "";
}