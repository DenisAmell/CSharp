using Task2;

namespace Task2.Launcher.App
{   class Programm
    {
        static void Main(string[] args)
        {
            try
            {
                var res = new int[] { 1, 2, 3 }.GetPermutations(EqualityComparer<int>.Instance);
                foreach (var set in res)
                {
                    Console.WriteLine($"[{string.Join(", ", set.Select(x => x.ToString()))}]");
                }
            } catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);            
            }
        }
    }
}