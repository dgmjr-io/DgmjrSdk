namespace Dgmjr.Sdk.Tasks;

using Microsoft.Build.Framework;

public class EnsureLicenseFileExists : MSBTask
{
    const string LICENSE_MD = "LICENSE.md";
    private string ProjectDirectory => GetDirectoryName(MSBuildProjectFullPath);

    private string LicenseFilePath => Combine(ProjectDirectory, LICENSE_MD);

    protected virtual Stream LicenseFileContent =>
        typeof(EnsureLicenseFileExists).Assembly.GetManifestResourceStream(LICENSE_MD);

    [Required]
    public string MSBuildProjectFullPath { get; set; }

    public override bool Execute()
    {
        if (!File.Exists(LicenseFilePath))
        {
            Log.LogWarning(
                $"License file '{LICENSE_MD}' not found in project directory: {ProjectDirectory}; adding it."
            );
            using var fs = File.Create(LicenseFilePath);
            using var licenseFileStream = LicenseFileContent;
            licenseFileStream.CopyTo(fs);
        }

        return true;
    }
}
