﻿namespace Logger.Appenders
{
	using System;
	using Layouts.Contracts;
	using Solid.Logger.Appenders;
	using Solid.Logger.Loggers;


	public class ConsoleAppender : Appender
	{
		public ConsoleAppender(ILayout layout)
			: base(layout)
		{
		}

		public override void Append(string dateTime, ReportLevel reportLevel, string message)
		{
			if (reportLevel >= this.ReportLevel)
			{
				this.MessegesCount++;
				Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
			}
		}

		public override string ToString()
		{
			return $"Appender type:{this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
				$"Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended:" +
				   $" {this.MessegesCount}";
		}
	}
}
