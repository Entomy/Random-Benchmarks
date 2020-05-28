using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class WrapperOverhead {

		Int32 scalar;

		Wrapper wrapper;

		[Benchmark]
		public void Assignment_Scalar() => scalar = 1;

		[Benchmark]
		public void Assignment_Wrapper() => wrapper = 1;

		[Benchmark]
		public void Equals_Scalar() => scalar.Equals(scalar);

		[Benchmark]
		public void Equals_Wrapper() => wrapper.Equals(wrapper);

		private readonly struct Wrapper : IEquatable<Wrapper> {
			private readonly Int32 Value;

			private Wrapper(Int32 value) => Value = value;

			public static implicit operator Wrapper(Int32 value) => new Wrapper(value);

			public override Boolean Equals(Object obj) {
				switch (obj) {
				case Wrapper wrapper:
					return Equals(wrapper);
				default:
					return false;
				}
			}

			public Boolean Equals(Wrapper other) => Value.Equals(other.Value);

			public override Int32 GetHashCode() => Value;
		}
	}
}
