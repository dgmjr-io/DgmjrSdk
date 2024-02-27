namespace Dgmjr.Sdk.Tasks;
using Internal;

public class EnsurePackageIcon : MSBTask
{
    protected const string Icon = "icon";
    protected const string _png = ".png";
    protected const string _jpg = ".jpg";
    protected const string _svg = ".svg";
    protected static readonly string[] _extensions = { _png, _jpg, _svg };

    const string DEFAULT_PACKAGE_ICON_PNG = "DEFAULT_PACKAGE_ICON.png";
    protected string ProjectDirectory => GetDirectoryName(MSBuildProjectFullPath);

    protected string PackageIconPath => Combine(ProjectDirectory, Icon);

    protected virtual string? GetPackageIconPath() =>
        _extensions
            .Select(ext => Combine(ProjectDirectory, $"{Icon}{ext}"))
            .FirstOrDefault(Exists);

    [Output]
    public string? PackageIcon => GetFileName(GetPackageIconPath());

    [Required]
    public string MSBuildProjectFullPath { get; set; }

    protected virtual string DefaultPackageIconExtension => _png;

    protected Stream OpenCreateIconStream() =>
        Create(Combine(ProjectDirectory, $"{Icon}{DefaultPackageIconExtension}"));

    protected virtual Stream OpenDefaultIconStream() =>
        GetType().Assembly.GetManifestResourceStream(DEFAULT_PACKAGE_ICON_PNG);

    public override bool Execute()
    {
        if (PackageIcon is null)
        {
            Log.LogWarning(
                $"Package icon '{Icon}({_png}/{_jpg}/{_svg}' not found in project directory: {ProjectDirectory}; adding it as {Icon}{DefaultPackageIconExtension} from {GetType().Assembly.FullName}."
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
