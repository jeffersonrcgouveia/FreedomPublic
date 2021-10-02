using System.Collections.Generic;
using UnityEngine;

namespace Freedom.Commons.Extensions
{
    public static class IReadOnlyListExtensions
    {
        public static T RandomValue<T>(this IReadOnlyList<T> list) => list[Random.Range(0, list.Count)];
    }
}
