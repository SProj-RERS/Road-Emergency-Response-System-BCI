/// <summary>
/// Contain configuration of a specific App.
/// </summary>
static class AppConfig
{
    public static string AppUrl              = "wss://localhost:6868";
    public static string AppName             = "useless";
    
    /// <summary>
    /// Name of directory where contain tmp data and logs file.
    /// </summary>
    public static string TmpAppDataDir       = "Emotiv-Unity-Plugin";
    public static string ClientId            = "Keqs8rKJEnay49TQhhkhb37ORhdWHQEfudzDi2oq";
    public static string ClientSecret        = "rvgcQwI4rZNtcCOzXXJds4nvlJtGhNqCF5NofNLvJvEEFPtM0SDSWekEQZv6y5FTX78frHXQOvZAMNfc3RmPYtBE5h3vjNr7CdCs7xUSuY63f6iQY4YKItVOrUXkD3uc";
    public static string AppVersion          = "1.0.1 Dev";
    
    /// <summary>
    /// License Id is used for App
    /// In most cases, you don't need to specify the license id. Cortex will find the appropriate license based on the client id
    /// </summary>
    public static string AppLicenseId        = "";
}