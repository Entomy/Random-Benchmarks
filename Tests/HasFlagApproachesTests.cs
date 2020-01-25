using System;
using RandomBenchmarks;
using Xunit;

namespace Tests {
	public class HasFlagApproachesTests {
		HasFlagApproaches instance = new HasFlagApproaches();

		[Fact]
		public void HasFlag() => Assert.True(instance.HasFlag());

		[Fact]
		public void Bitwise() => Assert.True(instance.Bitwise());
	}
}
