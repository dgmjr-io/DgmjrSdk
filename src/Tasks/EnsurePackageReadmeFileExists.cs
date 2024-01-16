namespace Dgmjr.Sdk.Tasks;

public class EnsurePackageReadmeFileExists : MSBTask
{
    private static readonly Assembly Assembly = typeof(EnsurePackageReadmeFileExists).Assembly;

    private const string FrontmatterRegexString = @"---\s*[\r\n]+(?<frontmatter>[\s\S]+?)[\r\n]+---";
    private static readonly Regex FrontmatterRegex = new Regex(FrontmatterRegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

    private const string README_MD = "README.md";
    private string PackageReadmePath => Combine(GetDirectoryName(MSBuildProjectFullPath)!, "README.md");
    private const string README_TEMPLATE = "README_TEMPLATE.md";
    private const string FrontMatterTemplate = "frontmatter_template.yml";
    private bool ReadmeExists => Exists(PackageReadmePath);

    private ProjectInstance _projectInstance;
    private ProjectInstance ProjectInstance => _projectInstance ??= new ProjectInstance(MSBuildProjectFullPath);

    [Required]
    public string MSBuildProjectFullPath { get; set; }

    public override bool Execute()
    {
        if (!Exists(PackageReadmePath))
        {
            // Log.LogMessage($"Creating {README_MD}...");
            // WriteAllText(PackageReadmePath, GetReadmeContent());
        }
        else
        {
            // Log.LogMessage($"Updating {README_MD}...");
            // WriteAllText(PackageReadmePath, GetReadmeContent());
        }
        return true;
    }

    private string GetReadmeContent()
    {
        var readmeMarkdown = ReadmeExists ? ReadAllText(PackageReadmePath) : new StreamReader(Assembly.GetManifestResourceStream(README_TEMPLATE)).ReadToEnd();
        return readmeMarkdown;
        // var frontmatterYaml = GetFrontMatter(readmeMarkdown);
        // if (string.IsNullOrWhiteSpace(frontmatterYaml))
        // {
        //     frontmatterYaml = new StreamReader(Assembly.GetManifestResourceStream(FrontMatterTemplate)).ReadToEnd();
        // }
        // var frontMatter = new YamlDotNet.Serialization.DeserializerBuilder().Build()
        //     .Deserialize<ReadmeFrontMatter>(frontmatterYaml);

        // frontMatter.Title = ProjectInstance.GetPropertyValue("Title");
        // frontMatter.Authors = ProjectInstance.GetPropertyValue("Authors").Split(';');
        // frontMatter.Description = ProjectInstance.GetPropertyValue("Description");
        // frontMatter.Version = ProjectInstance.GetPropertyValue("PackageVersion");
        // frontMatter.PackageId = ProjectInstance.GetPropertyValue("PackageId");
        // frontMatter.LastModifiedDate = DateTimeOffset.UtcNow;
        // frontMatter.Keywords = ProjectInstance.GetPropertyValue("PackageTags").Split(';');
        // frontMatter.LicenseExpression = ProjectInstance.GetPropertyValue("PackageLicenseExpression") ?? "MIT";
        // frontMatter.Repository = Uri.TryCreate(ProjectInstance.GetPropertyValue("RepositoryUrl"), UriKind.Absolute, out var repositoryUri) ? repositoryUri : null;
        // frontMatter.ProjectUrl = Uri.TryCreate(ProjectInstance.GetPropertyValue("PackageProjectUrl"), UriKind.Absolute, out var projectUri) ? projectUri : null;
        // frontMatter.Summary = ProjectInstance.GetPropertyValue("PackageSummary") ?? frontMatter.Description;

        // var newFrontmatterYaml = new YamlDotNet.Serialization.SerializerBuilder().Build().Serialize(frontMatter);

        // return readmeMarkdown.Replace(frontmatterYaml, newFrontmatterYaml);
    }

    private string GetFrontMatter(string readmeMarkdown)
    {
        return FrontmatterRegex.Match(readmeMarkdown).Groups["frontmatter"].Value;
    }
}
