﻿using BenchmarkDotNet.Running;

namespace Random_Benchmarks {
	public static class Program {
		public static void Main() {
			BenchmarkRunner.Run<DynamicDispatchOverhead>();
		}
	}
}
