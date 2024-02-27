namespace Dgmjr.Sdk.Tasks;

using Microsoft.Build.Framework;

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

        Log.LogMessage(
            $"License file '{LICENSE_MD}' being copied from {GetType().FullName}."
        );
        using var fs = OpenCreateStream();
        using var licenseFileStream = OpenLicenseFileStream();
        licenseFileStream.CopyTo(fs);

        return true;
    }
}
