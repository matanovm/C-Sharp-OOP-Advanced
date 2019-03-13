namespace Logger.Appenders
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
			if (dateTime == null)
			{
				throw new ArgumentNullException(nameof(dateTime));
			}

			if (message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}

			else if (reportLevel >= this.ReportLevel)
			{
				this.MessegesCount++;
				Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
			}
		}

		public override string ToString()
		{
			string Appender = this.GetType().Name;
			string Layout = this.Layout.GetType().Name;
			string ReportLevel = this.ReportLevel.ToString().ToUpper();
			int Messeges = this.MessegesCount;

			return $"Appender type:{Appender}, Layout type: {Layout}, " +
				$"Report level: {ReportLevel}, Messages appended:" +
				   $" {Messeges}";
		}
	}
}
