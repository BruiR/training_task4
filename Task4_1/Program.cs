using System;

namespace Task4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dm1 = new DiagonalMatrix<int>(5);
            var matrixTracker = new MatrixTracker<int>(dm1);
            dm1[0, 0] = 0;
            dm1[1, 1] = 1;
            dm1[2, 2] = 2;
            dm1[3, 3] = 3;
            dm1[4, 4] = 4;
            Console.WriteLine(dm1);
            matrixTracker.Undo();
            Console.WriteLine("dm1 after Undo =>");
            Console.WriteLine(dm1);
            try
            {
                dm1[5, 5] = 5;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            matrixTracker.Undo();
            Console.WriteLine("dm1 after Undo =>");
            Console.WriteLine(dm1);

            var dm2 = new DiagonalMatrix<int>(6);
            dm2[0, 0] = 0;
            dm2[1, 1] = 1;
            dm2[2, 2] = 2;
            dm2[3, 3] = 3;
            dm2[4, 4] = 4;
            dm2[5, 5] = 7;

            Func<int, int, int> Add = (int a, int b) => a + b;
            var  dm3 = DiagonalMatrixHelper.Add(dm1,dm2, Add);

            Console.WriteLine("dm3 =>");
            Console.WriteLine(dm3);
        }

    }
}
