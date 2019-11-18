using System;
using BenchmarkDotNet.Running;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;

namespace Random_Benchmarks {
	public static class Program {
		public static void Main() {
			Theme.DefaultDark.Apply();

			while (true) {
				Console.WriteChoices(Choices);
				Console.ReadChoice(Choices);
			}
		}

		internal readonly static KeyChoiceSet Choices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, nameof(DynamicDispatchOverhead), () => BenchmarkRunner.Run<DynamicDispatchOverhead>()),
				new KeyChoice(ConsoleKey.D2, nameof(DispatchApproaches), () => BenchmarkRunner.Run<DispatchApproaches>()),
				new KeyChoice(ConsoleKey.D3, nameof(HasFlagApproaches), () => BenchmarkRunner.Run<HasFlagApproaches>()),
				new KeyChoice(ConsoleKey.D4, nameof(NullArgChecking), () => BenchmarkRunner.Run<NullArgChecking>()),
				new KeyChoice(ConsoleKey.D5, nameof(VectorMath), () => BenchmarkRunner.Run<VectorMath>()),
				new BackKeyChoice(ConsoleKey.Q, "Quit", () => Environment.Exit(0)));
	}
}
