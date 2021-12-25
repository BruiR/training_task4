using System;

namespace Task4_1
{
    public class DiagonalMatrix<T>
    {
        private readonly T[] _elements;
        public int Size => _elements.Length;  
        
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Wrong size");
            }
            else
            {
                _elements = new T[size];
            }
        }

        public T this[int i, int j]
        {
            get
            {
                CheckIndex(i);
                CheckIndex(j);
                return i == j ? _elements[i] : default;
            }
            set
            {
                CheckIndex(i);
                CheckIndex(j);
                if ((i == j) && !Equals(value, _elements[i]))
                {
                    var oldValue = _elements[i];
                    _elements[i] = value;
                    OnElementChanged(new ElementChangedEventArgs<T> (i,oldValue, _elements[i]));
                }
            }
        }

        public override string ToString()
        {
            string outputString = string.Empty;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    T element = this[i, j];
                    outputString += $"{(element == null ? "null" : element.ToString()),-12}";
                }
                outputString += "\n";
            }
            return outputString;
        }

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> args)
        {
            ElementChanged?.Invoke(this, args);
        }

        private void CheckIndex(int index)
        {
            if ((index < 0 ) || (index >= Size))
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
        }
    }
}
