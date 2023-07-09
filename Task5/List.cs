namespace Task5;

public class List<T>
{

    private sealed class LinkedListNode<T>
    {
        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }

        public T Data { get; set; }

        public LinkedListNode<T>? Next { get; set; }

    }

}