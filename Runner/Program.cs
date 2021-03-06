﻿using System;
using BenchmarkDotNet.Running;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;

namespace RandomBenchmarks {
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
			new KeyChoice(ConsoleKey.D3, nameof(FormatPhoneNumber), () => BenchmarkRunner.Run<FormatPhoneNumber>()),
			new KeyChoice(ConsoleKey.D4, nameof(HasFlagApproaches), () => BenchmarkRunner.Run<HasFlagApproaches>()),
			new KeyChoice(ConsoleKey.D5, nameof(LoopVariations), () => BenchmarkRunner.Run<LoopVariations>()),
			new KeyChoice(ConsoleKey.D6, nameof(MethodSelection), () => BenchmarkRunner.Run<MethodSelection>()),
			new KeyChoice(ConsoleKey.D7, nameof(MemberAccess), () => BenchmarkRunner.Run<MemberAccess>()),
			new KeyChoice(ConsoleKey.D8, nameof(NullableEqualityChecking), () => BenchmarkRunner.Run<NullableEqualityChecking>()),
			new KeyChoice(ConsoleKey.D9, nameof(NullableOverhead), () => BenchmarkRunner.Run<NullableOverhead>()),
			new KeyChoice(ConsoleKey.A, nameof(NullArgChecking), () => BenchmarkRunner.Run<NullArgChecking>()),
			new KeyChoice(ConsoleKey.B, nameof(ReturnConstruction), () => BenchmarkRunner.Run<ReturnConstruction>()),
			new KeyChoice(ConsoleKey.C, nameof(UnicodeNormalization), () => BenchmarkRunner.Run<UnicodeNormalization>()),
			new KeyChoice(ConsoleKey.D, nameof(VectorMath), () => BenchmarkRunner.Run<VectorMath>()),
			new KeyChoice(ConsoleKey.E, nameof(WithinSignedRange), () => BenchmarkRunner.Run<WithinSignedRange>()),
			new KeyChoice(ConsoleKey.F, nameof(WithinUnsignedRange), () => BenchmarkRunner.Run<WithinUnsignedRange>()),
			new KeyChoice(ConsoleKey.G, nameof(WrapperOverhead), () => BenchmarkRunner.Run<WrapperOverhead>()),
			new BackKeyChoice(ConsoleKey.Q, "Quit", () => Environment.Exit(0)));
	}
}
