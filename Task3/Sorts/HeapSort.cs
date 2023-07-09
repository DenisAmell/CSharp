using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Sorts;

public sealed  class HeapSort<T> :
    BaseSort<T>
{
    public override T[] Sort(T[] collection, SortingMode sortingMode, Comparison<T> comparison)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        var size = collection.Length;

        for (var i = size / 2 - 1; i>= 0; i--) 
        {
            Heapify(collection, size, i, sortingMode, comparison);
        }

        for (var i = size - 1; i >= 0; i--)
        {
            (collection[0], collection[i]) = (collection[i], collection[0]);
            Heapify(collection, i, 0, sortingMode, comparison );
        }


        return collection;
    }

    private static void Heapify(T[] collection, int size, int root, SortingMode sortingMode, Comparison<T> comparison)
    {
        var maxMin = root;

        var left = 2 * root + 1;
        var right = 2 * root + 2;


        if (left < size && (sortingMode == SortingMode.Ascending ? comparison(collection[left], collection[maxMin]) > 0 : comparison(collection[left], collection[maxMin]) < 0)) {
            maxMin = left;
        }


        if (right < size && (sortingMode == SortingMode.Ascending ? comparison(collection[right], collection[maxMin]) > 0 : comparison(collection[right], collection[maxMin]) < 0))
        {
            maxMin = right;
        }

        if (maxMin != root)
        {
            (collection[root], collection[maxMin]) = (collection[maxMin], collection[root]);
            Heapify(collection, size, maxMin, sortingMode, comparison);
        }

    }
}

