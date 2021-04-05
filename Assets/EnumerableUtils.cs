using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EnumerableUtils
{
    public static T GetRandomElement<T>(IEnumerable<T> enumerable)
    {
        var enumerableArray = enumerable as T[] ?? enumerable.ToArray();
        return enumerableArray.ElementAt(Random.Range(0, enumerableArray.Count()));
    }

    public static T[] GetRandomElementFromEachArray<T>(params IEnumerable<T>[] arrays)
    {
        return arrays.Select(enumerable =>
        {
            var enumerableArray = enumerable as T[] ?? enumerable.ToArray();
            return enumerableArray.ElementAt(Random.Range(0, enumerableArray.Count()));
        }).ToArray();
    }
}