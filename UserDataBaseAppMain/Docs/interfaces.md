# Interfaces in C#

An interface defines a contract that classes must follow. It specifies what a class must implement without defining how it should be implemented.

## Key Characteristics

1. Can't contain implementation
2. Can't have fields
3. Members are public by default
4. A class can implement multiple interfaces

## Example

```csharp
public interface IVehicle
{
    void Start();
    void Stop();
    bool IsRunning { get; }
}

public class Car : IVehicle
{
    private bool _isRunning;

    public bool IsRunning => _isRunning;

    public void Start()
    {
        _isRunning = true;
        Console.WriteLine("Car started");
    }

    public void Stop()
    {
        _isRunning = false;
        Console.WriteLine("Car stopped");
    }
}
```

## Interface Inheritance

Interfaces can inherit from other interfaces:

```csharp
public interface IElectricVehicle : IVehicle
{
    int BatteryLevel { get; }
    void Charge();
}
```

## Default Interface Methods (C# 8.0+)

```csharp
public interface ILogger
{
    void Log(string message);
    
    // Default implementation
    void LogError(string message) 
    {
        Log($"ERROR: {message}");
    }
}
```

## Benefits

1. **Abstraction**: Hide implementation details
2. **Multiple Inheritance**: A class can implement multiple interfaces
3. **Polymorphism**: Different classes can provide different implementations
4. **Testing**: Easier to mock for unit testing
5. **Loose Coupling**: Reduces dependencies between components
