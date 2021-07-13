namespace MyLinkedList1
{
	class Program
	{
		static void Main(string[] args)
		{
			#region MyLinkedList

			MyLinkedList<int> linkedList = new MyLinkedList<int>();

			linkedList.Add(3);
			linkedList.Add(1);
			linkedList.Add(3);
			linkedList.Add(2);
			linkedList.Add(3);
			linkedList.Add(4);

			linkedList.Remove(3);

			int[] arr = new int[4];

			linkedList.CopyTo(arr, 3);

			#endregion MyLinkedList

			#region LinkedList

			//LinkedList<int> list = new LinkedList<int>();

			//list.AddLast(3);
			//list.AddLast(1);
			//list.AddLast(3);
			//list.AddLast(2);
			//list.AddLast(4);
			//list.AddLast(3);

			//list.Remove(3);

			#endregion LinkedList
		}
	}
}
