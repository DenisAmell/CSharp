using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.Collections;


namespace Task5;


public class LinkedList<T> :
    IEnumerable<T>,
    IEquatable<LinkedList<T>>,
    ICloneable
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

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            // Mutable string object
           
            s.Append("(");
            s.Append(Data);
            s.Append(")->");

            return s.ToString();
        }

    }

    private LinkedListNode<T>? _first;
    private LinkedListNode<T>? _last;
    private int _count;

    public int Count => _count;
    public T First => _first.Data;
    public T Last => _last.Data;

    public LinkedList()
    {
        _first = _last = null;
    }

    public LinkedList(IEnumerable<T> list)
    {
        foreach (var item in list)
        {
            PushBack(item);
        }
    }

    public LinkedList(LinkedList<T> list)
    {
        var currentNode = list._first;

        while (currentNode != null)
        {
            PushBack(currentNode.Data);
            currentNode = currentNode.Next;
        }
    }


    public LinkedList<T> PushFront(T? data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        _first = _first == null ? (_last = new LinkedListNode<T>(data)) : (new LinkedListNode<T>(data) { Next = _first });

        _count++;

        return this;
    }
        
    public LinkedList<T> PushBack(T? data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        _last = _first == null ? _first = new LinkedListNode<T>(data) : _last!.Next = new LinkedListNode<T>(data);

        _count++;

        return this;
    }

    public LinkedList<T> PushAt(T? data, int index)
    {

        if (data == null) throw new ArgumentNullException(nameof(data));

        if (index < 0 || index > _count) throw new ArgumentOutOfRangeException("The index is greater than the number of elements ", nameof(index));

        LinkedListNode<T>? curNode = _first;
        LinkedListNode<T>? prevNode = null;

        for (int i = 0; i < index; i++)
        {
            prevNode = curNode;
            curNode = curNode.Next;
        }

        var newNode = new LinkedListNode<T>(data) { Next = curNode };

        if (prevNode == null)
        {
            _first = newNode;
        } else 
        { 
            prevNode.Next = newNode;
        }       

        if (index == _count)
        {
            _last = newNode;
        }


        _count++;
        return this;
    }


    public T PopFront()
    {
        if (_first == null) throw new InvalidOperationException("Is empty");

        var removedValue = _first.Data;

        _first = _first.Next;

        _count--;

        return removedValue;
    }


    public T PopBack()
    {
        if (_first == null) throw new InvalidOperationException("Is empty");


        var curNude = _first;
        T removedValue;

        LinkedListNode<T> prevNode = null;

        for (int i = 0; i < _count - 1; i++)
        {
            prevNode = curNude;
            curNude = curNude.Next;
        }

        if (prevNode == null)
        {
             removedValue = curNude.Data;
            _first = _last = null;
            _count--;
            return removedValue;
        }

        removedValue = prevNode.Data;

        _last = prevNode;
        _last.Next = null;
        _count--;
 

        return removedValue;
    }


    public T RemoveAt(int index)
    {
        if (index < 0 || index >= _count) throw new ArgumentException("The index is greater than the number of elements ", nameof(index));

        if (_count == 0) throw new IndexOutOfRangeException("List is empty");

        T removedValue;
        

        if (_count == 1)
        {
            removedValue = _first.Data;
            _first = _last = null;
            return removedValue;
        }

        var curNode = _first;
        LinkedListNode<T> prevNode = null;

        for(int i = 0; i < index; i++)
        {
            prevNode = curNode;
            curNode = curNode.Next;
        }

        removedValue = curNode.Data;

        if (prevNode == null) _first = _first!.Next;
        else prevNode.Next = curNode!.Next;

        if (index == _count - 1) _last = prevNode;


        _count--;

        return removedValue;

    }


    public LinkedList<T> Reverse()
    {
        if (_count == 0) throw new IndexOutOfRangeException("Is empty");

        var curNode = _first;

        var newLinkedList = new LinkedList<T>();

        while(curNode != null)
        {
            newLinkedList.PushFront(curNode.Data);
            curNode = curNode.Next;
        }

        return newLinkedList;
    }


    public static LinkedList<T> operator!(LinkedList<T> other)
    {
        return other.Reverse();
    }

    private LinkedList<T> Find(out T findValue, int index)
    {
        if (_count == 0) throw new Exception("Is empty");

        if (index < 0 || index >= _count) throw new ArgumentException("The index is greater than the number of elements", nameof(index));


        var curNode = _first;

        while (index > 0)
        {
            curNode = curNode!.Next;
            index--;
        }

        findValue = curNode!.Data;

        return this;
    }

    private LinkedList<T> Update(T? data, int index)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        if (index < 0 || index >= _count) throw new ArgumentException("The index is greater than the number of elements", nameof(index));

        if (_count == 0) throw new Exception("Is empty");

        var currentNode = _first;

        while (index > 0)
        {
            currentNode = currentNode!.Next;
            index--;
        }

        currentNode!.Data = data;

        return this;
    }


    public T this[
       int index]
    {
        get
        {
            Find(out var findValue, index);
            return findValue;
        }

        set => Update(value, index);
    }

    public static LinkedList<T> ConcatList(LinkedList<T> firstList,LinkedList<T> secondList)
    {
        if (firstList is null)
        {
            throw new ArgumentNullException(nameof(firstList));
        }

        if (secondList is null)
        {
            throw new ArgumentNullException(nameof(secondList));
        }

        var firstListCount = firstList.Count;
        var secondListCount = secondList.Count;
        var listLength = firstListCount + secondListCount;
        var newList = new LinkedList<T>();
        var i = 0;
        for (; i < listLength; i++)
        {
            if (i < firstListCount)
                newList.PushBack(firstList[i]);
            else
                newList.PushBack(secondList[i - secondListCount]);
        }

        return newList;
    }


    public static LinkedList<T> operator +(LinkedList<T> firstList, LinkedList<T> secondList)
    {
        return ConcatList(firstList, secondList);
    }

    public static LinkedList<T> IntersectionList(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList,
        IEqualityComparer<T> comparer)
    {
        if (firstList == null) throw new ArgumentNullException(nameof(firstList));
        if (secondList == null) throw new ArgumentNullException(nameof(secondList));

        return new LinkedList<T>(firstList.Intersect(secondList, comparer));
    }

    public static LinkedList<T> operator&(LinkedList<T> firstList, LinkedList<T> secondList)
    {
        return IntersectionList(firstList, secondList, EqualityComparer<T>.Default);
    }

    public static LinkedList<T> UnionList(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList,
        IEqualityComparer<T> comparer)
    {
        if (firstList == null) throw new ArgumentNullException(nameof(firstList));
        if (secondList == null) throw new ArgumentNullException(nameof(secondList));

        return new LinkedList<T>(firstList.Union(secondList, comparer));
    }

    public static LinkedList<T> operator |(LinkedList<T> firstList, LinkedList<T> secondList)
    {
        return UnionList(firstList, secondList, EqualityComparer<T>.Default);
    }


    public static LinkedList<T> Except(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList,
        IEqualityComparer<T> comparer)
    {
        if (firstList == null) throw new ArgumentNullException(nameof(firstList));
        if (secondList == null) throw new ArgumentNullException(nameof(secondList));

        return new LinkedList<T>(firstList.Except(secondList, comparer));
    }

    public static LinkedList<T> operator- (LinkedList<T> firstList, LinkedList<T> secondList)
    {
        return UnionList(firstList, secondList, EqualityComparer<T>.Default);
    }

    public void Each(Action<T> action)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        if (_count == 0) throw new Exception("Is empty");

        foreach (var item in this)
        {
            action(item);
        }
    }



    public static bool operator ==(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        if (firstList is null && secondList is null) return true;

        if (firstList is null || secondList is null) return false;

        return firstList.Equals(secondList);
    }

    public static bool operator !=(
        LinkedList<T>? firstList,
        LinkedList<T>? secondList)
    {
        if (firstList is null && secondList is null) return false;

        if (firstList is null || secondList is null) return true;

        return !(firstList.Equals(secondList));
    }


    public static LinkedList<T> MultList(LinkedList<T> firstList, LinkedList<T> secondList)
    {
        var newLinkedList = new LinkedList<T>();

        var sizeNewList = firstList.Count < secondList.Count ? firstList.Count : secondList.Count;


        for (int i = 0; i < sizeNewList; i++)
        {
            newLinkedList.PushBack((dynamic?)firstList[i] * secondList[i]);
        }

        return newLinkedList;
    }


    public static LinkedList<T> operator*(LinkedList<T> firstList, LinkedList<T> secondList)
    {
        return MultList(firstList, secondList);
    }

    public LinkedList<T> Sort(
      IComparer<T>? comparer,
      BaseSort<T>.SortingMode mode = BaseSort<T>.SortingMode.Ascending,
      BaseSort<T>.SortingAlgorithm algorithm = BaseSort<T>.SortingAlgorithm.QuickSort)
    {
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        if (_count == 0) throw new Exception("List is empty");

        return new LinkedList<T>(this.ToArray().Sort(mode, algorithm, comparer));
    }

    public LinkedList<T> Sort(
        Comparer<T>? comparer,
        BaseSort<T>.SortingMode mode = BaseSort<T>.SortingMode.Ascending,
         BaseSort<T>.SortingAlgorithm algorithm = BaseSort<T>.SortingAlgorithm.QuickSort)
    {
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        if (_count == 0) throw new Exception("List is empty");

        return new LinkedList<T>(this.ToArray().Sort(mode, algorithm, comparer));
    }

    public LinkedList<T> Sort(
        Comparison<T>? comparer,
         BaseSort<T>.SortingMode mode = BaseSort<T>.SortingMode.Ascending,
         BaseSort<T>.SortingAlgorithm algorithm = BaseSort<T>.SortingAlgorithm.QuickSort)
    {
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        if (_count == 0) throw new InvalidOperationException("List is empty");

        return new LinkedList<T>(this.ToArray().Sort(mode, algorithm, comparer));
    }




    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = _first;
        while (currentNode != null)
        {
            yield return currentNode.Data;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        if (Count == 0) return "[]";


        StringBuilder s = new StringBuilder();

        s.Append("[");
   

        LinkedListNode<T>? node = _first;

        while (node != null)
        {
            
            s.Append(node.ToString());

            node = node.Next;
        }
        s.Append("XXX");
        s.Append("]");

       
        return s.ToString();
    }

    public bool Equals(LinkedList<T>? other)
    {
        if (other == null) return false;

        if (_count != other.Count) return false;

        if (_count == 0) return true;

        var thisNode = _first;
        var otherNode = other._first;

        while (thisNode != null)
        {
            if (thisNode.Data == null && otherNode.Data != null) return false;

            if (!thisNode.Data!.Equals(otherNode!.Data)) return false;

            thisNode = thisNode.Next;
            otherNode = otherNode.Next;
        }

        return true;
    }


    public override bool Equals(object? obj)
    {
        if (obj ==  null) return false;

        if(obj is LinkedList<T> list) return Equals(list);

        return false;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        var currentNode = _first;

        while (currentNode != null)
        {
            hashCode.Add(currentNode.Data);
            currentNode = currentNode.Next;
        }

        return hashCode.ToHashCode();
    }

    public object Clone()
    {
        return new LinkedList<T>(this);
    }
}