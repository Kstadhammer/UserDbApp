# Lists in C#

Lists are dynamic collections that can grow or shrink in size. They are part of the System.Collections.Generic namespace.

## Creating Lists
```csharp
// Empty list
List<string> names = new List<string>();

// List with initial values
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
```

## Common List Operations
```csharp
List<string> fruits = new List<string>();

// Adding elements
fruits.Add("apple");               // Add single item
fruits.AddRange(new[] { "banana", "orange" });  // Add multiple items

// Accessing elements
string firstFruit = fruits[0];     // Access by index

// Removing elements
fruits.Remove("apple");            // Remove specific item
fruits.RemoveAt(0);               // Remove at index
fruits.Clear();                   // Remove all items

// Checking contents
bool hasApple = fruits.Contains("apple");
int count = fruits.Count;         // Get number of items
```

## List Methods
- `Insert()`: Add an element at a specific position
- `IndexOf()`: Find the position of an element
- `Sort()`: Sort the list
- `Reverse()`: Reverse the order of elements
- `ToArray()`: Convert list to array

## LINQ with Lists
```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };

// Filter
var evenNumbers = numbers.Where(n => n % 2 == 0);

// Transform
var doubled = numbers.Select(n => n * 2);

// Sort
var sorted = numbers.OrderByDescending(n => n);
```
