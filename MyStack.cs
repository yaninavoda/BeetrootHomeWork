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
            for (int i = 0; i < _elements.Count; i++)
            {
                arr[i] = _elements[i];
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
            //_elements.Reverse();

            var enumerator = _elements.GetEnumerator();
            

            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //_elements.Reverse();
            var enumerator = _elements.GetEnumerator();
            
            return enumerator;
        }

        private int GetLastIndex()
        {
            int index = _elements.Count - 1;

            return index;
        }
    }
}
