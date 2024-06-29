namespace Dgmjr.NoTargets.Sdk.Tasks;

using Internal;
using Microsoft.Build.Framework;
using static System.IO.Path;
using static System.IO.File;
using System.IO;
using System.Linq;

/// <summary>
/// Ensures that a package icon exists within the project directory.
/// </summary>
public class EnsurePackageIcon : MSBTask
{
    /// <summary>the "<inheritdoc cref="Icon" path="/value" />" extension</summary>
    /// <value>.svg</value>
    protected const string Icon = "icon";

    /// <summary>the "<inheritdoc cref="_png" path="/value" />" extension</summary>
    /// <value>.svg</value>
    protected const string _png = ".png";

    /// <summary>the "<inheritdoc cref="_jpg" path="/value" />" extension</summary>
    /// <value>.svg</value>
    protected const string _jpg = ".jpg";

    /// <summary>the "<inheritdoc cref="_svg" path="/value" />" extension</summary>
    /// <value>.svg</value>
    protected const string _svg = ".svg";

    private const string DEFAULT_PACKAGE_ICON_PNG = "DEFAULT_PACKAGE_ICON.png";

    /// <summary>
    /// Supported icon extensions
    /// </summary>
    protected static readonly string[] Extensions = { _png, _jpg, _svg };

    /// <summary>
    /// The directory where the project file lives
    /// </summary>
    protected string ProjectDirectory => GetDirectoryName(MSBuildProjectFullPath);

    /// <summary>
    /// Path to the package icon
    /// </summary>
    protected string PackageIconPath => Combine(ProjectDirectory, Icon);

    /// <summary>
    /// Get the package icon path
    /// </summary>
    protected virtual string? GetPackageIconPath() =>
        Extensions.Select(ext => Combine(ProjectDirectory, $"{Icon}{ext}")).FirstOrDefault(Exists);

    /// <summary>
    /// Get the package icon's file name
    /// </summary>
    [Output]
    public string? PackageIcon => GetFileName(GetPackageIconPath());

    /// <summary>
    /// Path to the project file
    /// </summary>
    [Required]
    public string MSBuildProjectFullPath { get; set; }

    /// <summary>
    /// Default package icon extension
    /// </summary>
    protected virtual string DefaultPackageIconExtension => _png;

    /// <summary>
    /// Open a write stream to create the package icon
    /// </summary>
    protected Stream OpenCreateIconStream() =>
        Create(Combine(ProjectDirectory, $"{Icon}{DefaultPackageIconExtension}"));

    /// <summary>
    /// Open a read stream to the default package icon
    /// </summary>
    protected virtual Stream OpenDefaultIconStream() =>
        GetType().Assembly.GetManifestResourceStream(DEFAULT_PACKAGE_ICON_PNG);

    /// <summary>
    /// Execute the task
    /// </summary>
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
