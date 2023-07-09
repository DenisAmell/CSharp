namespace Task3;
using Task3.Sorts;

public static class SetSortsMethods
{
    public static T[] Sort<T>(
       this T[] collection,
       BaseSort<T>.SortingMode mode,
       BaseSort<T> sortAlgorithm) where T : IComparable<T>
    {
        int Comparison(T x, T y) => x.CompareTo(y);

        return sortAlgorithm.Sort(collection, mode, Comparison);
    }

   
    public static T[] Sort<T>(
        this T[] cpllection, BaseSort<T>.SortingMode mode, 
        BaseSort<T> sortAlgorithm, Comparison<T> comparison)
    {
        return sortAlgorithm.Sort(cpllection, mode, comparison);
    }

    public static T[] Sort<T>(
         this T[] collection,
         BaseSort<T>.SortingMode mode,
         BaseSort<T> sortAlgorithm,
         Comparer<T> comparer)
    {
        return sortAlgorithm.Sort(collection, mode, comparer.Compare);
    }

    public static T[] Sort<T>(
         this T[] collection,
         BaseSort<T>.SortingMode mode,
         BaseSort<T> sortAlgorithm,
         IComparer<T> comparer)
    {
        return sortAlgorithm.Sort(collection, mode, comparer.Compare);
    }
}