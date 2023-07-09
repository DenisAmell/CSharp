using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4;

public sealed class MiddleRectangleMethod :
    IntegralSolutionMethods
{

    public MiddleRectangleMethod()
    {
        _methodName = "MiddleRectangleMethod";
    }

    protected override double Method(
       Func<double, double> function,
       double leftBorder,
       double rightBorder,
       int n)
    {
        var height = (rightBorder - leftBorder) / n;
        var sum = (function(leftBorder) + function(rightBorder)) / 2;

        var stopWatch = new Stopwatch();
        stopWatch.Start();

        for ( var i = 1; i < n; i++)
        {
            var x = leftBorder + height * i;
            sum += function(x);
        }

        stopWatch.Stop();
        _time = stopWatch.ElapsedTicks;
        var result = height * sum;
        return result;
    }


}
