using System;
using RandomBenchmarks;
using Xunit;

namespace Tests {
	public class NullArgCheckingTests {
		NullArgChecking instance = new NullArgChecking();

		[Theory]
		[InlineData(false, "", "")]
		[InlineData(true, null, "")]
		[InlineData(true, "", null)]
		[InlineData(true, null, null)]
		public void Naive(Boolean exp, String a, String b) {
			instance.A = a;
			instance.B = b;
			Assert.Equal(exp, instance.Naive());
		}

		[Theory]
		[InlineData(false, "", "")]
		[InlineData(true, null, "")]
		[InlineData(true, "", null)]
		[InlineData(true, null, null)]
		public void Or(Boolean exp, String a, String b) {
			instance.A = a;
			instance.B = b;
			Assert.Equal(exp, instance.Or());
		}

		[Theory]
		[InlineData(false, "", "")]
		[InlineData(true, null, "")]
		[InlineData(true, "", null)]
		[InlineData(true, null, null)]
		public void ShortCircuitOr(Boolean exp, String a, String b) {
			instance.A = a;
			instance.B = b;
			Assert.Equal(exp, instance.ShortCircuitOr());
		}
	}
}
