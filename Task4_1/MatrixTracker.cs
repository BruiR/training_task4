using System;

namespace Task4_1
{
    public class MatrixTracker<T>
    {
        private DiagonalMatrix<T> _diagonalMatrix;
        private ElementChangedEventArgs<T>[] _changedElements;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix) 
        {
            if (diagonalMatrix is null) throw new ArgumentNullException(nameof(diagonalMatrix));
            _changedElements = Array.Empty<ElementChangedEventArgs<T>>();
            _diagonalMatrix = diagonalMatrix;
            _diagonalMatrix.ElementChanged += Follow;
        }

        public void Undo()
        {
            if (_changedElements.Length != 0)
            {
                _diagonalMatrix.ElementChanged -= Follow;
                var lastElement = _changedElements[^1];
                _diagonalMatrix[lastElement.Index, lastElement.Index] = lastElement.OldValue;
                Array.Resize(ref _changedElements, _changedElements.Length - 1);
                _diagonalMatrix.ElementChanged += Follow;
            }
        }

        private void Follow(object obj, ElementChangedEventArgs<T> args)
        {
            Array.Resize(ref _changedElements, _changedElements.Length + 1);
            _changedElements[^1] = args;
        }

    }
}
