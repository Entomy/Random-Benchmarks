using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp50)]
	[SimpleJob(RuntimeMoniker.CoreRt50)]
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class ReturnConstruction {
		[Benchmark]
		public EmptyClass Class() => new EmptyClass();

		[Benchmark]
		public EmptySealedClass SealedClass() => new EmptySealedClass();

		[Benchmark]
		public EmptyStruct Struct() => new EmptyStruct();

		[Benchmark]
		public EmptyRefStruct RefStruct() => new EmptyRefStruct();

		public class EmptyClass {
		}

		public sealed class EmptySealedClass {

		}

		public struct EmptyStruct {

		}

		public ref struct EmptyRefStruct {

		}
	}
}
