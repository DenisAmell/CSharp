using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5;
public abstract class BaseSort<T>
{
    public enum SortingMode
    {
        Ascending,
        Descending
    }


    public enum SortingAlgorithm
    {
        InsertionSort,
        SelectionSort,
        QuickSort,
        HeapSort,
        MergeSort
    }
    public abstract T[] Sort(T[] collection,  SortingMode sortingMode, Comparison<T> comparison);
}
