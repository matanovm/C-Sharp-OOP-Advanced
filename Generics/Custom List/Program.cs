using System;

namespace Custom_List
{
	class Program
	{
		static void Main(string[] args)
		{
			Engine engine = new Engine();

			string input;
			while ((input = Console.ReadLine()) != "END")
			{
				engine.CommandInterpreter(input);
			}
		}
	}
}
