using System;

namespace MyList1
{
	class Program
	{
		static void Main(string[] args)
		{
			MyList<int> myList = new MyList<int>();

			for (int i = 0; i < 13; i++)
			{
				myList.Add(i);
			}

			myList.Remove(3);

			foreach (var item in myList)
			{
				Console.Write(item+" ");
			}

			Console.WriteLine();

			myList.Insert(3, 89);
			myList.Insert(11, 56);

			foreach (var item in myList)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();

			Console.WriteLine($"IsContains: {myList.Contains(56)}");

			foreach (var item in myList)
			{
				Console.Write(item+" ");
			}
			Console.WriteLine();

			myList.RemoveAt(6);
			foreach (var item in myList)
			{
				Console.Write(item+" ");
			}

			int[] arr = new int[13];
			myList.CopyTo(arr, 5);
			Console.WriteLine();
			foreach (var item in arr)
			{
				Console.Write(item + " ");
			}
		}
	}
}
