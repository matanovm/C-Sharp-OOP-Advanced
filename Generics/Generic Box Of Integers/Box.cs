namespace Generic_Box_Of_Integers
{
	class Box<T>
	{
		private T value;

		public Box(T value)
		{
			this.value = value;
		}

		public override string ToString()
		{
			return $"{value.GetType().FullName}: {value}";
		}
	}
}
