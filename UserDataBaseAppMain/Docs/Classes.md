# Classes in C#

Classes are the fundamental building blocks of object-oriented programming in C#. They encapsulate data and behavior into a single unit.

## Class Structure
```csharp
public class Person
{
    // Fields (private by default)
    private string name;
    private int age;

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Auto-implemented property
    public int Age { get; set; }

    // Constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
```

## Access Modifiers
- `public`: Accessible from anywhere
- `private`: Only accessible within the same class
- `protected`: Accessible in the same class and derived classes
- `internal`: Accessible within the same assembly

## Inheritance
```csharp
public class Employee : Person
{
    public string EmployeeId { get; set; }

    public Employee(string name, int age, string employeeId) 
        : base(name, age)
    {
        EmployeeId = employeeId;
    }
}
```

## Static Members
```csharp
public class Calculator
{
    // Static field
    public static double Pi = 3.14159;

    // Static method
    public static double Add(double a, double b)
    {
        return a + b;
    }
}
```

## Interfaces and Implementation
```csharp
public interface IShape
{
    double CalculateArea();
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
```
