using System;
using System.Collections.Generic;

namespace Generic_Count_Method_Doubles
{
	public class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			List<double> messages = new List<double>();

			for (int i = 0; i < n; i++)
			{
				double message = double.Parse(Console.ReadLine());
				messages.Add(message);
			}

			double element = double.Parse(Console.ReadLine());

			Box<double> box = new Box<double>(messages);
			int result = box.GetGreaterthan(element);
			Console.WriteLine(result);
		}
	}
}
