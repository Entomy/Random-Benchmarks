﻿using System;
using RandomBenchmarks;
using Xunit;

namespace Tests {
	public class WithinSignedRangeTests {
		WithinSignedRange instance = new WithinSignedRange();

		[Theory]
		[InlineData(true, 10, 1, 100)]
		[InlineData(true, 80, 1, 100)]
		[InlineData(false, 500, 1, 100)]
		[InlineData(false, 10, 30, 100)]
		[InlineData(true, 80, 30, 100)]
		[InlineData(false, 500, 30, 100)]
		[InlineData(true, 10, 1, 40)]
		[InlineData(false, 80, 1, 40)]
		[InlineData(false, 500, 1, 40)]
		[InlineData(false, 10, 30, 40)]
		[InlineData(false, 80, 30, 40)]
		[InlineData(false, 500, 30, 40)]
		[InlineData(true, 10, 1, 600)]
		[InlineData(true, 80, 1, 600)]
		[InlineData(true, 500, 1, 600)]
		[InlineData(false, 10, 30, 600)]
		[InlineData(true, 80, 30, 600)]
		[InlineData(true, 500, 30, 600)]
		public void Naive(Boolean exp, Int32 actual, Int32 lower, Int32 upper) {
			instance.Actual = actual;
			instance.Lower = lower;
			instance.Upper = upper;
			Assert.Equal(exp, instance.Naive());
		}

		[Theory]
		[InlineData(true, 10, 1, 100)]
		[InlineData(true, 80, 1, 100)]
		[InlineData(false, 500, 1, 100)]
		[InlineData(false, 10, 30, 100)]
		[InlineData(true, 80, 30, 100)]
		[InlineData(false, 500, 30, 100)]
		[InlineData(true, 10, 1, 40)]
		[InlineData(false, 80, 1, 40)]
		[InlineData(false, 500, 1, 40)]
		[InlineData(false, 10, 30, 40)]
		[InlineData(false, 80, 30, 40)]
		[InlineData(false, 500, 30, 40)]
		[InlineData(true, 10, 1, 600)]
		[InlineData(true, 80, 1, 600)]
		[InlineData(true, 500, 1, 600)]
		[InlineData(false, 10, 30, 600)]
		[InlineData(true, 80, 30, 600)]
		[InlineData(true, 500, 30, 600)]
		public void Arithmetic(Boolean exp, Int32 actual, Int32 lower, Int32 upper) {
			instance.Actual = actual;
			instance.Lower = lower;
			instance.Upper = upper;
			Assert.Equal(exp, instance.Arithmetic());
		}
	}
}
