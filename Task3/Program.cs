using Task3.Sorts;


namespace Task3.Launcher.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new int[] { 34, 29, -1, 4, 10, 12 };
            try
            {
                numbers.Sort(BaseSort<int>.SortingMode.Ascending, new QuickSort<int>());

                foreach (var i in numbers)
                {
                    Console.Write($"{i} ");
                }
            } catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}