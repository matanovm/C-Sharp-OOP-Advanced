using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Solid.Logger.Appenders;
using Solid.Logger.Loggers;
using Solid.Logger.Loggers.Contracts;
using System.IO;

namespace Solid.Logger.Appernders
{
	public class FileAppender : Appender
	{
		private const string path = @"D:\GitHub_Repository\C_Sharp_OOP_Advanced\Solid\log.txt";

		private readonly ILogFile logFile;

		public FileAppender(ILayout layout, ILogFile logFile)
			:base(layout)
		{
			this.logFile = logFile;
		}

		public override void Append(string dateTime, ReportLevel reportLevel, string message)
		{
			if (reportLevel >= ReportLevel)
			{
				this.MessegesCount++;
				string content = string.Format(this.Layout.Format, dateTime, reportLevel, message)+
					"\n";
				this.logFile.Write(content);
				File.AppendAllText(path, content);
			}
		}

		public override string ToString()
		{
			return $"Appender type:{this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
				$"Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended:" +
				   $" {this.MessegesCount}, File size:{this.logFile.Size} ";
		}
	}
}
