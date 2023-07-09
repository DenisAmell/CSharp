using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4;

public sealed class RightRectangleMethod :
    IntegralSolutionMethods
{

    public RightRectangleMethod()
    {
        _methodName = "RightRectangleMethod";
    }


    protected override double Method(
       Func<double, double> function,
       double leftBorder,
       double rightBorder,
       int n)
    {
        var height = (rightBorder - leftBorder) / n;
        var sum = (double)0;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        for (var i = 1; i <= n; i++)
        {
            var x = leftBorder + i * height;
            sum += function(x);
        }

        stopWatch.Stop();
        _time = stopWatch.ElapsedTicks;

        var result = height * sum;
        return result;
    }


}
