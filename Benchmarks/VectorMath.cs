using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RandomBenchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class VectorMath {
		// This does UInt16 vectors just because I needed the specific numbers. It still shows off how much faster the vector unit is, regardless.

		public static UInt16[] Array = new UInt16[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

		public static String String = "Hello world";
		public static Vector<UInt16> StrVector;
		public static Vector<UInt16> Vector = new Vector<UInt16>(Array);
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "<Pending>")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1810:Initialize reference type static fields inline", Justification = "<Pending>")]
		static VectorMath() {
			UInt16[] ints = new UInt16[16];
			for (Int32 i = 0; i < String.Length; i++) {
				ints[i] = unchecked((UInt16)String[i]);
			}
			StrVector = new Vector<UInt16>(ints);
		}

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
		public void CreateArray() => Array = new UInt16[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

		[Benchmark]
		public void CreateVector() => Vector = new Vector<UInt16>(Array);

		[Benchmark]
		public void CreateVectorFromString() {
			StrVector = new Vector<UInt16>(new Converter(String).Units);
		}

		[Benchmark]
		public Boolean EqualsArray() {
			Boolean Result = true;
			for (UInt16 i = 0; i < Array.Length; i++) {
				Result &= Array[i] == Array[i];
			}
			return Result;
		}

		[Benchmark]
		public Boolean EqualsSpan() => String.AsSpan().Equals("Hello world".AsSpan(), StringComparison.Ordinal);

		[Benchmark]
		public Boolean EqualsVector() => Vector == Vector;

		[Benchmark]
		public Boolean NotEqualsVector() => Vector != StrVector;

		[StructLayout(LayoutKind.Explicit)]
		private struct Converter {
			[FieldOffset(0)] private Char[] chars;
			[FieldOffset(0)] private UInt16[] units;

			public Converter(String @string) {
				units = null;
				chars = new Char[16];
				@string.AsSpan().CopyTo(chars.AsSpan(0, @string.Length));
			}

			public Char[] Chars => chars;

			public UInt16[] Units => units;
		}
	}
}
