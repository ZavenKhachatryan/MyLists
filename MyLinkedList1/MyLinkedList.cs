using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList1
{
	class MyLinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerator<T>
	{
		private MyLinkedListNode<T> _fakeLinkedListNode;
		private MyLinkedListNode<T> _currentNode;

		public MyLinkedList() { }

		public MyLinkedListNode<T> LinkedListNode { get; private set; }

		public int Count { get; private set; }

		public T Current { get; private set; }

		object IEnumerator.Current => Current;

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			if (_currentNode == null)
			{
				LinkedListNode = new MyLinkedListNode<T>(item);
				_currentNode = LinkedListNode;
				Count++;
			}
			else
			{
				_currentNode.Next = new MyLinkedListNode<T>(item);
				_currentNode = _currentNode.Next;
				Count++;
			}
		}

		public void Clear()
		{
			LinkedListNode = default;
			Count = default;
			Current = default;
			_currentNode = default;
		}

		public bool Contains(T item)
		{
			_fakeLinkedListNode = LinkedListNode;

			while (_fakeLinkedListNode != null)
			{
				if (_fakeLinkedListNode.Value.ToString().Contains(item.ToString()))
				{
					return true;
				}
				_fakeLinkedListNode = _fakeLinkedListNode.Next;
			}

			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (arrayIndex >= Count || arrayIndex < 0)
			{
				throw new IndexOutOfRangeException();
			}

			_fakeLinkedListNode = LinkedListNode;
			int pointer = 0;
			int i = 0;

			while (_fakeLinkedListNode != null)
			{
				if (pointer >= arrayIndex)
				{
					array[i++] = _fakeLinkedListNode.Value;
				}

				pointer++;
				_fakeLinkedListNode = _fakeLinkedListNode.Next;
			}
		}

		public bool Remove(T item)
		{
			if (LinkedListNode.Value.ToString().Contains(item.ToString()))
			{
				LinkedListNode = LinkedListNode.Next;
				Count--;
				return true;
			}

			MyLinkedList<T> _fakeLinkedList = new MyLinkedList<T>();
			_currentNode = LinkedListNode;
			int pointer = 0;

			while (_currentNode != null)
			{
				if (_currentNode.Value.ToString().Contains(item.ToString()) && pointer == 0)
				{
					pointer++;
					Count--;
				}
				else
				{
					_fakeLinkedList.Add(_currentNode.Value);
				}
				_currentNode = _currentNode.Next;
			}

			LinkedListNode = _fakeLinkedList.LinkedListNode;
			_fakeLinkedList = null;
			 
			return true;
		}

		public IEnumerator<T> GetEnumerator()
		{
			_fakeLinkedListNode = LinkedListNode;
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public bool MoveNext()
		{
			if (_fakeLinkedListNode == null)
				return false;

			Current = _fakeLinkedListNode.Value;
			_fakeLinkedListNode = _fakeLinkedListNode.Next;
			return true;
		}

		public void Reset()
		{
			_fakeLinkedListNode = null;
		}

		public void Dispose()
		{
			Reset();
		}
	}
}
