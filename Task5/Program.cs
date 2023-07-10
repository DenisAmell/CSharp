namespace Task5.Launcher.App
{
    class Program
    {
        static void Main(string[] args)
        {


            var list = new LinkedList<IEqualityComparer<int>>();

            list.PushBack(EqualityComparer<int>.Default);
    
            var newList = new LinkedList<IEqualityComparer<int>>();

            // newList.PushFront(4);
            newList.PushBack( EqualityComparer.Instance);
            

            //LinkedList<int> concatList = list + newList;

            var unionList = list * newList; 
           // list.PushAt(25, 2);

            // list.RemoveAt(2);

            Console.WriteLine(list.ToString());
            Console.WriteLine(newList.ToString());
          //  Console.WriteLine(concatList.ToString());
            Console.WriteLine(unionList.ToString());
        }
    }
}