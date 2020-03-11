using System;
using RandomBenchmarks;
using Xunit;

namespace Tests {
	public class FormatPhoneNumberTests {
		FormatPhoneNumber instance = new FormatPhoneNumber();

		[Fact]
		public void ByLoop() {
			instance.Source = "5555555555";
			Assert.Equal("(555) 555-5555", instance.ByLoop());
		}

		[Fact]
		public void ByRegex() {
			instance.Source = "5555555555";
			Assert.Equal("(555) 555-5555", instance.ByRegex());
		}
	}
}
