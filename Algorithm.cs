using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace aoc
{
	public static class Algorithm
	{
		public static long LowestCommonMultiple(IEnumerable<int> numbers)
		{
			static long CalculateLCM(long a, long b) => (a * b) / CalculateGCD(a, b);

			static long CalculateGCD(long a, long b)
			{
				while (b != 0)
				{
					var temp = b;
					b = a % b;
					a = temp;
				}
				return a;
			}

			long lcm = numbers.First();
			foreach (var n in numbers.Skip(1))
			{
				lcm = CalculateLCM(lcm, n);
			}
			return lcm;
		}
	}
}
