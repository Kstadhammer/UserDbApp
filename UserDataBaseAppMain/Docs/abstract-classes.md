# Abstract Classes in C#

Abstract classes provide a base for other classes to inherit from while allowing some methods to be implemented and others to be left abstract (to be implemented by derived classes).

## Key Characteristics

1. Cannot be instantiated
2. Can have both abstract and concrete methods
3. Can have fields and constructors
4. A class can inherit from only one abstract class

## Example

```csharp
public abstract class Shape
{
    // Concrete property
    public string Color { get; set; }

    // Constructor
    protected Shape(string color)
    {
        Color = color;
    }

    // Abstract method - must be implemented by derived classes
    public abstract double CalculateArea();

    // Concrete method - can be used as-is or overridden
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"This shape is {Color}");
    }
}

public class Circle : Shape
{
    private double _radius;

    public Circle(double radius, string color) : base(color)
    {
        _radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
}
```

## Abstract vs Interface

### Abstract Class
- Can have implementation
- Can have fields
- Can have constructors
- Single inheritance only
- Can have access modifiers

### Interface
- No implementation (except default methods in C# 8.0+)
- No fields
- No constructors
- Multiple inheritance possible
- All members are public

## When to Use Abstract Classes

1. When you want to share code among several related classes
2. When you expect classes to have common methods or fields
3. When you need to provide a base implementation with some common functionality
4. When you want to declare non-public members

## Benefits

1. **Code Reuse**: Share common functionality
2. **Consistency**: Enforce common structure
3. **Flexibility**: Allow different implementations while maintaining a common interface
4. **Security**: Can have protected members
