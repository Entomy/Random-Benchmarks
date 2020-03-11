using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class DynamicDispatchOverhead {
		[Benchmark]
		public void StaticCall() => Static.Method();

		Dynamic dynamic = new DynamicActual();

		[Benchmark]
		public void DynamicCall() => dynamic.Method();

		private static class Static {
			internal static void Method() { }
		}

		private abstract class Dynamic {
			internal abstract void Method();
		}

		private sealed class DynamicActual : Dynamic {
			internal override void Method() { }
		}

	}
}
