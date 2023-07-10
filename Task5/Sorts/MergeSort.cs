using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task5;
public sealed class MergeSort<T> :
    BaseSort<T>
{
    public override T[] Sort(T[] collection, SortingMode sortingMode, Comparison<T> comparison)
    {

        if (collection == null) throw new ArgumentNullException(nameof(collection));

        return MSort(collection, 0, collection.Length - 1, sortingMode, comparison);
    }

    private T[] MSort(T[] collection, int lowIndex, int highIndex, SortingMode sortingMode, Comparison<T> comparison)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MSort(collection, lowIndex, middleIndex, sortingMode, comparison);
            MSort(collection, middleIndex + 1, highIndex, sortingMode, comparison);
            Merge(collection, lowIndex, middleIndex, highIndex, sortingMode, comparison);
        }

        return collection;
    }
    private void Merge(T[] collection, int lowIndex, int middleIndex, int highIndex, SortingMode sortingMode, Comparison<T> comparsion)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new T[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (sortingMode == SortingMode.Ascending ?
                comparsion(collection[left], collection[right]) < 0
                : comparsion(collection[left], collection[right]) > 0)
            {
                tempArray[index] = collection[left];
                left++;
            }
            else
            {
                tempArray[index] = collection[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = collection[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = collection[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            collection[lowIndex + i] = tempArray[i];
        }
    }
}

