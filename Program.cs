using Task2;

namespace CSharp.Launcher.App
{
    class Programm
    {
        static void Main(string[] args)
        {
            try
            {
                var res = new int[] { 1, 1, 2, 2 }.GetPermutations(EqualityComparer.Instance);
                foreach (var set in res)
                {
                    Console.WriteLine($"[{string.Join(", ", set.Select(x => x.ToString()))}]");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}