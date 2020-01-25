using System;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class VectorMath {
		// This does UInt16 vectors just because I needed the specific numbers. It still shows off how much faster the vector unit is, regardless.

		public UInt16[] Array = new UInt16[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

		public Vector<UInt16> Vector;

		[Benchmark]
		public void CreateArray() => Array = new UInt16[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

		[Benchmark]
		public void CreateVector() => Vector = new Vector<UInt16>(Array);

		[Benchmark]
		public Int32[] AddArray() {
			Int32[] Result = new Int32[Array.Length];
			for (UInt16 i = 0; i < Result.Length; i++) {
				Result[i] = Array[i] + Array[i];
			}
			return Result;
		}

		[Benchmark]
		public Vector<UInt16> AddVector() => Vector + Vector;

		[Benchmark]
		public Boolean EqualsArray() {
			Boolean Result = true;
			for (UInt16 i = 0; i < Array.Length; i++) {
				Result &= Array[i] == Array[i];
			}
			return Result;
		}

		[Benchmark]
		public Boolean EqualsVector() => Vector == Vector;
	}
}
