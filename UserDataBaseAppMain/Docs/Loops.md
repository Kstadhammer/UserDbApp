# Loops in C#

Loops are used to execute a block of code repeatedly. C# provides several types of loops for different scenarios.

## For Loop
Used when you know exactly how many times you want to iterate.
```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iteration {i}");
}
```

## While Loop
Executes as long as a condition is true.
```csharp
int count = 0;
while (count < 5)
{
    Console.WriteLine($"Count is {count}");
    count++;
}
```

## Do-While Loop
Similar to while loop but guarantees at least one execution.
```csharp
int number = 0;
do
{
    Console.WriteLine(number);
    number++;
} while (number < 5);
```

## Foreach Loop
Used to iterate over collections (arrays, lists, etc.).
```csharp
string[] fruits = { "apple", "banana", "orange" };
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
```

## Loop Control
- `break`: Exits the loop
- `continue`: Skips to the next iteration
- `return`: Exits the method
