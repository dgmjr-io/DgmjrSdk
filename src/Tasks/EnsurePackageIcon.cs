using Internal;

namespace Dgmjr.Sdk.Tasks;

public class EnsurePackageIcon : MSBTask
{
    private const string Icon = "icon";
    private const string _png = ".png";
    private const string _jpg = ".jpg";
    private const string _svg = ".svg";
    private static readonly string[] _extensions = { _png, _jpg, _svg };

    const string DEFAULT_PACKAGE_ICON_PNG = "DEFAULT_PACKAGE_ICON.png";
    private string ProjectDirectory => GetDirectoryName(MSBuildProjectFullPath);

    private string PackageIconPath => Combine(ProjectDirectory, Icon);

    protected virtual string? GetPackageIconPath() =>
        _extensions
            .Select(ext => Combine(ProjectDirectory, $"{Icon}{ext}"))
            .FirstOrDefault(File.Exists);

    [Output]
    public string? PackageIcon => GetFileName(GetPackageIconPath());

    [Required]
    public string MSBuildProjectFullPath { get; set; }

    protected virtual string DefaultPackageIconExtension => _png;

    protected Stream OpenCreateIconStream() =>
        Create(Combine(ProjectDirectory, $"{Icon}{DefaultPackageIconExtension}"));

    protected virtual Stream OpenDefaultIconStream() =>
        typeof(EnsurePackageIcon).Assembly.GetManifestResourceStream(DEFAULT_PACKAGE_ICON_PNG);

    public override bool Execute()
    {
        if (PackageIcon is null)
        {
            Log.LogWarning(
                $"Package icon '{Icon}({_png}/{_jpg}/{_svg}' not found in project directory: {ProjectDirectory}; adding it as {Icon}{DefaultPackageIconExtension}."
            );
            using var fs = OpenCreateIconStream();
            using var defaultIconStream = OpenDefaultIconStream();
            defaultIconStream.CopyTo(fs);
            Log.LogMessage(
                $"Added {Icon}{DefaultPackageIconExtension} to project directory: {ProjectDirectory}"
            );
        }

        return true;
    }
}
