using System;
using System.Text;

namespace aoc
{
	class Program
	{
		static void Main()
		{
			var grid = Grid.FromFile("input.txt");
			Console.WriteLine($"Width: {grid.Width}, Height: {grid.Height}");
            Console.WriteLine();
            // Print to console
			grid.Print();
            Console.WriteLine();
            // Print to StringBuilder
            var sb = new StringBuilder();
            grid.PrintTo(sb);
            Console.WriteLine(sb);
            Console.WriteLine();
            // Clone
            var grid2 = grid.Clone();
            grid2.Print();
            Console.WriteLine();
            // CountDistinct
            foreach (var c in grid.CountDistinct())
            {
                Console.WriteLine($"'{c.Key}': {c.Value}");
            }
            Console.WriteLine();
            // Count
            Console.WriteLine($"count '#': {grid.Count('#')}");
            Console.WriteLine($"count 'x': {grid.Count('x')}");
            Console.WriteLine();
            // Fill
            grid2.Fill('x');
            grid2.Print();
            Console.WriteLine();
            // Indexing
            grid2[0, 0] = '*';
            grid2[0, 4] = '+';
            grid2.Print();
            Console.WriteLine();
            // CountAdjacent4Distinct
            foreach (var c in grid.CountAdjacent4Distinct(1, 1))
            {
                Console.WriteLine($"'{c.Key}': {c.Value}");
            }
            Console.WriteLine();
            // CountAdjacent8Distinct
            foreach (var c in grid.CountAdjacent8Distinct(1, 1))
            {
                Console.WriteLine($"'{c.Key}': {c.Value}");
            }
            Console.WriteLine();
            // CountAdjacent4
            Console.WriteLine($"{grid.CountAdjacent4(1, 1, '#')}");
            Console.WriteLine();
            // CountAdjacent8
            Console.WriteLine($"{grid.CountAdjacent8(1, 1, '#')}");
            Console.WriteLine();
            // IsInBounds
            Console.WriteLine($"1/1 in bounds: {grid.IsInBounds(1, 1)}");
            Console.WriteLine($"1/10 in bounds: {grid.IsInBounds(1, 10)}");
            Console.WriteLine();
            // Find (first occurrence)
            Console.WriteLine(grid.Find('.'));
            // Count (all matches)
            Console.WriteLine(grid.Count(c => c == '#'));
		}
	}
}

