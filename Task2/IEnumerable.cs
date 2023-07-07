using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2;

public static class EnumerableMethod
{ 
    public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> list, int length,
        IEqualityComparer<T> comparer)
     {
        if (list.Distinct(comparer).Count() != list.Count())
            throw new ArgumentException("Values are repeated", nameof(list));

        if (length == 1) return list.Select(t => new T[] { t });

        return GetCombinations(list, length - 1, comparer)
             .SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
     }

    public static IEnumerable<IEnumerable<T>> GenSubset<T>(this IEnumerable<T> list, IEqualityComparer<T> comparer)
    {
        if (list.Distinct(comparer).Count() != list.Count())
            throw new ArgumentException("Values are repeated", nameof(list));

        var enumerable = list as T[] ?? list.ToArray();

        for (var i = 0; i < (1 << enumerable.Length); i++)
        {
            var result = Array.Empty<T>();

            var mask = i;

            foreach (var element in enumerable)
            {
                if ((mask & 1) == 1)
                {
                    result = result.Concat(new[] { element }).ToArray();
                }

                mask >>= 1;
            }

            yield return result;
        }
    }

    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list, IEqualityComparer<T> comparer)
    {
        //  comparer = comparer ?? EqualityComparer<T>.Default;
        if (list.Distinct(comparer).Count() != list.Count())
            throw new ArgumentException("Values are repeated", nameof(list));


        if (!list.Any())
        {
            yield return Enumerable.Empty<T>();
            yield break;
        }

        var index = 0;
        foreach (var item in list)
        {
            var remaining = list.Take(index).Concat(list.Skip(index + 1));
            foreach (var permutation in remaining.GetPermutations(comparer))
            {
                yield return new[] { item }.Concat(permutation);
            }

            index++;
        }
    }

}