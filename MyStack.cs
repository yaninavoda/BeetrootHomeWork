using System.Collections;
using System.Dynamic;

namespace BeetrootHomework
{
    public class MyStack<T> : IEnumerable<T>
    {
        
        private List<T> _elements;
        public int Count { get; set; }

        public MyStack()
        {
            Count = _elements.Count;
        }

        public MyStack(List<T> elements)
        {
            _elements = elements;
            Count = elements.Count;
        }

        public T PopStack()
        {
            T element = _elements[GetLastIndex()];

            _elements.RemoveAt(GetLastIndex());

            Count--;

            return element;
        }

        public void PushStack(T value)
        {
            _elements.Add(value);

            Count++;
        }
        public void ClearStack()
        {
            _elements.Clear();

            Count = 0;
        }
        public T PeekStack()
        {
            T element = _elements[GetLastIndex()];

            return element;
        }
        public void CopyToStack(T[] arr) 
        {
            int index = 0;
            for (int i = _elements.Count - 1; i >= 0; i--)
            {
                arr[index] = _elements[i];
                index++;
            }
        }

        public void PrintStack()
        {
            foreach (var item in _elements)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        private int GetLastIndex()
        {
            return _elements.Count - 1;
        }
    }
}
