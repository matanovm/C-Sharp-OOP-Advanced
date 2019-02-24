using System;
using System.Collections.Generic;

namespace Generic_Count_Method_Strings
{
	public class Box<T>
		where T : IComparable<T>
	{
		public Box(List<string> items)
		{
			this.Items = items;
		}

		public List<string> Items { get; set; }

		public override string ToString()
		{
			return $"{this.Items.GetType()}: {this.Items}";
		}

		internal int GetGreaterthan(T element)
		{
			int count = 0;

			foreach (var item in this.Items)
			{
				if (item.CompareTo(element) > 0)
				{
					count++;
				}
			}

			return count;
		}
	}
}
