using Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Layouts.Factory.Contracts
{
	public interface ILayoutFactory
	{
		ILayout CreateLayout(string type);
	}
}
