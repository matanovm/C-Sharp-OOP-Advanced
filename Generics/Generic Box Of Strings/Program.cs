using System;

namespace Generic_Box_Of_Strings
{
	public class Program
	{
		static void Main(string[] args)
		{
			int n;
			while (true)
			{
				string s = Console.ReadLine();
				bool success = int.TryParse(s, out n);
				if (success)
				{
					for (int i = 0; i < n; i++)
					{
						int value = int.Parse(Console.ReadLine());
						Box<int> box = new Box<int>(value);

						Console.WriteLine(box.ToString());
					}
				}
				else
				{
					Console.WriteLine("Integer number expected.");
				}
			}
		}
	}
}
