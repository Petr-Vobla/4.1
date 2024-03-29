public class MyArray<T>
{
    private T[] array;
    private int capacity;
    private int size;

    public MyArray()
    {
        capacity = 10;
        array = new T[capacity];
        size = 0;
    }

    public MyArray(int capacity)
    {
        if (capacity <= 0)
        {
            Console.WriteLine("Емкость массива должна быть больше нуля");
            capacity = 7;
        }

        array = new T[capacity];
        size = 0;
    }

    public void Add(T item)
    {
        if (size == capacity)
        {
            capacity = 2 * capacity + 1;
            Array.Resize(ref array, capacity);
        }

        array[size] = item;
        size++;
    }

    public void Remove(T item)
    {
        int index = Array.IndexOf(array, item, 0, size);
        if (index >= 0)
        {
            for (int i = index; i < size - 1; i++)
                array[i] = array[i + 1];

            size--;
        }
    }

    public void Sort()
    {
        Array.Sort(array, 0, size);
    }

    public int Count()
    {
        return size;
    }

    public int Count(Func<T, bool> condition)
    {
        int count = 0;
        for (int i = 0; i < count; i++)
        {
            if (condition(array[i]))
                count++;
        }
        return count;
    }

    public bool Any(Func<T, bool> condition)
    {
        for (int i = 0; i < size; i++)
        {
            if (condition(array[i]))
                return true;
        }
        return false;
    }

    public bool All(Func<T, bool> condition)
    {
        for (int i = 0; i < size; i++)
        {
            if (!condition(array[i]))
                return false;
        }
        return true;
    }

    public bool Contains(T item)
    {
        return Array.IndexOf(array, item, 0, size) >= 0;
    }

    public T FirstOrDefault(Func<T, bool> condition)
    {
        for (int i = 0; i < size; i++)
        {
            if (condition(array[i]))
                return array[i];
        }
        return default(T);
    }

    public void ForEach(Action<T> action)
    {
        for (int i = 0; i < size; i++)
        {
            action(array[i]);
        }
    }

    public void Reverse()
    {
        Array.Reverse(array, 0, size);
    }

    public T Min()
    {
        T min = array[0];
        for (int i = 1; i < size; i++)
        {
            if (Comparer<T>.Default.Compare(array[i], min) < 0)
                min = array[i];
        }
        return min;
    }

    public T Max()
    {
        T max = array[0];
        for (int i = 1; i < size; i++)
        {
            if (Comparer<T>.Default.Compare(array[i], max) > 0)
                max = array[i];
        }
        return max;
    }
}

public class Program
{
    public static void Main()
    {
        MyArray<int> intArray = new MyArray<int>();
        intArray.Add(5);
        intArray.Add(3);
        intArray.Add(7);

        Console.WriteLine("Min: " + intArray.Min());
        Console.WriteLine("Max: " + intArray.Max());

        MyArray<string> stringArray = new MyArray<string>();
        stringArray.Add("John");
        stringArray.Add("Silver");

        Console.WriteLine("Min: " + stringArray.Min());
        Console.WriteLine("Max: " + stringArray.Max());
    }
}

