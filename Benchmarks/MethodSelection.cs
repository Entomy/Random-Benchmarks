using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class MethodSelection {
		[Params(true, false)]
		public Boolean Selector { get; set; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void specificTrue() => new String('i', 10).Trim().Replace('e', 'o');

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void specificFalse() => new String('u', 10).Trim().Replace('e', 'o');

		[Benchmark(Baseline = true)]
		public void Specific() => specificTrue();

		[Benchmark]
		public void Discriminated() {
			if (Selector) {
				specificTrue();
			} else {
				specificFalse();
			}
		}
	}
}
