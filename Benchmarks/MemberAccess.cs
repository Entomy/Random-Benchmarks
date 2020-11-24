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
	public class MemberAccess {

		//! These are so fast that they need to be inflated to take more time. So long as the inflation mechanism is identical the results are still comparable.

		private Int32 field;

		private Int32 Property { get; set; }

		[Benchmark]
		public void FieldAccess() {
			for (Int32 i = 1_000_000; i-- > 0;) {
				_ = field;
			}
		}

		[Benchmark]
		public void PropertyAccess() {
			for (Int32 i = 1_000_000; i-- > 0;) {
				_ = Property;
			}
		}

		[Benchmark]
		public void FieldMutate() {
			for (Int32 i = 1_000_000; i-- > 0;) {
				field = i;
			}
		}

		[Benchmark]
		public void PropertyMutate() {
			for (Int32 i = 1_000_000; i-- > 0;) {
				Property = i;
			}
		}
	}
}
