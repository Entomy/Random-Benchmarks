using System;
using RandomBenchmarks;
using Xunit;

namespace Tests {
	public class NullableEqualityCheckingTests {
		NullableEqualityChecking instance = new NullableEqualityChecking();

		[Theory]
		[InlineData(true, "", "")]
		[InlineData(false, "", null)]
		[InlineData(false, null, "")]
		[InlineData(true, null, null)]
		[InlineData(false, "", "oh no")]
		public void Naive(Boolean exp, String a, String b) {
			instance.A = a;
			instance.B = b;
			Assert.Equal(exp, instance.Naive());
		}

		[Theory]
		[InlineData(true, "", "")]
		[InlineData(false, "", null)]
		[InlineData(false, null, "")]
		[InlineData(true, null, null)]
		[InlineData(false, "", "oh no")]
		public void XorLead(Boolean exp, String a, String b) {
			instance.A = a;
			instance.B = b;
			Assert.Equal(exp, instance.XorLead());
		}
	}
}
