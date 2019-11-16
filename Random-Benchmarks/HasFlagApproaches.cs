using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Random_Benchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	public class HasFlagApproaches {

		RegexOptions Options = RegexOptions.IgnoreCase | RegexOptions.RightToLeft | RegexOptions.Singleline;

		[Benchmark(Baseline = true)]
		public Boolean HasFlag() => Options.HasFlag(RegexOptions.RightToLeft);

		/// <summary>
		/// Roslynator alleges this is faster
		/// </summary>
		/// <see cref="https://github.com/JosefPihrt/Roslynator/blob/master/docs/analyzers/RCS1096.md"/>
		/// <returns></returns>
		[Benchmark]
		public Boolean Bitwise() => (Options & RegexOptions.RightToLeft) != 0;
	}
}
