using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Solid.Logger.Loggers;

namespace Solid.Logger.Appenders
{
	public abstract class Appender : IAppender
	{
		private readonly ILayout _layout;

		protected Appender(ILayout layout)
		{
			_layout = layout;
		}

		protected ILayout Layout => _layout;

		public ReportLevel ReportLevel { get; set; }

		public int MessegesCount { get; protected set; }

		public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
	}
}
