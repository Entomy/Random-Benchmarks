using System;
using RandomBenchmarks;
using Xunit;

namespace Tests {
	public class HasFlagApproachesTests {
		HasFlagApproaches instance = new HasFlagApproaches();

		[Fact]
		public void HasFlag() => Assert.True(instance.HasFlag());

		[Fact]
		public void MicrosoftBitwise() => Assert.True(instance.MicrosoftBitwise());

		[Fact]
		public void RoslynatorBitwise() => Assert.True(instance.RoslynatorBitwise());
	}
}
