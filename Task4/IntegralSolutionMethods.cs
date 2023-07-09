
namespace Task4;

public class IntegralSolutionMethods :
    InterfeceIntegralsion
{
    protected string? _methodName;
    public string MethodName => _methodName;

    protected int _iterationsCount;
    protected long _time;


    public double IntegralCulc(Func<double, double> function, double leftBorder, double rightBorder, double accuracy)
    {
        if (function == null) throw new ArgumentNullException(nameof(function));

        var n = 1;
        var result = Method(function, leftBorder, rightBorder, n);
        var previousResult = 0d;

        do
        {
            previousResult = result;
            n += 1;
            result = Method(function, leftBorder, rightBorder, n);

        } while (Math.Abs(result - previousResult).CompareTo(accuracy) > 0);

        _iterationsCount = n;

        return result;
    }
    protected virtual double Method(
      Func<double, double> function,
      double leftBorder,
      double rightBorder,
      int n)
    {
        throw new NotImplementedException();
    }

    public int IterationsCount => _iterationsCount;

    public long Time => _time;
}