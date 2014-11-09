using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class MatrixOperations
    {
        public int RowsNumber;
        public int ColumnsNumber;

        public MatrixOperations(int i, int j) {
            RowsNumber = i;
            ColumnsNumber = j;
        }

        public int[,] FillingMatrix(MatrixOperations ob) {
            Random rand = new Random();
            int[,] matrix = new int [ob.RowsNumber, ob.ColumnsNumber];
            for (int a = 0; a < ob.RowsNumber; a++)
                for (int b = 0; b < ob.ColumnsNumber; b++)
                    matrix[a, b] = rand.Next(100);
            return matrix;
        }

        public int[,] MatrixAddition(int[,] matrix, int[,] matrix1) {
            int[,] ResultOfMatrixAddition = new int[RowsNumber, ColumnsNumber];
            for (int a = 0; a < RowsNumber; a++)
                for (int b = 0; b < ColumnsNumber; b++)
                    ResultOfMatrixAddition[a, b] = 0;
            if (matrix.GetLength(0) != matrix1.GetLength(0) || matrix.GetLength(1) != matrix1.GetLength(1))
            {
                Console.WriteLine("Addition is impossible");
                return null;
            }

            else{
                for (int a = 0; a < matrix.GetLength(0); a++)
                    for (int b = 0; b < matrix.GetLength(1); b++)
                        ResultOfMatrixAddition[a, b] = matrix[a, b] + matrix1[a, b];
                return ResultOfMatrixAddition;
            }
        }

        public int[,] MatrixSubtraction(int[,] matrix, int[,] matrix1)
        {
            int[,] ResultOfMatrixSubtraction = new int[RowsNumber, ColumnsNumber];
            for (int a = 0; a < RowsNumber; a++)
                for (int b = 0; b < ColumnsNumber; b++)
                    ResultOfMatrixSubtraction[a, b] = 0;
            if (matrix.GetLength(0) != matrix1.GetLength(0) || matrix.GetLength(1) != matrix1.GetLength(1))
            {
                Console.WriteLine("Subtraction is impossible");
                return null;
            }

            else
            {
                for (int a = 0; a < matrix.GetLength(0); a++)
                    for (int b = 0; b < matrix.GetLength(1); b++)
                        ResultOfMatrixSubtraction[a, b] = matrix[a, b] - matrix1[a, b];
                return ResultOfMatrixSubtraction;
            }
        }

        public int[,] MatrixMultiplication(int[,] matrix, int[,] matrix1) {
            int[,] ResultOfMatrixMultiplication = new int[RowsNumber, ColumnsNumber];
            for (int a = 0; a < RowsNumber; a++)
                for (int b = 0; b < ColumnsNumber; b++)
                    ResultOfMatrixMultiplication[a, b] = 0;
            if (matrix.GetLength(1) != matrix1.GetLength(0))
            {
                Console.WriteLine("Multiplication is impossible");
                return null;
            }

            else {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                        for (int k = 0; k < matrix1.GetLength(0); k++)
                            ResultOfMatrixMultiplication[i, j] += matrix[i, k] * matrix1[k, j];
                return ResultOfMatrixMultiplication;
            }
        }
    }
}
