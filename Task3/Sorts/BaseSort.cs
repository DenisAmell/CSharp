using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Sorts;

public abstract class BaseSort<T>
{
    public enum SortingMode
    {
        Ascending,
        Descending
    }

    public abstract T[] Sort(T[] collection,  SortingMode sortingMode, Comparison<T> comparison);
}
