namespace MyList1
{
	public class ListItem<T>
	{
		public ListItem() { }

		public ListItem(T value, bool hasValue)
		{
			Value = value;
			HasValue = hasValue;
		}

		public T Value { get; set; }
		public bool HasValue { get; set; }
	}
}
