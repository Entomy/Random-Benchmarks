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
	public class WithinUnsignedRange {
		[Params(10, 80, 500)]
		public UInt32 Actual { get; set; }

		[Params(1, 30)]
		public UInt32 Lower { get; set; }

		[Params(100, 40, 600)]
		public UInt32 Upper { get; set; }

		[Benchmark]
		public Boolean Naive() => Lower <= Actual && Actual <= Upper;

		[Benchmark]
		public Boolean Arithmetic() => (Actual - Lower) <= (Upper - Lower);
	}
}
