using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Sorts;
public sealed class InsertionSort<T> :
    BaseSort<T>
{
    public override T[] Sort(T[] collection, SortingMode sortingMode, Comparison<T> comparison)
    {

        if (collection == null) throw new ArgumentNullException(nameof(collection));

        var size = collection.Length;

        for (var i = 1; i < size; i++)
        {
            var k = collection[i];
            var j = i;

            while (j > 0 && (sortingMode == SortingMode.Ascending 
                ? comparison(k, collection[j - 1]) < 0
                : comparison(k, collection[j - 1]) > 0))
            {
                collection[j] = collection[j - 1];
                j--;
            }
            collection[j] = k;
        }

        return collection;
    }
}


