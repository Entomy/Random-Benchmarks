using System;
using BenchmarkDotNet.Running;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;

namespace Random_Benchmarks {
	public static class Program {
		static Program() {
			Theme.DefaultDark.Apply();
		}

		public static void Main() {
			Console.WriteChoices(Choices);
			Console.ReadChoice(Choices);
		}

		internal static KeyChoiceSet Choices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, nameof(DynamicDispatchOverhead), DynamicDispatchOverheadChoice),
				new KeyChoice(ConsoleKey.D2, nameof(DispatchApproaches), DispatchApproachesChoice),
				new KeyChoice(ConsoleKey.D3, nameof(VectorMath), VectorMathChoice),
				new BackKeyChoice(ConsoleKey.Q, "Quit", () => Environment.Exit(0)));


		internal static void DynamicDispatchOverheadChoice() {
			BenchmarkRunner.Run<DynamicDispatchOverhead>();
			Main();
		}

		internal static void DispatchApproachesChoice() {
			BenchmarkRunner.Run<DispatchApproaches>();
			Main();
		}

		internal static void VectorMathChoice() {
			BenchmarkRunner.Run<VectorMath>();
			Main();
		}
	}
}
