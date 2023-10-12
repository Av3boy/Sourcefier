// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. 
// https://github.com/microsoft/OpenAPI.NET/blob/649f0b1780c575c4780f4091eedd7a555e8ccc4a/src/Microsoft.OpenApi/Extensions/EnumExtensions.cs

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Microsoft.OpenApi.Extensions
{
    /// <summary>
    /// Enumeration type extension methods.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     Gets an attribute on an enum field value.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to retrieve.</typeparam>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>
        ///     The attribute of the specified type or null.
        /// </returns>
        public static T? GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString())[0];
            var attributes = memInfo.GetCustomAttributes<T>(false);
            return attributes.FirstOrDefault();
        }

        /// <summary>
        ///     Gets the enum display name.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>
        ///     Use <see cref="DisplayAttribute"/> if exists.
        ///     Otherwise, use the standard string representation.
        /// </returns>
        public static string? GetDisplayName(this Enum enumValue)
        {
            var attribute = enumValue.GetAttributeOfType<DisplayAttribute>();
            return attribute == null ? enumValue.ToString() : attribute.Name;
        }
    }
}