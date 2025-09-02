# Understanding `out` and `ref` in C#

`out` and `ref` are two of the most commonly confused keywords in C#.  
This article simplifies the concepts into **three key points**.

---

## Point 1: Default is **by value**
By default, variables in C# are passed **by value** to methods.  
That means a copy of the variable is passed, so changes inside the method do not affect the original variable.

Example:
```csharp
public static void SomeFunction(int insideVar)
{
    insideVar = 50;
}

public static void Main()
{
    int outsideVar = 20;
    SomeFunction(outsideVar);
    Console.WriteLine(outsideVar); // Output: 20
}
```

✅ Any modifications inside the function do not affect outsideVar.

## Point 2: ref passes reference + data
When a parameter is marked with ref, the reference of the variable is passed.
This means changes in the method affect the original variable.

Example:

```csharp
public static void SomeFunction(ref int insideVar)
{
    insideVar = 50;
}

public static void Main()
{
    int outsideVar = 20;
    SomeFunction(ref outsideVar);
    Console.WriteLine(outsideVar); // Output: 50
}
```

✅ With ref, data + reference are passed, making it two-way communication.

## Point 3: out passes reference only
When a parameter is marked with out:

Only the reference is passed (not the data).

The method must assign a value to the variable before returning.

Any value from the caller is ignored.

Example:

```csharp
public static void SomeFunction(out int insideVar)
{
    insideVar = 50; // Must assign a value
}

public static void Main()
{
    int outsideVar; // No need to initialize
    SomeFunction(out outSideVar);
    Console.WriteLine(outsideVar); // Output: 50
}
```

✅ With out, the method’s output always overwrites the caller variable.
It is one-way from the callee → caller.

---

## Point number 4: The `in` keyword (readonly reference)

Starting with C# 7.2, we also have the `in` keyword for parameters.  
This allows a variable (typically a `struct`) to be passed **by reference** like `ref`, but the key difference is that it is **readonly inside the method**.

- With `in`, no copying happens → improves performance for large structs.  
- The method can **read** the data but **cannot modify** it.  

Example:
```csharp
public struct Point
{
    public int X;
    public int Y;
}

public class Demo
{
    public static void Print(in Point p)
    {
        Console.WriteLine($"Point: {p.X}, {p.Y}");

        // p.X = 10; ❌ Compile-time error (readonly)
    }

    public static void Main()
    {
        Point pt = new Point { X = 5, Y = 10 };
        Print(in pt); // Passed by reference, but readonly
    }
}


## Summary
REF: Data + reference passed → two-way (caller ↔ callee).

OUT: Only reference passed, callee must assign → one-way (callee → caller).

IN: Only reference passed, readonly inside method → one-way (caller → callee).

