namespace Generic_Box_Of_Integers
{
	public class Box<T>
	{
		private T value;

		public Box(T _value)
		{
			value = _value;
		}

		public override string ToString()
		{
			return $"{value.GetType().FullName}: {value}";
		}
	}
}
