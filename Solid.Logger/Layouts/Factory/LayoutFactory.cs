using Logger.Layouts;
using Logger.Layouts.Contracts;
using Solid.Logger.Layouts.Factory.Contracts;
using System;

namespace Solid.Logger.Layouts.Factory
{
	public class LayoutFactory : ILayoutFactory
	{
		public ILayout CreateLayout(string type)
		{
			string typeAsLowerCase = type.ToLower();

			switch (typeAsLowerCase)
			{
				case "simplelayout":
					return new SimpleLayout();
				case "xmllayout":
					return new XmlLayout();
				default:
					throw new AggregateException("Invalid layout type!");
			}
		}
	}
}
