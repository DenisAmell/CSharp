using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4;

public sealed class SimpsonMethod :
    IntegralSolutionMethods
{

    public SimpsonMethod()
    {
        _methodName = "SimpsonMethod";
    }
    protected override double Method(
       Func<double, double> function,
       double leftBorder,
       double rightBorder,
       int n)
    {
        var height = (rightBorder - leftBorder) / n;
        var sum1 = 0d;
        var sum2 = 0d;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        

        for (var k = 1; k <= n; k++)
        {
            var xk = leftBorder + k * height;
            if (k <= n - 1)
            {
                sum1 += function(xk);
            }

            var xk_1 = leftBorder + (k - 1) * height;
            sum2 += function((xk + xk_1) / 2);
        }

        stopWatch.Stop();
        _time = stopWatch.ElapsedTicks;

        var result = height / 3d * (1d / 2d * function(leftBorder) + sum1 + 2 * sum2 + 1d / 2d * function(rightBorder));
        return result;
    }


}
