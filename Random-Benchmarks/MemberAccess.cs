using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Random_Benchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
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
