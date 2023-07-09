using System;

namespace Task4.Launcher.App
{
    class Programm
    {
        static void Main(string[] args)
        { 
            double Function(double x) => 1 / (x + 1);

            const double accuracy = 0.0000001;

            var iterationsCount = new Dictionary<string, int>();
            var leadTime = new Dictionary<string, long>();

            IntegralSolutionMethods leftRectangleMethod = new LeftRectangleMethod();
            IntegralSolutionMethods rightRectangleMethod = new RightRectangleMethod();
            IntegralSolutionMethods middleRectangleMethod = new MiddleRectangleMethod();
            IntegralSolutionMethods trapezeMethod = new TrapezeMethod();
            IntegralSolutionMethods simpsonMethod = new SimpsonMethod();
            

            try
            {
               Console.WriteLine(
               $"{leftRectangleMethod.MethodName}: {leftRectangleMethod.IntegralCulc(Function, 3, 12, accuracy)} ");
                iterationsCount.Add(leftRectangleMethod.MethodName, leftRectangleMethod.IterationsCount);
                leadTime.Add(leftRectangleMethod.MethodName, leftRectangleMethod.Time);

                Console.WriteLine(
               $"{rightRectangleMethod.MethodName}: {rightRectangleMethod.IntegralCulc(Function, 3, 12, accuracy)} ");
                iterationsCount.Add(rightRectangleMethod.MethodName, rightRectangleMethod.IterationsCount);
                leadTime.Add(rightRectangleMethod.MethodName, rightRectangleMethod.Time);

                Console.WriteLine(
               $"{middleRectangleMethod.MethodName}: {middleRectangleMethod.IntegralCulc(Function, 3, 12, accuracy)} ");
                iterationsCount.Add(middleRectangleMethod.MethodName, middleRectangleMethod.IterationsCount);
                leadTime.Add(middleRectangleMethod.MethodName, middleRectangleMethod.Time);

                Console.WriteLine(
                $"{trapezeMethod.MethodName}: {trapezeMethod.IntegralCulc(Function, 3, 12, accuracy)} ");
                iterationsCount.Add(trapezeMethod.MethodName, trapezeMethod.IterationsCount);
                leadTime.Add(trapezeMethod.MethodName, trapezeMethod.Time);

                Console.WriteLine($"{simpsonMethod.MethodName}: {simpsonMethod.IntegralCulc(Function, 3, 12, accuracy)} ");
                iterationsCount.Add(simpsonMethod.MethodName, simpsonMethod.IterationsCount);
                leadTime.Add(simpsonMethod.MethodName, simpsonMethod.Time);

                var sortedIterationCount = from element in iterationsCount orderby element.Value ascending select element;
                var sortedLeadTime = from element in leadTime orderby element.Value ascending select element;

                Console.WriteLine($"{Environment.NewLine}Number of method iterations");
                var index = 1;
                foreach (var item in sortedIterationCount)
                {
                    Console.WriteLine($"{index++}) {item.Key}: {item.Value}");
                }

                Console.WriteLine($"{Environment.NewLine}Elapsed time of methods (in ticks)");
                index = 1;
                foreach (var item in sortedLeadTime)
                {
                    Console.WriteLine($"{index++}) {item.Key}: {item.Value}");
                }

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}