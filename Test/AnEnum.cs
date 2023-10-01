/*
 * AnEnum.cs
 *
 *   Created: 2023-03-28-02:15:28
 *   Modified: 2023-03-28-03:18:18
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace TestingDgmjrSdk;

using System.ComponentModel.DataAnnotations;

[GenerateEnumerationRecordStruct("AnEnumeration", "TestingDgmjrSdk")]
public enum AnEnum
{
    /// <summary>This is a summary of the enum value.</summary>
    /// <value>The enum value's value.</value>
    /// <example>Foo!</example>
    /// <default>Bar!</default>
    EnumValue,

    /// <summary>This is a summary of the enum value.</summary>
    /// <value>The enum value's value.</value>
    /// <example>Foo!</example>
    /// <default>Bar!</default>
    EnumValue2,

    /// <summary>This is a summary of the enum value.</summary>
    /// <value>The enum value's value.</value>
    /// <example>Foo!</example>
    /// <default>Bar!</default>
    [Display(Name = "Enumeration Value 3")]
    EnumValue3
}
