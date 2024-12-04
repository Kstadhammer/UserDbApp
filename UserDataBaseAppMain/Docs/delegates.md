# Delegates in C#

Delegates are type-safe function pointers that can hold references to methods. They enable methods to be passed as parameters and support callbacks and event handling.

## Delegate Declaration

```csharp
// Simple delegate
public delegate void MessageHandler(string message);

// Generic delegate
public delegate T Operation<T>(T x, T y);
```

## Built-in Delegates

```csharp
// Action delegates (no return value)
Action<string> displayMessage = Console.WriteLine;
Action<int, int> processNumbers = (x, y) => Console.WriteLine(x + y);

// Func delegates (with return value)
Func<int, int, int> add = (x, y) => x + y;
Func<string, bool> isLongString = s => s.Length > 10;

// Predicate (returns bool)
Predicate<int> isEven = x => x % 2 == 0;
```

## Multicast Delegates

```csharp
public class Logger
{
    public delegate void LogDelegate(string message);
    
    private LogDelegate _logHandlers;
    
    public void RegisterLogger(LogDelegate handler)
    {
        _logHandlers += handler;
    }
    
    public void UnregisterLogger(LogDelegate handler)
    {
        _logHandlers -= handler;
    }
    
    public void Log(string message)
    {
        _logHandlers?.Invoke(message);
    }
}
```

## Anonymous Methods

```csharp
delegate void Operation(int x, int y);

Operation multiply = delegate(int x, int y)
{
    Console.WriteLine($"Result: {x * y}");
};
```

## Lambda Expressions

```csharp
// Expression lambda
Func<int, int> square = x => x * x;

// Statement lambda
Func<int, int, string> compare = (x, y) =>
{
    if (x > y) return "First is larger";
    if (x < y) return "Second is larger";
    return "Equal";
};
```

## Common Use Cases

1. **Callback Methods**
```csharp
public void ProcessData(Action<string> callback)
{
    // Process data
    string result = "Processing complete";
    callback(result);
}
```

2. **LINQ Operations**
```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var evenNumbers = numbers.Where(x => x % 2 == 0);
```

3. **Method Abstraction**
```csharp
public class Calculator
{
    public T Execute<T>(Func<T, T, T> operation, T x, T y)
    {
        return operation(x, y);
    }
}
```

## Benefits

1. **Flexibility**: Methods can be passed as parameters
2. **Encapsulation**: Implementation details can be hidden
3. **Event Handling**: Foundation for the event system
4. **Asynchronous Programming**: Used in async/await pattern
