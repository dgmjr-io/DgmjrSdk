using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Dgmjr.Sdk.Models;

public class ReadmeFrontMatter
{
    [YamlMember(Alias = "title", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string Title { get; set; } = string.Empty;
    [YamlMember(Alias = "slug", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string Slug { get; set; } = string.Empty;
    [YamlMember(Alias = "date")]
    public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;
    [YamlMember(Alias = "lastmod")]
    public DateTimeOffset LastModifiedDate { get; set; } = DateTimeOffset.UtcNow;

    [YamlMember(Alias = "version", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string Version { get; set; } = string.Empty;

    [YamlMember(Alias = "description", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string Description { get; set; } = string.Empty;

    [YamlMember(Alias = "packageId", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string PackageId { get; set; } = string.Empty;

    [YamlMember(Alias = "authors", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string[] Authors { get; set; } = [];

    [YamlMember(Alias = "tags", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string[] Tags { get; set; } = [];

    [YamlMember(Alias = "keywords", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string[] Keywords { get; set; } = [];

    [YamlMember(Alias = "repositoryUrl", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public Uri? Repository { get; set; }

    [YamlMember(Alias = "license", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string LicenseExpression { get; set; } = string.Empty;

    [YamlMember(Alias = "projectUrl", DefaultValuesHandling = DefaultValuesHandling.OmitNull, SerializeAs = typeof(string))]
    public Uri? ProjectUrl { get; set; }

    [YamlMember(Alias = "summary", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string Summary { get; set; } = string.Empty;

    [YamlMember(Alias = "language", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string Language { get; set; } = "en-US";
    [YamlMember(Alias = "type", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
    public string DocumentType { get; set; } = "readme";

    // [YamlMember(Alias = "additionalValues", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
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
