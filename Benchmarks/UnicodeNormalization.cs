using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp50)]
	[SimpleJob(RuntimeMoniker.CoreRt50)]
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class UnicodeNormalization {
		//! Don't read too much into these. There's different characteristics of each normalization form, resulting in exactly how they compare being different.

		// For readabilities sake, precomposed characters are implicit, combined characters are explicitly escaped.
		[Params("", "hello", "ça-va", "\u0063\u0327a-va", "Tiếng Việt", "Ti\u0065\u0301\u0302ng vi\u0065\u0302\u0323t", "Ti\u0065\u0302\u0301ng vi\u0065\u0323\u0302t")]
		public String Source { get; set; }

		[Benchmark]
		public String FormC() => Source.Normalize(NormalizationForm.FormC);

		[Benchmark]
		public String FormD() => Source.Normalize(NormalizationForm.FormD);

		[Benchmark]
		public String FormKC() => Source.Normalize(NormalizationForm.FormKC);

		[Benchmark]
		public String FormKD() => Source.Normalize(NormalizationForm.FormKD);
	}
}
