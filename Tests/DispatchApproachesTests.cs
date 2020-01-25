using System;
using RandomBenchmarks;
using Xunit;

namespace Tests {
	public class DispatchApproachesTests {
		DispatchApproaches instance = new DispatchApproaches();

		[Fact]
		public void VirtualTableCall() => Assert.Equal(5, instance.VirtualTableCall());

		[Fact]
		public void PatternMatchCall() => Assert.Equal(5, instance.PatternMatchCall());

		[Fact]
		public void TagSwitchCall() => Assert.Equal(5, instance.TagSwitchCall());
	}
}
