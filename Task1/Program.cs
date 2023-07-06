using Task1;

namespace Task1.Launcher.App
{
    class Programm
    {
        static void Main(string[] args)
        {

            var obj = new Student("Gorschenko", "Denis", "Vitalevich", "M8O-213B-21", Student.Course.CSharp);

            Console.WriteLine(obj.GetNumberCourse);
        }
    }
}