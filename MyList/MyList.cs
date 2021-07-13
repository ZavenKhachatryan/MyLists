using System;
using System.Collections;
using System.Collections.Generic;

namespace MyList1
{
	public class MyList<T> : IEnumerable<T>, IEnumerator<T>, IList<T>, ICollection<T>
	{
		private ListItem<T>[] _array;

		public MyList()
		{
			_array = new ListItem<T>[Capacity];
		}

		private int Position { get; set; } = -1;
		public int Capacity { get; private set; } = 10;
		public int Count { get; private set; } = 0;
		public T Current => this[Position];
		object IEnumerator.Current => _array[Position];
		public bool IsReadOnly => false;

		public T this[int index]
		{
			get
			{
				var realIndex = GetRealIndex(index);
				return _array[realIndex].Value;
			}
			set
			{
				var realIndex = GetRealIndex(index);
				_array[realIndex].Value = value;
			}
		}

		private int GetRealIndex(int index)
		{
			if (index >= Count || index < 0)
			{
				throw new IndexOutOfRangeException();
			}
			for (int realIndex = 0, fakeIndex = 0; realIndex < _array.Length; realIndex++)
			{
				if (_array[realIndex].HasValue)
				{
					if (fakeIndex == index)
					{
						return realIndex;
					}
					fakeIndex++;
				}
			}
			throw new IndexOutOfRangeException();
		}
		private void ShardArray()
		{
			Capacity *= 2;
			var tempArray = new ListItem<T>[Capacity];
			int j = 0;
			for (int i = 0; i < _array.Length; i++)
			{
				if (_array[i].HasValue)
				{
					tempArray[j++] = _array[i];
				}
			}
			Count = j;
			_array = tempArray;
		}
		public void Add(T item)
		{
			if (Count >= Capacity)
			{
				ShardArray();
			}
			_array[Count++] = new ListItem<T>(item, true);
		}
		public void Remove(int index)
		{
			_array[GetRealIndex(index)].HasValue = false;
			Count--;
		}

		public int IndexOf(T item)
		{
			for (int i = 0, index = 0; i < Count; i++)
			{
				if (_array[i].HasValue == true)
				{
					if (_array[i].Value.Equals(item))
					{
						return index;
					}

					index++;
				}
			}

			throw new Exception("Item was not found");
		}

		public void Insert(int index, T item)
		{
			_array[GetRealIndex(index)].Value = item;

			//if (index < 0 || index >= Count)
			//{
			//	throw new IndexOutOfRangeException();
			//}

			//for (int realIndex = 0, fakeIndex = 0; realIndex < _array.Length && _array[fakeIndex] != null; realIndex++)
			//{
			//	if (_array[realIndex] != null && _array[realIndex].HasValue == false)
			//	{
			//		continue;
			//	}
			//	if (fakeIndex == index)
			//	{
			//		_array[realIndex].Value = item;
			//	}
			//	fakeIndex++;
			//}
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}

			for (int realIndex = 0, fakeIndex = 0; realIndex < _array.Length && _array[fakeIndex] != null; realIndex++)
			{
				if (_array[realIndex] != null && _array[realIndex].HasValue == false)
				{
					continue;
				}
				if (_array[realIndex] == null)
				{
					return;
				}
				if (fakeIndex >= index)
				{
					_array[realIndex].HasValue = false;
					Count--;
				}
				fakeIndex++;
			}
		}

		public void Clear()
		{
			Count = 0;
			Capacity = 10;
			_array = new ListItem<T>[Capacity];
		}

		public bool Contains(T item)
		{
			for (int i = 0; i < _array.Length; i++)
			{
				if (_array[i] != null && _array[i].HasValue == true && _array[i].Value.Equals(item))
				{
					return true;
				}
			}

			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (arrayIndex < 0 || arrayIndex >= Count)
			{
				throw new IndexOutOfRangeException();
			}

			for (int i = 0, realIndex = 0, fakeIndex = 0; realIndex < _array.Length && _array[fakeIndex] != null; realIndex++)
			{
				if (_array[realIndex] != null && _array[realIndex].HasValue == false)
				{
					continue;
				}
				if (fakeIndex == arrayIndex)
				{
					array[i++] = _array[realIndex].Value;
				}
				fakeIndex++;
			}
		}

		public bool Remove(T item)
		{
			Remove(IndexOf(item));
			return true;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this;
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _array.GetEnumerator();
		}
		public bool MoveNext()
		{
			if (Position >= Count - 1)
			{
				return false;
			}
			else
			{
				Position++;
				return true;
			}
		}
		public void Reset()
		{
			Position = -1;
		}
		public void Dispose()
		{
			Reset();
		}
	}
}
