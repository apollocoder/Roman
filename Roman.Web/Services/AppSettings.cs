namespace Roman.Web.Services;

public class AppSettings : ISettings
{
    private const string RootSectionName = "App";

    public AppSettings() {}

    public AppSettings(IConfiguration config)
    {
        var rootSection = config.GetSection(RootSectionName);
        
        this.CompanyName = rootSection.GetValue<string?>(nameof(CompanyName)) ?? "Default Company GmbH";
    }

    public string CompanyName { get; } = string.Empty;
}
