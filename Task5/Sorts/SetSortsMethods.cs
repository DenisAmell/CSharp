namespace Task5;


public static class SetSortsMethods
{
    public static T[] Sort<T>(
       this T[] collection,
       BaseSort<T>.SortingMode mode,
       BaseSort<T>.SortingAlgorithm sortAlgorithm) where T : IComparable<T>
    {
        int Comparison(T x, T y) => x.CompareTo(y);

        BaseSort<T>? algorithm = sortAlgorithm switch
        {
            BaseSort<T>.SortingAlgorithm.InsertionSort => new InsertionSort<T>(),
            BaseSort<T>.SortingAlgorithm.SelectionSort => new SelectionSort<T>(),
            BaseSort<T>.SortingAlgorithm.QuickSort => new QuickSort<T>(),
            BaseSort<T>.SortingAlgorithm.HeapSort => new HeapSort<T>(),
            BaseSort<T>.SortingAlgorithm.MergeSort => new MergeSort<T>(),
            _ => throw new ArgumentException("Chosen invalid sorting algorithm", nameof(sortAlgorithm))
        };


        return algorithm!.Sort(collection, mode, Comparison);
    }

   
    public static T[] Sort<T>(
        this T[] cpllection, BaseSort<T>.SortingMode mode, 
        BaseSort<T>.SortingAlgorithm sortAlgorithm, Comparison<T> comparison)
    {
        BaseSort<T>? algorithm = sortAlgorithm switch
        {
            BaseSort<T>.SortingAlgorithm.InsertionSort => new InsertionSort<T>(),
            BaseSort<T>.SortingAlgorithm.SelectionSort => new SelectionSort<T>(),
            BaseSort<T>.SortingAlgorithm.QuickSort => new QuickSort<T>(),
            BaseSort<T>.SortingAlgorithm.HeapSort => new HeapSort<T>(),
            BaseSort<T>.SortingAlgorithm.MergeSort => new MergeSort<T>(),
            _ => throw new ArgumentException("Chosen invalid sorting algorithm", nameof(sortAlgorithm))
        };
        return algorithm.Sort(cpllection, mode, comparison);
    }

    public static T[] Sort<T>(
         this T[] collection,
         BaseSort<T>.SortingMode mode,
         BaseSort<T>.SortingAlgorithm sortAlgorithm,
         Comparer<T> comparer)
    {
        BaseSort<T>? algorithm = sortAlgorithm switch
        {
            BaseSort<T>.SortingAlgorithm.InsertionSort => new InsertionSort<T>(),
            BaseSort<T>.SortingAlgorithm.SelectionSort => new SelectionSort<T>(),
            BaseSort<T>.SortingAlgorithm.QuickSort => new QuickSort<T>(),
            BaseSort<T>.SortingAlgorithm.HeapSort => new HeapSort<T>(),
            BaseSort<T>.SortingAlgorithm.MergeSort => new MergeSort<T>(),
            _ => throw new ArgumentException("Chosen invalid sorting algorithm", nameof(sortAlgorithm))
        };
        return algorithm.Sort(collection, mode, comparer.Compare);
    }

    public static T[] Sort<T>(
         this T[] collection,
         BaseSort<T>.SortingMode mode,
         BaseSort<T>.SortingAlgorithm sortAlgorithm,
         IComparer<T> comparer)
    {

        BaseSort<T>? algorithm = sortAlgorithm switch
        {
            BaseSort<T>.SortingAlgorithm.InsertionSort => new InsertionSort<T>(),
            BaseSort<T>.SortingAlgorithm.SelectionSort => new SelectionSort<T>(),
            BaseSort<T>.SortingAlgorithm.QuickSort => new QuickSort<T>(),
            BaseSort<T>.SortingAlgorithm.HeapSort => new HeapSort<T>(),
            BaseSort<T>.SortingAlgorithm.MergeSort => new MergeSort<T>(),
            _ => throw new ArgumentException("Chosen invalid sorting algorithm", nameof(sortAlgorithm))
        };

        return algorithm.Sort(collection, mode, comparer.Compare);
    }
}