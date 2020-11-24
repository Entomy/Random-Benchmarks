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
	public class NullArgChecking {
		[Params(null, "")]
		public String A { get; set; }

		[Params("", null)]
		public String B { get; set; }

		[Benchmark(Baseline = true)]
		public Boolean Naive() {
			if (A is null) {
				return true;
			} else if (B is null) {
				return true;
			} else {
				return false;
			}
		}

		[Benchmark]
		public Boolean Or() => A is null | B is null;

		[Benchmark]
		public Boolean ShortCircuitOr() => A is null || B is null;
	}
}
