using System.Collections.Generic;
using System.Linq;

namespace aoc;

public static class Extensions
{
	public static T RemoveFirst<T>(this HashSet<T> hashSet)
	{
		var t = hashSet.First();
		hashSet.Remove(t);
		return t;
	}

	public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
	{
		foreach (var t in items)
		{
			hashSet.Add(t);
		}
	}
}