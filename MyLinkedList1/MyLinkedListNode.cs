namespace MyLinkedList1
{
	class MyLinkedListNode<T>
	{
		public MyLinkedListNode() { }

		public MyLinkedListNode(T value)
		{
			Value = value;
		}

		public T Value { get; set; }
		public MyLinkedListNode<T> Next { get; set; }
	}
}
