#if !GENERATED_ENUMERATION_TYPE_ATTRIBUTES
#define GENERATED_ENUMERATION_TYPE_ATTRIBUTES

using System.CodeDom.Compiler;

#nullable enable
[CompilerGenerated, System.CodeDom.Compiler.GeneratedCode("JustinWritesCode.Enumerations.CodeGeneration.V2", "0.0.1.0"), AttributeUsage(AttributeTargets.Enum)]
internal abstract class GenerateEnumerationTypeAttribute : Attribute
{
    public GenerateEnumerationTypeAttribute(string? EnumerationTypeName = null, string? Namespace =  null)
    {
    }
}

[CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
internal abstract class GenerateEnumerationRecordTypeAttribute : GenerateEnumerationTypeAttribute
{
    public GenerateEnumerationRecordTypeAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
    {
    }
}

[CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
internal sealed class GenerateEnumerationRecordClassAttribute : GenerateEnumerationRecordTypeAttribute
{
    public GenerateEnumerationRecordClassAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
    {
    }
}

[CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
internal sealed class GenerateEnumerationRecordStructAttribute : GenerateEnumerationRecordTypeAttribute
{
    public GenerateEnumerationRecordStructAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
    {
    }
}

[CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
internal sealed class GenerateEnumerationClassAttribute : GenerateEnumerationTypeAttribute
{
    public GenerateEnumerationClassAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
    {
    }
}

[CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
internal sealed class GenerateEnumerationStructAttribute : GenerateEnumerationTypeAttribute
{
    public GenerateEnumerationStructAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
    {
    }
}

#endif