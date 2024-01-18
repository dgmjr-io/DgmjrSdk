namespace Dgmjr.Sdk.Tasks;

public class EnsurePackageIcon : MSBTask
{
    private const string Icon = "icon";
    private const string _png = ".png";
    private const string _jpg = ".jpg";

    const string DEFAULT_PACKAGE_ICON_PNG = "DEFAULT_PACKAGE_ICON.png";
    private string ProjectDirectory => GetDirectoryName(MSBuildProjectFullPath);

    private string PackageIconPath => Combine(ProjectDirectory, Icon);

    [Required]
    public string MSBuildProjectFullPath { get; set; }

    public override bool Execute()
    {
        if (!Exists(PackageIconPath + _png) && !Exists(PackageIconPath + _jpg))
        {
            Log.LogWarning(
                $"Package icon '{Icon}{_png}/{Icon}{_jpg}' not found in project directory: {ProjectDirectory}; adding it."
            );
            using var fs = Create(PackageIconPath);
            using var manifestStream = typeof(EnsurePackageIcon).Assembly.GetManifestResourceStream(
                DEFAULT_PACKAGE_ICON_PNG
            );
            manifestStream.CopyTo(fs);
        }

        return true;
    }
}
