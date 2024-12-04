# Events in C#

Events enable a class or object to notify other classes or objects when something of interest occurs. They are built on delegates and follow the publisher-subscriber pattern.

## Basic Event Declaration

```csharp
public class Publisher
{
    // Declare the event using EventHandler delegate
    public event EventHandler<EventArgs> SimpleEvent;

    protected virtual void OnSimpleEvent()
    {
        SimpleEvent?.Invoke(this, EventArgs.Empty);
    }

    public void DoSomething()
    {
        // Some code here
        OnSimpleEvent();
    }
}
```

## Custom Event Arguments

```csharp
public class OrderEventArgs : EventArgs
{
    public string OrderId { get; }
    public decimal Amount { get; }

    public OrderEventArgs(string orderId, decimal amount)
    {
        OrderId = orderId;
        Amount = amount;
    }
}

public class OrderProcessor
{
    public event EventHandler<OrderEventArgs> OrderProcessed;

    protected virtual void OnOrderProcessed(OrderEventArgs e)
    {
        OrderProcessed?.Invoke(this, e);
    }

    public void ProcessOrder(string orderId, decimal amount)
    {
        // Process the order
        OnOrderProcessed(new OrderEventArgs(orderId, amount));
    }
}
```

## Event Subscription

```csharp
public class OrderMonitor
{
    public void Subscribe(OrderProcessor processor)
    {
        processor.OrderProcessed += HandleOrderProcessed;
    }

    public void Unsubscribe(OrderProcessor processor)
    {
        processor.OrderProcessed -= HandleOrderProcessed;
    }

    private void HandleOrderProcessed(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"Order {e.OrderId} processed for ${e.Amount}");
    }
}
```

## Custom Event Accessors

```csharp
public class CustomEventPublisher
{
    private EventHandler<EventArgs> _event;

    public event EventHandler<EventArgs> CustomEvent
    {
        add
        {
            _event += value;
            Console.WriteLine("Event handler added");
        }
        remove
        {
            _event -= value;
            Console.WriteLine("Event handler removed");
        }
    }
}
```

## Event Best Practices

1. **Thread Safety**
```csharp
public event EventHandler<EventArgs> ThreadSafeEvent;

protected virtual void OnThreadSafeEvent()
{
    var handler = ThreadSafeEvent;
    handler?.Invoke(this, EventArgs.Empty);
}
```

2. **Weak Event Pattern**
```csharp
public class WeakEventManager
{
    private readonly WeakReference<EventHandler<EventArgs>> _eventReference;

    public void AddHandler(EventHandler<EventArgs> handler)
    {
        _eventReference.SetTarget(handler);
    }
}
```

## Common Use Cases

1. **UI Events**
```csharp
button.Click += (sender, e) => Console.WriteLine("Button clicked!");
```

2. **Progress Reporting**
```csharp
public class DataProcessor
{
    public event EventHandler<ProgressEventArgs> ProgressChanged;

    public void ProcessData()
    {
        for (int i = 0; i <= 100; i += 10)
        {
            OnProgressChanged(i);
        }
    }
}
```

3. **State Changes**
```csharp
public class Connection
{
    public event EventHandler<ConnectionStateEventArgs> StateChanged;

    private ConnectionState _state;
    public ConnectionState State
    {
        get => _state;
        set
        {
            if (_state != value)
            {
                _state = value;
                OnStateChanged(new ConnectionStateEventArgs(value));
            }
        }
    }
}
```

## Benefits

1. **Loose Coupling**: Publishers don't need to know about subscribers
2. **Multiple Subscribers**: Multiple objects can respond to events
3. **Extensibility**: New subscribers can be added without modifying publisher
4. **Separation of Concerns**: Clear separation between event source and handlers
