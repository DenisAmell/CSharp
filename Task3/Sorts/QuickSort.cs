using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task3.Sorts;

public sealed class QuickSort<T> :
      BaseSort<T>
{
    public override T[] Sort(T[] collection, SortingMode sortingMode, Comparison<T> comparison)
    {
        return QSort(collection, 0, collection.Length - 1, sortingMode, comparison);
    }

    private T[] QSort(T[] collection, int minIndex, int maxIndex, SortingMode sortingMode, Comparison<T> comparison)
    {
        if (minIndex >= maxIndex)
        {
            return collection;
        }

        var pivotIndex = Partition(collection, minIndex, maxIndex, sortingMode, comparison);
        QSort(collection, minIndex, pivotIndex - 1, sortingMode, comparison);
        QSort(collection, pivotIndex + 1, maxIndex, sortingMode, comparison);

        return collection;
    }

    private int Partition(T[] collection, int minIndex, int maxIndex, SortingMode sortingMode, Comparison<T> comparison)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (sortingMode == SortingMode.Ascending 
                ? comparison(collection[i], collection[maxIndex]) < 0
                : comparison(collection[i], collection[maxIndex]) > 0)
            {
                pivot++;
                (collection[pivot], collection[i]) = (collection[i], collection[pivot]);
            }
        }

        pivot++;
        (collection[pivot], collection[maxIndex]) = (collection[maxIndex], collection[pivot]);
        return pivot;
    }
}
