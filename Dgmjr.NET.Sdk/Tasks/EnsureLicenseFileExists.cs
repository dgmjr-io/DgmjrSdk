namespace Dgmjr.Sdk.Tasks;

using Microsoft.Build.Framework;
using static System.IO.Path;
using static System.IO.File;

public class EnsureLicenseFileExists : MSBTask
{
    const string LICENSE_MD = "LICENSE.md";
    private string ProjectDirectory => GetDirectoryName(MSBuildProjectFullPath);

    private string LicenseFilePath => Combine(ProjectDirectory, LICENSE_MD);

    protected virtual Stream OpenLicenseFileStream() =>
        GetType().Assembly.GetManifestResourceStream(LICENSE_MD);

    protected virtual Stream OpenCreateStream() =>
        Create(LicenseFilePath);

    [Required]
    public string MSBuildProjectFullPath { get; set; }

    public override bool Execute()
    {

        Log.LogWarning(
            $"License file '{LICENSE_MD}' being copied from {GetType().FullName}."
        );
        using var fs = OpenCreateStream();
        using var licenseFileStream = OpenLicenseFileStream();
        licenseFileStream.CopyTo(fs);

        return true;
    }
}
