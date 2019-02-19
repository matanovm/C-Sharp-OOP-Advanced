using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;

namespace Solid.Logger.Appenders.Factory.Contracts
{
	public interface IAppenderFactory
	{
		IAppender CreateAppender(string type, ILayout layout);
	}
}
