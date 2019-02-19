using Solid.Logger.Core.Contracts;
using System;

namespace Solid.Logger.Core
{
	public class Engine : IEngine
	{
		private ICommandInterpreter commandInterpreter;

		public Engine(ICommandInterpreter comandInterpreter)
		{
			this.commandInterpreter = comandInterpreter;
	    }

		public void Run()
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string[] inputArgs = Console.ReadLine().Split();
				this.commandInterpreter.AddAppender(inputArgs);
			}

			string input = Console.ReadLine();

			while (input != "END")
			{
				string[] inputArgs = input.Split('|');
				this.commandInterpreter.AddMessage(inputArgs);

				input = Console.ReadLine();
			}

			this.commandInterpreter.PrintInfo();
		}		
	}
}
