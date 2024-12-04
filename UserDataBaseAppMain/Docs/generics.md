# Generics in C#

Generics allow you to write type-safe classes, interfaces, and methods that can work with different data types while maintaining type safety.

## Basic Syntax

```csharp
public class GenericList<T>
{
    private T[] items;
    private int count;

    public void Add(T item)
    {
        if (count == items.Length)
        {
            Array.Resize(ref items, items.Length * 2);
        }
        items[count++] = item;
    }

    public T GetItem(int index)
    {
        return items[index];
    }
}
```

## Generic Constraints

```csharp
// Class constraint
public class DataManager<T> where T : class
{
    // T must be a reference type
}

// Interface constraint
public class Calculator<T> where T : IComparable<T>
{
    // T must implement IComparable<T>
}

// Multiple constraints
public class Repository<T> where T : class, new()
{
    // T must be a reference type and have a parameterless constructor
}
```

## Generic Methods

```csharp
public static class Utilities
{
    public static void Swap<T>(ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
    }

    public static bool AreEqual<T>(T first, T second) where T : IEquatable<T>
    {
        return first.Equals(second);
    }
}
```

## Common Generic Interfaces

```csharp
// IEnumerable<T>
public class Collection<T> : IEnumerable<T>
{
    private List<T> items = new List<T>();

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// IComparable<T>
public class ComparableItem<T> : IComparable<ComparableItem<T>> where T : IComparable<T>
{
    public T Value { get; set; }

    public int CompareTo(ComparableItem<T> other)
    {
        return Value.CompareTo(other.Value);
    }
}
```

## Benefits

1. **Type Safety**: Catch type errors at compile-time
2. **Code Reuse**: Write code that works with multiple types
3. **Performance**: Avoid boxing/unboxing with value types
4. **Type Inference**: Let compiler determine types automatically

## Common Generic Collections

```csharp
List<T>           // Dynamic array
Dictionary<K,V>   // Key-value pairs
HashSet<T>        // Unique elements
Queue<T>          // First-in-first-out
Stack<T>          // Last-in-first-out
```
