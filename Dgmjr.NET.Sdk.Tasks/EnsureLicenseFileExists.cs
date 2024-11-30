using Microsoft.Build.Framework;

namespace Dgmjr.Sdk.Tasks
{
    ///<summary>Task to ensure that a license file exists within the project directory.</summary>
    public class EnsureLicenseFileExists : MSBTask
    {
        ///<summary>The name of the license file (LICENSE.md).</summary>
        private const string LICENSE_MD = "LICENSE.md";

        ///<summary>The project directory where the task is executed.</summary>
        private string ProjectDirectory => GetDirectoryName(MSBuildProjectFullPath);

        ///<summary>The full path to the license file within the project directory.</summary>
        private string LicenseFilePath => Combine(ProjectDirectory, LICENSE_MD);

        ///<summary>Opens a stream to read the license file from the assembly resources.</summary>
        protected virtual Stream OpenLicenseFileStream() =>
            GetType().Assembly.GetManifestResourceStream(LICENSE_MD);

        ///<summary>Opens a stream to create the license file within the project directory.</summary>
        protected virtual Stream OpenCreateStream() =>
            Create(LicenseFilePath);

        ///<summary>The full path to the MSBuild project file.</summary>
        [Required]
        public string MSBuildProjectFullPath { get; set; }

        ///<summary>Executes the task to ensure the existence of the license file.</summary>
        /// <returns>True if the task is executed successfully.</returns>
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
}
