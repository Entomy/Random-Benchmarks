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
	public class DispatchApproaches {
		private static readonly A Object = new C();

		private enum Tag { B, C }

		[Benchmark]
		public Int32 GenericCall() => Generic(Object);

		[Benchmark]
		public Int32 PatternMatchCall() => PatternMatch(Object);

		[Benchmark]
		public Int32 TagSwitchCall() => TagSwitch(Object);

		[Benchmark]
		public Int32 VirtualTableCall() => Object.Method();

		private static Int32 Generic<T>(T obj) where T : A => obj.Method();

		private static Int32 PatternMatch(A a) {
			switch (a) {
			case B b:
				return 1 + 2;
			case C c:
				return 2 + 3;
			default:
				throw new NotImplementedException();
			}
		}

		private static Int32 TagSwitch(A a) {
			switch (a.Tag) {
			case Tag.B:
				return 1 + 2;
			case Tag.C:
				return 2 + 3;
			default:
				throw new NotImplementedException();
			}
		}

		private abstract class A {
			internal readonly Tag Tag;

			protected A(Tag tag) => Tag = tag;

			/// <summary>
			/// Dynamically dispatching call
			/// </summary>
			internal abstract Int32 Method();
		}

		private sealed class B : A {
			internal B() : base(Tag.B) { }

			// Statically dispatching call
			internal sealed override Int32 Method() => 1 + 2;
		}

		private sealed class C : A {
			internal C() : base(Tag.C) { }

			// Statically dispatching call
			internal sealed override Int32 Method() => 2 + 3;
		}
	}
}
