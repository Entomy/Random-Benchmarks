using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp50)]
	[SimpleJob(RuntimeMoniker.CoreRt50)]
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class LoopVariations {
		[Params(new Int32[] { 52, 63, 88, 67, 63, 31, 61, 45, 18, 77, 10, 86, 84, 86, 79, 67, 96, 29, 66, 22, 69, 57, 76, 23, 11, 3, 34, 62, 41, 11, 49, 67, 33, 26, 41, 48, 89, 5, 93, 29, 22, 55, 73, 27, 62, 33, 46, 70, 10, 87, 18, 46, 92, 66, 80, 36, 79, 90, 24, 94, 34, 42, 66, 54, 7, 56, 59, 70, 32, 36, 48, 20, 96, 78, 85, 49, 23, 95, 16, 61, 43, 25, 49, 10, 31, 19, 28, 61, 61, 85, 99, 93, 53, 72, 62, 29, 53, 96, 39, 43, 71, 56, 40, 55, 12, 83, 68, 73, 43, 85, 5, 72, 78, 75, 81, 37, 84, 81, 48, 21, 40, 15, 95, 96, 23, 90, 35, 72, 33, 87, 71, 11, 27, 14, 30, 22, 33, 76, 80, 59, 32, 94, 26, 67, 91, 15, 49, 96, 85, 93, 83, 2, 30, 84, 78, 100, 82, 35, 19, 43, 58, 97, 89, 63, 87, 40, 86, 19, 4, 28, 94, 51, 77, 23, 30, 34, 95, 6, 71, 90, 46, 43, 80, 65, 5, 60, 90, 30, 53, 57, 78, 90, 90, 16, 38, 15, 76, 88, 72, 16, 74, 59, 3, 44, 68, 86, 95, 60, 83, 84, 11, 26, 38, 57, 70, 24, 22, 70, 70, 74, 42, 56, 94, 31, 65, 2, 72, 17, 6, 4, 3, 19, 4, 6, 92, 10, 82, 77, 89, 67, 40, 13, 80, 92, 31, 54, 4, 66, 67, 81, 89, 67, 38, 15, 59, 13, 31, 40, 76, 19, 40, 20, 84, 30, 39, 37, 72, 31, 85, 23, 83, 89, 86, 43, 96, 18, 41, 25, 61, 96, 82, 65, 65, 99, 12, 65, 12, 96, 13, 27, 91, 60, 96, 76, 23, 23, 82, 46, 86, 75, 5, 95, 89, 92, 99, 96, 76, 65, 86, 69, 40, 63, 4, 65, 65, 51, 39, 48, 44, 46, 84, 33, 85, 54, 12, 50, 80, 40, 51, 21, 20, 85, 68, 81, 63, 85, 42, 77, 31, 6, 86, 75, 36, 37, 97, 82, 61, 86, 45, 21, 62, 70, 69, 49, 14, 9, 62, 87, 57, 82, 18, 53, 20, 56, 20, 10, 24, 15, 18, 76, 85, 34, 22, 79, 80, 91, 60, 42, 86, 13, 13, 51, 21, 34, 86, 14, 6, 37, 15, 98, 42, 39, 2, 88, 72, 26, 40, 52, 23, 58, 20, 7, 32, 52, 21, 36, 1, 86, 87, 57, 88, 76, 61, 3, 28, 61, 6, 57, 30, 54, 49, 84, 5, 67, 42, 33, 31, 17, 56, 24, 70, 33, 87, 79, 95, 29, 83, 100, 37, 29, 43, 82, 44, 76, 67, 97, 5, 82, 49, 26, 66, 26, 8, 80, 36, 93, 55, 4, 41, 50, 97, 42, 74, 28, 96, 33, 29, 54, 35, 70, 93, 71, 97, 33, 57, 78, 49, 50, 45, 6, 64, 53, 29, 78, 27, 74, 95, 53, 19, 41, 60, 24, 55, 93, 53, 57, 46, 49, 51, 8, 98, 22, 61, 82, 20, 31, 39, 35, 88, 28, 34, 62, 10, 83, 9, 70, 49, 69, 43, 70, 34, 37, 21, 40, 43, 67, 99, 62, 84, 57, 19, 42, 77, 96, 20, 66, 24, 77, 25, 85, 44, 49, 36, 40, 29, 59, 19, 29, 67, 85, 82, 61, 77, 11, 11, 48, 81, 71, 14, 9, 96, 38, 73, 91, 21, 94, 55, 10, 76, 4, 2, 61, 68, 91, 21, 5, 58, 85, 36, 30, 29, 18, 67, 21, 26, 83, 80, 84, 8, 48, 35, 25, 94, 41, 69, 54, 42, 64, 77, 16, 1, 8, 84, 3, 25, 34, 76, 58, 89, 59, 12, 76, 97, 17, 41, 54, 54, 5, 29, 73, 12, 82, 32, 3, 74, 26, 82, 3, 62, 23, 64, 96, 15, 70, 87, 94, 50, 94, 22, 42, 58, 10, 52, 12, 59, 1, 22, 7, 24, 64, 98, 54, 33, 17, 83, 33, 20, 20, 67, 85, 81, 66, 89, 19, 58, 74, 36, 50, 71, 42, 92, 84, 72, 23, 46, 16, 82, 35, 77, 45, 11, 8, 3, 95, 6, 16, 15, 5, 65, 31, 81, 83, 85, 5, 98, 2, 26, 3, 2, 56, 43, 24, 7, 38, 34, 72, 65, 14, 40, 71, 20, 44, 76, 21, 86, 71, 4, 67, 11, 54, 36, 81, 41, 66, 40, 67, 85, 83, 3, 54, 97, 52, 45, 88, 95, 36, 11, 35, 25, 42, 51, 94, 62, 57, 61, 73, 60, 42, 16, 17, 28, 20, 100, 5, 46, 65, 91, 68, 52, 66, 64, 70, 70, 79, 98, 23, 40, 17, 9, 73, 63, 62, 17, 91, 81, 86, 27, 34, 44, 27, 80, 94, 49, 32, 59, 22, 85, 13, 13, 23, 87, 7, 33, 86, 21, 67, 33, 63, 46, 86, 86, 44, 31, 67, 66, 65, 42, 64, 70, 21, 77, 36, 34, 3, 74, 16, 50, 46, 87, 70, 44, 77, 44, 11, 51, 49, 96, 16, 83, 52, 37, 65, 80, 18, 55, 18, 62, 61, 37, 25, 12, 3, 26, 44, 14, 98, 4, 84, 78, 21, 87, 50, 95, 38, 48, 42, 28, 39, 86, 26, 86, 78, 4, 21, 85, 69, 86, 58, 93, 22, 23, 55, 36, 10, 99, 95, 28, 7, 85, 4, 71, 16, 77, 70, 17, 61, 59, 58, 51, 36, 10, 55, 35, 30, 76, 34, 78, 81, 40, 49, 6, 56, 92, 86, 11, 60, 37, 20, 51, 55, 51, 95, 32, 82, 93, 71, 10, 6, 27, 2, 10, 87, 17, 75, 56, 87, 33, 59, 37, 37, 94, 44, 81, 40, 39, 74, 33, 3, 22, 5, 74, 26, 33, 99, 28, 16, 8, 20, 71, 38, 54, 16, 24, 7, 97, 4, 87, 80, 65, 74, 15, 73, 40, 46, 74, 42, 40, 95, 93, 94, 33, 55, 41, 50, 67, 97, 74, 58, 100, 7, 57, 42, 13, 94, 17, 98, 91, 5, 39, 19, 99, 78, 78, 82, 24, 32, 69, 18, 91, 20, 39, 15, 41, 38, 54, 94, 87, 22, 82, 87, 33, 44, 73, 28, 44, 60, 48, 84, 49, 42, 63, 50, 94, 25 })]
		public Int32[] Array { get; set; }

		[Params(1000)]
		public Int32 I { get; set; }

		[Params(1000)]
		public UInt32 U { get; set; }

		[Params(1)]
		public Int32 X { get; set; }

		[Params(2)]
		public Int32 Y { get; set; }

		[Benchmark]
		public void Clone_For_int() {
			for (int i = 0; i < I; i++) { Array[i] = X; }
		}

		[Benchmark]
		public void Clone_For_long() {
			for (long i = 0; i < I; i++) { Array[i] = X; }
		}

		[Benchmark]
		public void Clone_For_nint() {
			for (nint i = 0; i < I; i++) { Array[i] = X; }
		}

		[Benchmark]
		public void Clone_For_nuint() {
			for (nuint i = 0; i < U; i++) { Array[i] = X; }
		}

		[Benchmark]
		public void Clone_For_short() {
			for (short i = 0; i < I; i++) { Array[i] = X; }
		}

		[Benchmark]
		public void Clone_For_uint() {
			for (uint i = 0; i < I; i++) { Array[i] = X; }
		}

		[Benchmark]
		public void Clone_For_ulong() {
			for (ulong i = 0; i < U; i++) { Array[i] = X; }
		}

		[Benchmark]
		public void Clone_For_ushort() {
			for (ushort i = 0; i < I; i++) { Array[i] = X; }
		}

		[Benchmark]
		public void Clone_Hoist_For_int() {
			for (int i = 0; i < I; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void Clone_Hoist_For_long() {
			for (long i = 0; i < I; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void Clone_Hoist_For_nint() {
			for (nint i = 0; i < I; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void Clone_Hoist_For_nuint() {
			for (nuint i = 0; i < U; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void Clone_Hoist_For_short() {
			for (short i = 0; i < I; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void Clone_Hoist_For_uint() {
			for (uint i = 0; i < I; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void Clone_Hoist_For_ulong() {
			for (ulong i = 0; i < U; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void Clone_Hoist_For_ushort() {
			for (ushort i = 0; i < I; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void Empty_For_int() {
			for (int i = 0; i < I; i++) { }
		}

		[Benchmark]
		public void Empty_For_long() {
			for (long i = 0; i < I; i++) { }
		}

		[Benchmark]
		public void Empty_For_nint() {
			for (nint i = 0; i < I; i++) { }
		}

		[Benchmark]
		public void Empty_For_nuint() {
			for (nuint i = 0; i < U; i++) { }
		}

		[Benchmark]
		public void Empty_For_short() {
			for (short i = 0; i < I; i++) { }
		}

		[Benchmark]
		public void Empty_For_uint() {
			for (uint i = 0; i < I; i++) { }
		}

		[Benchmark]
		public void Empty_For_ulong() {
			for (ulong i = 0; i < U; i++) { }
		}

		[Benchmark]
		public void Empty_For_ushort() {
			for (ushort i = 0; i < I; i++) { }
		}

		[Benchmark]
		public void NoCloneByComputedBoundary_Hoist_For_int() {
			for (int i = 0; i < I + 1; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void NoCloneByComputedBoundary_Hoist_For_long() {
			for (long i = 0; i < I + 1; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void NoCloneByComputedBoundary_Hoist_For_nint() {
			for (nint i = 0; i < I + 1; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void NoCloneByComputedBoundary_Hoist_For_nuint() {
			for (nuint i = 0; i < U + 1; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void NoCloneByComputedBoundary_Hoist_For_short() {
			for (short i = 0; i < I + 1; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void NoCloneByComputedBoundary_Hoist_For_uint() {
			for (uint i = 0; i < I + 1; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void NoCloneByComputedBoundary_Hoist_For_ulong() {
			for (ulong i = 0; i < U + 1; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void NoCloneByComputedBoundary_Hoist_For_ushort() {
			for (ushort i = 0; i < I + 1; i++) { Array[i] = X + Y; }
		}

		[Benchmark]
		public void NoCloneByTryCatch_Hoist_For_int() {
			for (int i = 0; i < I + 1; i++) { try { Array[i] = X + Y; } catch { } }
		}

		[Benchmark]
		public void NoCloneByTryCatch_Hoist_For_long() {
			for (long i = 0; i < I + 1; i++) { try { Array[i] = X + Y; } catch { } }
		}

		[Benchmark]
		public void NoCloneByTryCatch_Hoist_For_nint() {
			for (nint i = 0; i < I + 1; i++) { try { Array[i] = X + Y; } catch { } }
		}

		[Benchmark]
		public void NoCloneByTryCatch_Hoist_For_nuint() {
			for (nuint i = 0; i < U + 1; i++) { try { Array[i] = X + Y; } catch { } }
		}

		[Benchmark]
		public void NoCloneByTryCatch_Hoist_For_short() {
			for (short i = 0; i < I + 1; i++) { try { Array[i] = X + Y; } catch { } }
		}

		[Benchmark]
		public void NoCloneByTryCatch_Hoist_For_uint() {
			for (uint i = 0; i < I + 1; i++) { try { Array[i] = X + Y; } catch { } }
		}

		[Benchmark]
		public void NoCloneByTryCatch_Hoist_For_ulong() {
			for (ulong i = 0; i < U + 1; i++) { try { Array[i] = X + Y; } catch { } }
		}

		[Benchmark]
		public void NoCloneByTryCatch_Hoist_For_ushort() {
			for (ushort i = 0; i < I + 1; i++) { try { Array[i] = X + Y; } catch { } }
		}
	}
}
