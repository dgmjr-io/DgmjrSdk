#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JustinWritesCode.Enumerations;
using JustinWritesCode.Enumerations.Abstractions;
using JustinWritesCode.Abstractions;
using Convert = System.Convert;
using TestingJustinWritesCodeSdk;

namespace TestingJwc
{
    /**
    
    */
    [System.CodeDom.Compiler.GeneratedCode("JustinWritesCode.Enumerations.CodeGeneration.V2", "0.0.1.0")]
    public partial record struct AnEnumeration : IEnumeration<AnEnumeration, int>, IComparable<AnEnumeration>, IEquatable<AnEnumeration>, IComparable, IFormattable, IConvertible
    #if NET7_0_OR_GREATER
    , IParsable<AnEnumeration>
    #endif
    {
        public AnEnumeration(AnEnum value, int id, string? name = null, string? description = null)
        {
            Value = value;
            Id = id;
            Name = name ?? value.ToString();
            Description = description;
        }

        object IIdentifiable.Id => Id;
        object IHaveAValue.Value => Value;
        public AnEnum Value { get; private set; }

        public Int32 Id { get; private set; } = default!;
                public String Name { get; private set; } = default!;
                public String Description { get; private set; } = default!;
                public String DisplayName { get; private set; } = default!;
                public String ShortName { get; private set; } = default!;
                public String GroupName { get; private set; } = default!;
                public Int32 Order { get; private set; } = default!;
                public String Uri { get; private set; } = default!;
        
        public override string ToString() => Name;

        public static AnEnumeration FromValue(AnEnum value) => FromValue(value, throwOnNotFound: true);
        public static AnEnumeration FromValue(AnEnum value, bool throwOnNotFound)
        {
            var result = AnEnumeration.All.FirstOrDefault(x => x.Value.Equals(value));
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"The value {value} is not a valid AnEnumeration.");
            }

            return result;
        }

        public static AnEnumeration FromId(int id) => FromId(id, throwOnNotFound: true);
        public static AnEnumeration FromId(int id, bool throwOnNotFound)
        {
            var result = AnEnumeration.All.FirstOrDefault(x => x.Id == id);
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(id), id, $"The id {id} is not a valid AnEnumeration.");
            }

            return result;
        }

        public static AnEnumeration FromName(string name) => FromName(name, throwOnNotFound: true);
        public static AnEnumeration FromName(string name, bool throwOnNotFound)
        {
            var result = AnEnumeration.All.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(name), name, $"The name {name} is not a valid AnEnumeration.");
            }

            return result;
        }

        public static AnEnumeration FromDescription(string description) => FromDescription(description, throwOnNotFound: true);
        public static AnEnumeration FromDescription(string description, bool throwOnNotFound)
        {
            var result = AnEnumeration.All.FirstOrDefault(x => x.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(description), description, $"The description {description} is not a valid AnEnumeration.");
            }

            return result;
        }

        public static AnEnumeration FromShortName(string shortName) => FromDescription(shortName, throwOnNotFound: true);
        public static AnEnumeration FromShortName(string shortName, bool throwOnNotFound)
        {
            var result = AnEnumeration.All.FirstOrDefault(x => x.ShortName.Equals(shortName, StringComparison.OrdinalIgnoreCase));
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(shortName), shortName, $"The ShortName {shortName} is not a valid AnEnumeration.");
            }

            return result;
        }

        public static bool TryFromShortName(string shortName, out AnEnumeration result) => TryFromShortName(shortName, out result, throwOnNotFound: false);
        public static bool TryFromShortName(string shortName, out AnEnumeration result, bool throwOnNotFound)
        {
            result = AnEnumeration.All.FirstOrDefault(x => x.ShortName.Equals(shortName, StringComparison.OrdinalIgnoreCase));
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(shortName), shortName, $"The ShortName {shortName} is not a valid AnEnumeration.");
            }

            return result != default;
        }

        public static bool TryFromValue(AnEnum value, out AnEnumeration result) => TryFromValue(value, out result, throwOnNotFound: false);
        public static bool TryFromValue(AnEnum value, out AnEnumeration result, bool throwOnNotFound)
        {
            result = AnEnumeration.All.FirstOrDefault(x => x.Value.Equals(value));
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"The value {value} is not a valid AnEnumeration.");
            }

            return result != default;
        }

        public static bool TryFromId(int id, out AnEnumeration result) => TryFromId(id, out result, throwOnNotFound: false);
        public static bool TryFromId(int id, out AnEnumeration result, bool throwOnNotFound)
        {
            result = AnEnumeration.All.FirstOrDefault(x => x.Id == id);
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(id), id, $"The id {id} is not a valid AnEnumeration.");
            }

            return result != default;
        }

        public static bool TryFromName(string name, out AnEnumeration result) => TryFromName(name, out result, throwOnNotFound: false);
        public static bool TryFromName(string name, out AnEnumeration result, bool throwOnNotFound)
        {
            result = AnEnumeration.All.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(name), name, $"The name {name} is not a valid AnEnumeration.");
            }

            return result != default;
        }

        public static bool TryFromDescription(string description, out AnEnumeration result) => TryFromDescription(description, out result, throwOnNotFound: false);
        public static bool TryFromDescription(string description, out AnEnumeration result, bool throwOnNotFound)
        {
            result = AnEnumeration.All.FirstOrDefault(x => x.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
            if (result == default && throwOnNotFound)
            {
                throw new ArgumentOutOfRangeException(nameof(description), description, $"The description {description} is not a valid AnEnumeration.");
            }

            return result != default;
        }

        public static IEnumerable<AnEnumeration> GetAll() => AnEnumeration.All;

        public static IEnumerable<AnEnumeration> GetAllExcept(params AnEnumeration[] except) => AnEnumeration.All.Except(except);

        public static IEnumerable<AnEnumeration> GetAllExcept(params AnEnum[] except) => AnEnumeration.All.Except(except.Select(x => AnEnumeration.FromValue(x)));

        public static IEnumerable<AnEnumeration> GetAllExcept(params int[] except) => AnEnumeration.All.Except(except.Select(x => AnEnumeration.FromId(x)));

        public static IEnumerable<AnEnumeration> GetAllExcept(params string[] except) => AnEnumeration.All.Except(except.Select(x => AnEnumeration.FromName(x)));

        #region IConvertible
        public TypeCode GetTypeCode() => TypeCode.Object;
        public bool ToBoolean(IFormatProvider? provider) => this.Value != default;
        public byte ToByte(IFormatProvider? provider) => Convert.ToByte(this.Value);
        public char ToChar(IFormatProvider? provider) => Convert.ToChar(this.Value);
        public DateTime ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(this.Value);
        public decimal ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(this.Value);
        public double ToDouble(IFormatProvider? provider) => Convert.ToDouble(this.Value);
        public short ToInt16(IFormatProvider? provider) => Convert.ToInt16(this.Value);
        public int ToInt32(IFormatProvider? provider) => Convert.ToInt32(this.Value);
        public long ToInt64(IFormatProvider? provider) => Convert.ToInt64(this.Value);
        public sbyte ToSByte(IFormatProvider? provider) => Convert.ToSByte(this.Value);
        public float ToSingle(IFormatProvider? provider) => Convert.ToSingle(this.Value);
        public string ToString(IFormatProvider? provider) => DisplayName;
        public object ToType(type conversionType, IFormatProvider? provider) => Convert.ChangeType(this.Value, conversionType);
        public ushort ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(this.Value);
        public uint ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(this.Value);
        public ulong ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(this.Value);
        #endregion

        public int CompareTo(AnEnumeration other) => Value.CompareTo(other.Value);
        public int CompareTo(object? other) => other is AnEnumeration _AnEnumeration ? CompareTo(_AnEnumeration) : throw new ArgumentOutOfRangeException(nameof(other), other, $"The value provided was not of the correct type (AnEnumeration)");
        public string ToString(string? format, IFormatProvider? formatProvider) => ToString();

        public static readonly AnEnumeration[] All = new[]
        {
            
                        AnEnumeration.EnumValue.Instance,
                        
                        AnEnumeration.EnumValue2.Instance,
                        
                        AnEnumeration.EnumValue3.Instance,
                        
        };

        #region IParsable
        public static AnEnumeration Parse(string s, IFormatProvider? format = null)
            => TryParse(s, out var result) ? result :
                throw new ArgumentOutOfRangeException(nameof(s), s, $"The value {s} is not a valid AnEnumeration.");

        public static bool TryParse(string s, out AnEnumeration result)
            => (result =
                TryFromName(s, out result) ? result :
                TryFromDescription(s, out result) ? result :
                TryFromShortName(s, out result) ? result : default) != default;

        public static bool TryParse(string? s, IFormatProvider? format, out AnEnumeration result)
            => (result =
                TryFromName(s, out result) ? result :
                TryFromDescription(s, out result) ? result :
                TryFromShortName(s, out result) ? result : default) != default;
        #endregion

        public static readonly int Count = AnEnumeration.All.Length;

        public FieldInfo? FieldInfo => typeof(AnEnum).GetRuntimeField(Name);

        public TAttribute? GetCustomAttribute<TAttribute>()
            where TAttribute : Attribute
            => FieldInfo.GetCustomAttribute<TAttribute>();

        public static bool operator <(AnEnumeration left, AnEnumeration right) => left.CompareTo(right) < 0;
        public static bool operator <=(AnEnumeration left, AnEnumeration right) => left.CompareTo(right) <= 0;
        public static bool operator >(AnEnumeration left, AnEnumeration right) => left.CompareTo(right) > 0;
        public static bool operator >=(AnEnumeration left, AnEnumeration right) => left.CompareTo(right) >= 0;
        // public static bool operator ==(AnEnumeration left, AnEnumeration right) => left.Equals(right);
        // public static bool operator !=(AnEnumeration left, AnEnumeration right) => !left.Equals(right);


        
                /// <summary>EnumValue</summary>
        /// <remarks>EnumValue</remarks>
        /// <seealso cref="TestingJustinWritesCodeSdk.AnEnum.EnumValue">AnEnum</seealso>
                [System.CodeDom.Compiler.GeneratedCode("JustinWritesCode.Enumerations.CodeGeneration.V2", "0.0.1.0")]
                public static class EnumValue
                {
                    public static readonly AnEnumeration Instance = new AnEnumeration((AnEnum)(0), 0, "EnumValue")
                    {
                                Id = 0,
                Name = "EnumValue",
                Description = "EnumValue",
                DisplayName = "EnumValue",
                ShortName = "EnumValue",
                GroupName = "AnEnum",
                Order = 0,
                Uri = "urn:TestingJwc:AnEnumeration:EnumValue",
            };
        
                    public const AnEnum Value = (AnEnum)(0);
        
                                public const System.Int32            Id = 0;
            public const System.String            Name = "EnumValue";
            public const System.String            Description = "EnumValue";
            public const System.String            DisplayName = "EnumValue";
            public const System.String            ShortName = "EnumValue";
            public const System.String            GroupName = "AnEnum";
            public const System.Int32            Order = 0;
            public const System.String            Uri = "urn:TestingJwc:AnEnumeration:EnumValue";
        }
                
                /// <summary>EnumValue2</summary>
        /// <remarks>EnumValue2</remarks>
        /// <seealso cref="TestingJustinWritesCodeSdk.AnEnum.EnumValue2">AnEnum</seealso>
                [System.CodeDom.Compiler.GeneratedCode("JustinWritesCode.Enumerations.CodeGeneration.V2", "0.0.1.0")]
                public static class EnumValue2
                {
                    public static readonly AnEnumeration Instance = new AnEnumeration((AnEnum)(1), 1, "EnumValue2")
                    {
                                Id = 1,
                Name = "EnumValue2",
                Description = "EnumValue2",
                DisplayName = "EnumValue2",
                ShortName = "EnumValue2",
                GroupName = "AnEnum",
                Order = 1,
                Uri = "urn:TestingJwc:AnEnumeration:EnumValue2",
            };
        
                    public const AnEnum Value = (AnEnum)(1);
        
                                public const System.Int32            Id = 1;
            public const System.String            Name = "EnumValue2";
            public const System.String            Description = "EnumValue2";
            public const System.String            DisplayName = "EnumValue2";
            public const System.String            ShortName = "EnumValue2";
            public const System.String            GroupName = "AnEnum";
            public const System.Int32            Order = 1;
            public const System.String            Uri = "urn:TestingJwc:AnEnumeration:EnumValue2";
        }
                
                /// <summary>EnumValue3</summary>
        /// <remarks>EnumValue3</remarks>
        /// <seealso cref="TestingJustinWritesCodeSdk.AnEnum.EnumValue3">AnEnum</seealso>
                [System.CodeDom.Compiler.GeneratedCode("JustinWritesCode.Enumerations.CodeGeneration.V2", "0.0.1.0")]
                public static class EnumValue3
                {
                    public static readonly AnEnumeration Instance = new AnEnumeration((AnEnum)(2), 2, "EnumValue3")
                    {
                                Id = 2,
                Name = "EnumValue3",
                Description = "EnumValue3",
                DisplayName = "EnumValue3",
                ShortName = "EnumValue3",
                GroupName = "AnEnum",
                Order = 2,
                Uri = "urn:TestingJwc:AnEnumeration:EnumValue3",
            };
        
                    public const AnEnum Value = (AnEnum)(2);
        
                                public const System.Int32            Id = 2;
            public const System.String            Name = "EnumValue3";
            public const System.String            Description = "EnumValue3";
            public const System.String            DisplayName = "EnumValue3";
            public const System.String            ShortName = "EnumValue3";
            public const System.String            GroupName = "AnEnum";
            public const System.Int32            Order = 2;
            public const System.String            Uri = "urn:TestingJwc:AnEnumeration:EnumValue3";
        }
                
    }
}
