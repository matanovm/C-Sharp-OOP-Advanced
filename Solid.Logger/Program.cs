using Solid.Logger.Core;
using Solid.Logger.Core.Contracts;

namespace Logger
{
	class Program
	{
		static void Main(string[] args)
		{
			ICommandInterpreter commandInterpreter = new CommandInterpreter();
			IEngine engine = new Engine(commandInterpreter);
			engine.Run();
		}
	}
}
