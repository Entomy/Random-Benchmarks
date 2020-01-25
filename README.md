# Random-Benchmarks
Random benchmarks taken of C#/.NET stuff.

The intention of this repo is to gather common algorithms for things that people often forget about, and benchmark and document their behavior, as well as try to provide guidelines about which are suitable for what instances.

This work has been broken up into separate projects to facilitate ease of development. There's three projects: Benchmarks, which is actually a library that holds the benchmarks; Runner, which is the BenchmarkDotNet executable providing an interface to run the benchmarks; Tests, which validates the algorithms in Benchmarks do what they claim.