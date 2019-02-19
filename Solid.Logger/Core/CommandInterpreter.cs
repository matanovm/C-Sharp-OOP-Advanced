﻿using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Solid.Logger.Appenders.Factory;
using Solid.Logger.Appenders.Factory.Contracts;
using Solid.Logger.Core.Contracts;
using Solid.Logger.Layouts.Factory;
using Solid.Logger.Layouts.Factory.Contracts;
using Solid.Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Core
{
	public class CommandInterpreter : ICommandInterpreter
	{
		private ICollection<IAppender> appenders;
		private IAppenderFactory appenderFactory;
		private ILayoutFactory layoutFactory;

		public CommandInterpreter()
		{
			this.appenders = new List<IAppender>();
			this.appenderFactory = new AppenderFactory();
			this.layoutFactory = new LayoutFactory();
		}

		public void AddAppender(string[] args)
		{
			string appenderType = args[0];
			string layoutType = args[1];
			ReportLevel reportLevel = ReportLevel.INFO;

			if (args.Length == 3)
			{
				reportLevel = Enum.Parse<ReportLevel>(args[2]);
			}

			ILayout layout = this.layoutFactory.CreateLayout(layoutType);
			IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);
			appender.ReportLevel = reportLevel;
			this.appenders.Add(appender);

		}

		public void AddMessage(string[] args)
		{
			ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
			string dateTime = args[1];
			string message = args[2];

			foreach (IAppender appender in appenders)
			{
				appender.Append(dateTime, reportLevel, message);
			}
		}

		public void PrintInfo()
		{
			Console.WriteLine("Logger Info");

			foreach (IAppender appender in appenders)
			{
				Console.WriteLine(appender);
			}
		}
	}

}	
