using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Random_Benchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	public class WithinRange {
		[Params(10, 80, 500)]
		public Int32 Actual { get; set; }

		[Params(1, 30)]
		public Int32 Lower { get; set; }

		[Params(100, 40, 600)]
		public Int32 Upper { get; set; }

		[Benchmark]
		public Boolean Naive() => Lower <= Actual && Actual <= Lower;

		[Benchmark]
		public Boolean Arithmetic1() => (Actual - Lower) * (Upper - Actual) >= 0;

		[Benchmark]
		public Boolean Arithmetic2() => (Actual - Lower) <= (Upper - Lower);
	}
}
