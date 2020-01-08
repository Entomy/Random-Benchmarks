using System;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Random_Benchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	public class WithinRange {
		[Params(10)]
		public Int32 Actual { get; set; }

		[Params(1)]
		public Int32 Lower { get; set; }

		[Params(100)]
		public Int32 Upper { get; set; }

		[Benchmark]
		public Boolean Naive() => Lower <= Actual && Actual <= Lower;

		[Benchmark]
		public Boolean Arithmetic() => (Actual - Lower) * (Upper - Actual) >= 0;
	}
}
