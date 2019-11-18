using System;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Random_Benchmarks {
	[SuppressMessage("Minor Code Smell", "S3626:Jump statements should not be redundant", Justification = "We're benchmarking code")]
	[SuppressMessage("Major Bug", "S3923:All branches in a conditional structure should not have exactly the same implementation", Justification = "We're benchmarking code")]
	[SuppressMessage("Redundancy", "RCS1134: Remove redundant statement", Justification = "We're benchmarking code")]
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	public class NullArgChecking {
		[Params("", "")]
		public String A { get; set; }

		[Params("", null)]
		public String B { get; set; }

		[Benchmark(Baseline = true)]
		public void Naive() {
			if (A is null) {
				return;
			} else if (B is null) {
				return;
			} else {
				return;
			}
		}

		[Benchmark]
		[SuppressMessage("Blocker Code Smell", "S2178:Short-circuit logic should be used in boolean contexts", Justification = "We're benchmarking code")]
		[SuppressMessage("Usage", "RCS1233:Use short-circuiting operator.", Justification = "We're benchmarking code")]
		public void Or() {
			if (A is null | B is null) {
				return;
			} else {
				return;
			}
		}

		[Benchmark]
		public void ShortCircuitOr() {
			if (A is null || B is null) {
				return;
			} else {
				return;
			}
		}
	}
}
