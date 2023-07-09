using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4;

public sealed class TrapezeMethod :
    IntegralSolutionMethods
{

    public TrapezeMethod()
    {
        _methodName = "TrapezeMethod";
    }

    protected override double Method(
       Func<double, double> function,
       double leftBorder,
       double rightBorder,
       int n)
    {
        var height = (rightBorder - leftBorder) / n;
        var sum = (function(leftBorder) + function(rightBorder)) / 2d;


        var stopWatch = new Stopwatch();
        stopWatch.Start();
        

        for (var i = 1; i < n; i++)
        {
            var x = leftBorder + i * height;
            sum += function(x);
        }

         

        var result = height * sum;
        return result;
    }
    
}
