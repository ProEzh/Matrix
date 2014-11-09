using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class Matrix
    {
        static public void Main()
        {
            MatrixOperations ob = new MatrixOperations(1, 2);
            MatrixOperations ob1 = new MatrixOperations(2, 1);
            int[,] matrix = ob.FillingMatrix(ob);
            int[,] matrix1 = ob1.FillingMatrix(ob1);
            int[,] ResultOfMatrixAddition = ob.MatrixAddition(matrix, matrix1);             //Очень странно, что если отлаживать пошагово, то метод next дает разные значения
            Console.WriteLine(ResultOfMatrixAddition);                                      //если же в этой строке установить точку останова, то массивы заполняются одинаково

            int[,] ResultOfMatrixSubtraction = ob.MatrixSubtraction(matrix, matrix1);
            int[,] ResultOfMatrixMultiplication = ob.MatrixMultiplication(matrix, matrix1);
        }
    }
}
