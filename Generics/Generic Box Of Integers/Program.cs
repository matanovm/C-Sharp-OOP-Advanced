﻿using System;

namespace Generic_Box_Of_Integers
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));

				Console.WriteLine(box.ToString());
			}
		}
	}
}
