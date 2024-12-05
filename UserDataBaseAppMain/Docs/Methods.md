# Methods in C#

Methods are blocks of code that perform specific tasks. They are fundamental to organizing code and promoting reusability.

## Method Declaration
```csharp
[access_modifier] [return_type] MethodName([parameters])
{
    // Method body
    return [value]; // if return type isn't void
}
```

## Method Types
```csharp
// Void method (no return value)
public void PrintMessage(string message)
{
    Console.WriteLine(message);
}

// Method with return value
public int Add(int a, int b)
{
    return a + b;
}

// Static method
public static double CalculateArea(double radius)
{
    return Math.PI * radius * radius;
}
```

## Parameter Types
```csharp
// Optional parameters
public void Greet(string name, string greeting = "Hello")
{
    Console.WriteLine($"{greeting}, {name}!");
}

// Out parameters
public void Divide(int a, int b, out int result, out int remainder)
{
    result = a / b;
    remainder = a % b;
}

// Reference parameters (ref)
public void SwapNumbers(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

// Params array
public int Sum(params int[] numbers)
{
    return numbers.Sum();
}
```

## Method Overloading
```csharp
public class Calculator
{
    // Method overloading - same name, different parameters
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}
```

## Expression-Bodied Methods
```csharp
// Shorter syntax for simple methods
public double Square(double x) => x * x;
public void Print(string message) => Console.WriteLine(message);
```
