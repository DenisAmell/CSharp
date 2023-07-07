using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Task2;

public class EqualityComparer :
    IEqualityComparer<int>
{
    private static EqualityComparer? _instance;

    public EqualityComparer()
    {

    }

    public static EqualityComparer Instance => _instance ??= new EqualityComparer();
    public bool Equals(int x, int y) => x == y;
   

    public int GetHashCode(int obj)
    {
        return obj.GetHashCode();
    }
}
