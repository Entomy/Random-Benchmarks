using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class NullableEqualityChecking {
		[Params("", null)]
		public String A { get; set; }

		[Params("", null)]
		public String B { get; set; }

		[Benchmark(Baseline = true)]
		public Boolean Naive() {
			if (A is null && B is null) {
				return true;
			} else if (A is null) {
				return false;
			} else if (B is null) {
				return false;
			} else {
				return A == B;
			}
		}

		[Benchmark]
		public Boolean XorLead() {
			if (A is null ^ B is null) {
				return false;
			} else {
				return A == B;
			}
		}
	}
}
