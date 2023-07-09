using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Sorts;

public sealed class SelectionSort<T> :
    BaseSort<T>
{
    public override T[] Sort(T[] collection, SortingMode sortingMode, Comparison<T> comparison)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        for (int i = 0; i < collection.Length - 1; i++)
        {
            //поиск минимального числа
            int min = i;
            for (int j = i + 1; j < collection.Length; j++)
            {
                if (sortingMode == SortingMode.Ascending
                    ? comparison(collection[j], collection[min]) < 0
                    : comparison(collection[j], collection[min]) > 0)
                {
                    min = j;
                }
            }
            //обмен элементов
             (collection[i], collection[min]) = (collection[min], collection[i]);
        }
        return collection;
    }
}
