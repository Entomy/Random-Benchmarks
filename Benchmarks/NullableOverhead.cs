﻿using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp50)]
	[SimpleJob(RuntimeMoniker.CoreRt50)]
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class NullableOverhead {
		[Benchmark]
		public Int32 ValueType() => 1;

		[Benchmark]
		public Int32? NullableValueType() => new Int32?(1);
	}
}
