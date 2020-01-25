# Random-Benchmarks
Random benchmarks taken of C#/.NET stuff.

The intention of this repo is to gather common algorithms for things that people often forget about, and benchmark and document their behavior, as well as try to provide guidelines about which are suitable for what instances.

This work has been broken up into separate projects to facilitate ease of development. There's three projects: Benchmarks, which is actually a library that holds the benchmarks; Runner, which is the BenchmarkDotNet executable providing an interface to run the benchmarks; Tests, which validates the algorithms in Benchmarks do what they claim.

# Guidelines

From these benchmarks, various guidelines can be provided when programming for .NET with C#. VB shouldn't be any different. However F# operates differently, so do not use these guidelines without additional F# specific benchmarks.

## Dispatching

Static dispatching is and will always be the most efficient approach, followed by runtime dispatching. However when dynamic dispatching is required, the use of virtual dispatch has been shown to be faster than pattern matching on a typeclass or switching on a tag. Let the vtable do its thing; don't be clever.

## Enum has Flag?

So this is a bit complex due to the several runtimes for .NET.

For .NET Framework (which is becoming obsolete):

Bitwise checks are considerably faster than the [`HasFlag()`](https://docs.microsoft.com/en-us/dotnet/api/system.enum.hasflag) call provided in the runtime. This is because [`HasFlag()`](https://docs.microsoft.com/en-us/dotnet/api/system.enum.hasflag) boxes, and then has to check numerous things because of that. Always use bitwise variants.

For .NET Core, CoreRt, and Mono:

Use whatever. [`HasFlag()`](https://docs.microsoft.com/en-us/dotnet/api/system.enum.hasflag) gets optimized to a bitwise check.

## Property or Field?

Using a property with an implicit backing store, that is, there's no added logic it just gets/sets a value, is exactly as fast as a field. The method call overhead is eliminated.

## Null Argument Guarding

If you have multiple arguments and none of them can be null, do not ever "if-then-else" through them.

## Vector Math

Use vectors for math whenever possible. Creating them from an array is extremely quick.

## Within range

When dealing with numeric types, the naive range check isn't the best, by a large margin. However some complexity is introduced by the fact that different optimal range check algorithms exist for signed and unsigned values, and can not be used interchangably. Always use the arithmetic check. I recommend overloading a [`MethodImplOptions.AggressiveInlining`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.methodimploptions) attributed method which does the appropriate range check for each type. A good numeric library should provide these for you, so check with that first.

As a special note, the arithmetic range check for unsigned values can be partially precomputed, and this should be done if multiple comparisons will be done against the same range.

~~~~csharp
(Actual - Lower) <= (Upper - Lower)
~~~~

The righthand factor can be precomputed, resulting in

~~~~csharp
(Actual - Lower) <= Margin
~~~~

All of these range checks are inclusive to both bounds. To make any algorithm exclusive to both bounds, remove the equality part of the comparison, so that it's just lesser-than or greater-than. If a check must be inclusive to one bound but exclusive to the other, you must use the naive algorithm (I recommend adjusting the bounds to be uniform instead).