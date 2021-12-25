using System;

namespace Task4_1
{
    public static class DiagonalMatrixHelper
    {        
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix,Func<T, T, T> sumFunc)
        {
            CheckForNull(firstMatrix);
            CheckForNull(secondMatrix);
            CheckForNull(sumFunc);
            if (firstMatrix.Size < secondMatrix.Size)
            {
                var tmp = firstMatrix;
                firstMatrix = secondMatrix;
                secondMatrix = tmp;
            }

            var outputDiagonalMatrix = new DiagonalMatrix<T>(firstMatrix.Size);
            
            for (int i = 0; i < secondMatrix.Size; i++)
            {
                outputDiagonalMatrix[i, i] = sumFunc(firstMatrix[i, i], secondMatrix[i, i]);
            }
            for (int i = secondMatrix.Size; i < firstMatrix.Size; i++)
            {
                outputDiagonalMatrix[i, i] = firstMatrix[i, i];
            }
            return outputDiagonalMatrix;
        }

        private static void CheckForNull<T>(T obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));

        }

    }
}
