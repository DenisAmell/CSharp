using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Task5;

public class EqualityComparer :
    IEqualityComparer<int>
{
    private static EqualityComparer? _instance;

    private EqualityComparer()
    {

    }

    public static EqualityComparer Instance => _instance ??= new EqualityComparer();
    public bool Equals(int x, int y) => x == y;
   

    public int GetHashCode(int obj)
    {
        return obj.GetHashCode();
    }
}
