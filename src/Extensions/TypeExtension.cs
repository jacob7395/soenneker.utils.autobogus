﻿using System;
using System.Dynamic;
using Soenneker.Utils.AutoBogus.Services;

namespace Soenneker.Utils.AutoBogus.Extensions;

public static class TypeExtension
{
    internal static bool IsNullable(this Type type)
    {
        return CacheService.Cache.GetCachedType(type).IsNullable;
        //return Nullable.GetUnderlyingType(type) != null;
    }

    internal static bool IsEnum(this Type type)
    {
        return CacheService.Cache.GetCachedType(type).IsEnum;
        //return type.IsEnum;
    }

    internal static bool IsAbstract(this Type type)
    {
        return CacheService.Cache.GetCachedType(type).IsAbstract;
        //return type.IsAbstract;
    }

    internal static bool IsInterface(this Type type)
    {
        return CacheService.Cache.GetCachedType(type).IsInterface;
        //return type.IsInterface;
    }

    internal static bool IsGenericType(this Type type)
    {
        return CacheService.Cache.GetCachedType(type).IsGenericType;
       // return type.IsGenericType;
    }

    internal static bool IsExpandoObject(this Type type)
    {
        return type == typeof(ExpandoObject);
    }

    internal static bool IsDictionary(this Type type)
    {
        return IsGenericType(type, "IDictionary`2");
    }

    internal static bool IsReadOnlyDictionary(this Type type)
    {
        return IsGenericType(type, "IReadOnlyDictionary`2");
    }

    internal static bool IsCollection(this Type type)
    {
        return IsGenericType(type, "ICollection`1");
    }

    internal static bool IsEnumerable(this Type type)
    {
        return IsGenericType(type, "IEnumerable`1");
    }

    private static bool IsGenericType(Type type, string interfaceTypeName)
    {
        if (type.Name == interfaceTypeName)
            return true;

        Type[] interfaces = CacheService.Cache.GetCachedType(type).GetInterfaces()!;

        foreach (Type i in interfaces)
        {
            if (i.Name == interfaceTypeName)
                return true;
        }

        return false;
    }
}