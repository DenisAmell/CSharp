using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Task2;

public class EqualityComparer<T> :
    IEqualityComparer<T>
{
    private static EqualityComparer<T>? _instance;

    public EqualityComparer()
    {

    }

    public static EqualityComparer<T> Instance => _instance ??= new EqualityComparer<T>();
    public bool Equals(T x, T y) => Equals(x, y);
   

    public int GetHashCode(T obj)
    {
        return obj.GetHashCode();
    }
}
