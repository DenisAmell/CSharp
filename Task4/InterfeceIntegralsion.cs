using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4;
public interface InterfeceIntegralsion
{
    double IntegralCulc(
       Func<double, double> function,
       double leftBorder,
       double rightBorder,
       double accuracy);

    string MethodName
    {
        get;
    }
}
