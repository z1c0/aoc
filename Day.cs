using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace aoc
{
	public enum Mode
	{
		Sample,
		Full
	}

	public static class Day
	{
		private static string? _expected1;
		private static string? _expected2;

		public static Mode Mode { get; set;	} = Mode.Full;

		public static void Expect<T1, T2>(T1? expected1, T2? expected2 = default)
		{
			_expected1 = expected1?.ToString();
			_expected2 = expected2?.ToString();
		}
		
		public static void Run<RET1, RET2>(Func<IEnumerable<string>, RET1>? part1, Func<IEnumerable<string>, RET2>? part2 = null) =>
			Run(Input.ReadStringList, part1, part2);

		public static void Run<INPUT, RET1, RET2>(Func<string, INPUT> readInput, Func<INPUT, RET1>? part1, Func<INPUT, RET2>? part2 = null)
		{
			var name = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
			string rootDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
			Console.WriteLine($"START {name}");
			var sw = Stopwatch.StartNew();
			var fileName = Path.Combine(rootDirectory, Mode == Mode.Full ? Input.DEFAULT_INPUT_FILENAME : Input.DEFAULT_SAMPLE_INPUT_FILENAME);
			var input = readInput(fileName);
			Invoke(part1, input, _expected1);
			Invoke(part2, input, _expected2);
			Console.WriteLine($"END (after {sw.Elapsed.TotalSeconds} seconds)");
		}

		private static void Invoke<INPUT, RET>(Func<INPUT, RET>? func, INPUT input, string? expected)
		{
			if (func != null)
			{
				try
				{
					var s = func(input)?.ToString();
					if (expected != null)
					{
						if (expected != s)
						{
							ConsoleEx.Error($"ERROR: expected '{expected}', actual '{s}'");
						}
						else
						{
							ConsoleEx.Success($"-> {s}");
						}
					}
					else
					{
						ConsoleEx.Info($"-> {s}");
					}
				}
				catch (Exception e)
				{
					ConsoleEx.Error($"ERROR: {e}");
				}
			}
		}
	}
}