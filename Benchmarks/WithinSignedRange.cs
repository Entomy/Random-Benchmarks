using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class WithinSignedRange {
		[Params(10, 80, 500)]
		public Int32 Actual { get; set; }

		[Params(1, 30)]
		public Int32 Lower { get; set; }

		[Params(100, 40, 600)]
		public Int32 Upper { get; set; }

		[Benchmark]
		public Boolean Naive() => Lower <= Actual && Actual <= Upper;

		[Benchmark]
		public Boolean Arithmetic() => (Actual - Lower) * (Upper - Actual) >= 0;
	}
}
