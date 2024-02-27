namespace Dgmjr.Sdk.Models;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using static String;

using static YamlDotNet.Serialization.DefaultValuesHandling;

public class ReadmeFrontMatter
{
    [YamlMember(Alias = "title", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Title { get; set; } = Empty;
    [YamlMember(Alias = "slug", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Slug { get; set; } = Empty;
    [YamlMember(Alias = "date")]
    public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;
    [YamlMember(Alias = "lastmod")]
    public DateTimeOffset LastModifiedDate { get; set; } = DateTimeOffset.UtcNow;

    [YamlMember(Alias = "version", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Version { get; set; } = Empty;

    [YamlMember(Alias = "description", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Description { get; set; } = Empty;

    [YamlMember(Alias = "packageId", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string PackageId { get; set; } = Empty;

    [YamlMember(Alias = "authors", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string[] Authors { get; set; } = [];

    [YamlMember(Alias = "tags", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string[] Tags { get; set; } = [];

    [YamlMember(Alias = "keywords", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string[] Keywords { get; set; } = [];

    [YamlMember(Alias = "repositoryUrl", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public Uri? Repository { get; set; }

    [YamlMember(Alias = "license", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string LicenseExpression { get; set; } = Empty;

    [YamlMember(Alias = "projectUrl", DefaultValuesHandling = OmitNull | OmitEmptyCollections, SerializeAs = typeof(string))]
    public Uri? ProjectUrl { get; set; }

    [YamlMember(Alias = "summary", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Summary { get; set; } = Empty;

    [YamlMember(Alias = "language", DefaultValuesHandling = OmitNull | OmitEmptyCollections)]
    public string Language { get; set; } = "en-US";
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
    public bool Accepts(Type type) => type == typeof(Uri);

    public object ReadYaml(IParser parser, Type type)
    {
        var value = parser.Consume<Scalar>().Value;
        return Uri.TryCreate(value, UriKind.Absolute, out var uri)
            ? uri
            : null;
    }

    public void WriteYaml(IEmitter emitter, object? value, Type type)
    {
        if (value is Uri uri)
        {
            emitter.Emit(new Scalar(null, null, uri.ToString(), ScalarStyle.Any, true, false));
        }
    }
}
