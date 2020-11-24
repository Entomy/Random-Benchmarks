using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp50)]
	[SimpleJob(RuntimeMoniker.CoreRt50)]
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class NullableEqualityChecking {
		[Params("", null)]
		public String A { get; set; }

		[Params("", null)]
		public String B { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		/// <remarks>
		/// This is a special equals designed to minimize the equality check as much as possible, so that no checking is replicated. The reason for this is that equality methods are going to do their own checking, and that shouldn't be duplicated. This kind of checking would normally be what's in the equals method, and if the checking done here isn't exhaustive enough, the tests need to report it as a failure, not let an underlying equals method catch it.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Boolean Equals(String a, String b) => ReferenceEquals(a, b);

		[Benchmark(Baseline = true)]
		public Boolean Naive() {
			if (A is null && B is null) {
				return true;
			} else if (A is null) {
				return false;
			} else if (B is null) {
				return false;
			} else {
				return Equals(A, B);
			}
		}

		[Benchmark]
		public Boolean XorLead() => !(A is null ^ B is null) && Equals(A, B);
	}
}
