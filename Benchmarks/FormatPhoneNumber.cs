using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class FormatPhoneNumber {
		[Params("5555555555")]
		public String Source { get; set; }

		[Benchmark]
		public String ByLoop() {
			Char[] result = new Char[Source.Length + 4];
			Int32 s = 0;
			for (Int32 r = 0; r < result.Length; r++) {
				if (r == 0) {
					result[r] = '(';
				} else if (r == 4) {
					result[r] = ')';
				} else if (r == 5) {
					result[r] = ' ';
				} else if (r == 9) {
					result[r] = '-';
				} else {
					result[r] = Source[s++];
				}
			}
			return new String(result);
		}

		[Benchmark]
		public String ByRegex() {
			Regex regex = new Regex(@"(\d{3})(\d{3})(\d{4})");
			Match match = regex.Match(Source);
			GroupCollection groups = match.Groups;
			return $"({groups[1]}) {groups[2]}-{groups[3]}";
		}
	}
}
