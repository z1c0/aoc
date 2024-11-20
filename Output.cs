using System;
using System.Collections.Generic;

namespace aoc
{
	public static class Output
	{
		public static void Print<T>(IEnumerable<T> list) =>
			Console.WriteLine($"[{string.Join(", ", list)}]");
	}
}
