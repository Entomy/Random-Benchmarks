using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class HasFlagApproaches {

		RegexOptions Options = RegexOptions.IgnoreCase | RegexOptions.RightToLeft | RegexOptions.Singleline;

		[Benchmark(Baseline = true)]
		[SuppressMessage("Performance", "RCS1096:Use bitwise operation instead of calling 'HasFlag'.", Justification = "We're benchmarking code.")]
		public Boolean HasFlag() => Options.HasFlag(RegexOptions.RightToLeft);

		/// <summary>
		/// Roslynator alleges this is faster. They are correct. No idea what Microsoft is doing.
		/// </summary>
		/// <see cref="https://github.com/JosefPihrt/Roslynator/blob/master/docs/analyzers/RCS1096.md"/>
		[Benchmark]
		public Boolean Bitwise() => (Options & RegexOptions.RightToLeft) != 0;
	}
}
