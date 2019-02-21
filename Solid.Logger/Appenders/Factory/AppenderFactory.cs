using Logger.Appenders;
using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Solid.Logger.Appenders.Factory.Contracts;
using Solid.Logger.Appernders;
using Solid.Logger.Loggers;
using System;

namespace Solid.Logger.Appenders.Factory
{
	public class AppenderFactory : IAppenderFactory
	{
		public IAppender CreateAppender(string type, ILayout layout)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			if (layout == null)
			{
				throw new ArgumentNullException(nameof(layout));
			}

			string typeAsLowerCase = type.ToLower();

			switch (typeAsLowerCase)
			{
				case "consoleappender":
					return new ConsoleAppender(layout);
				case "fileappender":
					return new FileAppender(layout, new LogFile());
				default:
					throw new ArgumentException("Invalid argument type.");
			}
		}
	}
}
