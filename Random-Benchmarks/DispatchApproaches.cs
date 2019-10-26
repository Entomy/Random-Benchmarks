using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Random_Benchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	public class DispatchApproaches {

		A Object = new C();

		[Benchmark]
		public void VirtualTableCall() => Object.Method();

		[Benchmark]
		public void PatternMatchCall() => PatternMatch(Object);

		[Benchmark]
		public void TagSwitchCall() => TagSwitch(Object);

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


		private enum Tag { B, C }

		private abstract class A {
			internal readonly Tag Tag;

			internal A(Tag tag) => Tag = tag;

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
