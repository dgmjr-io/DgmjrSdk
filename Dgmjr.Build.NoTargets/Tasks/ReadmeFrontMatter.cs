namespace Dgmjr.NoTargets.Sdk.Models;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using static System.String;
using System;

using static YamlDotNet.Serialization.DefaultValuesHandling;

/// <summary>
/// Represents the frontmatter of a README document.
/// </summary>
public class ReadmeFrontMatter
{
    /// <summary>
    /// the document title.
    /// </summary>
    [YamlMember(Alias = "title", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Title { get; set; } = Empty;

    /// <summary>
    /// the document slug.
    /// </summary>
    [YamlMember(Alias = "slug", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Slug { get; set; } = Empty;

    /// <summary>
    /// the creation date of the document.
    /// </summary>
    [YamlMember(Alias = "date")]
    public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// the last modification date of the document.
    /// </summary>
    [YamlMember(Alias = "lastmod")]
    public DateTimeOffset LastModifiedDate { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// the version information.
    /// </summary>
    [YamlMember(Alias = "version", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Version { get; set; } = Empty;

    /// <summary>
    /// a description of the document.
    /// </summary>
    [YamlMember(Alias = "description", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Description { get; set; } = Empty;

    /// <summary>
    /// the package ID.
    /// </summary>
    [YamlMember(Alias = "packageId", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string PackageId { get; set; } = Empty;

    /// <summary>
    /// the authors of the document.
    /// </summary>
    [YamlMember(Alias = "authors", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string[] Authors { get; set; } = [];

    /// <summary>
    /// the tags associated with the document.
    /// </summary>
    [YamlMember(Alias = "tags", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string[] Tags { get; set; } = [];

    /// <summary>
    /// the keywords associated with the document.
    /// </summary>
    [YamlMember(Alias = "keywords", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string[] Keywords { get; set; } = [];

    /// <summary>
    /// the repository URL.
    /// </summary>
    [YamlMember(Alias = "repositoryUrl", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public Uri? Repository { get; set; }

    /// <summary>
    /// the license expression.
    /// </summary>
    [YamlMember(Alias = "license", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string LicenseExpression { get; set; } = Empty;

    /// <summary>
    /// the project URL.
    /// </summary>
    [YamlMember(Alias = "projectUrl", DefaultValuesHandling = OmitNull | OmitEmptyCollections, SerializeAs = typeof(string))]
    public Uri? ProjectUrl { get; set; }

    /// <summary>
    /// a summary of the document.
    /// </summary>
    [YamlMember(Alias = "summary", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Summary { get; set; } = Empty;

    /// <summary>
    /// the language used for the document.
    /// </summary>
    [YamlMember(Alias = "language", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Language { get; set; } = "en-US";

    ///<summary>the document's type</summary>
    [YamlMember(Alias = "type", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string DocumentType { get; set; } = "readme";

    // [YamlMember(Alias = "additionalValues", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    // public IStringDictionary AdditionalValues { get; set; } = new Dictionary<string, string>();
}

public static class ReadmeFrontMatterExtensions
{
    public static string ToYaml(this ReadmeFrontMatter frontMatter)
    {
        var serializer = new SerializerBuilder()
            .Build();
        return serializer.Serialize(frontMatter);
    }
}

public class UrlYamlConverter : IYamlTypeConverter
{
    /// <inheritdoc />
    public bool Accepts(Type type) => type == typeof(Uri);

    /// <inheritdoc />
    public object? ReadYaml(IParser parser, Type type)
    {
        var value = parser.Consume<Scalar>().Value;
        return Uri.TryCreate(value, UriKind.Absolute, out var uri)
            ? uri
            : null;
    }

    /// <inheritdoc />
    public void WriteYaml(IEmitter emitter, object? value, Type type)
    {
        if (value is Uri uri)
        {
            emitter.Emit(new Scalar(null, null, uri.ToString(), ScalarStyle.Any, true, false));
        }
    }
}
