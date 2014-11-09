using System;

namespace Matrix
{
    public class Matrix
    {
        private uint countOfRows_;
        private uint countOfColumns_;
        private int[,] values_;
        
        public static int DefaultMaxValue = 10;
        
        public Matrix(uint countOfRows, uint countOfColumns)
        {
            countOfRows_ = countOfRows;
            countOfColumns_ = countOfColumns;
            
            values_ = new int[countOfRows, countOfColumns];
        }
        
        public Matrix Addition(Matrix matrix)
        {
            if (countOfRows_ != matrix.countOfRows_ || countOfColumns_ != matrix.countOfColumns_) {
                return null;
            }
            
            Matrix resultOfAddition = new Matrix (countOfRows_, countOfColumns_);
            for (uint i = 0; i < countOfRows_; ++i) {
                for (uint j = 0; j < countOfColumns_; ++j) {
                    resultOfAddition.values_[i, j] = values_[ i, j ] + matrix.values_[ i, j ];
                }
            }
            
            return resultOfAddition;
        }
        
        public Matrix Subtraction(Matrix matrix)
        {
            if (countOfRows_ != matrix.countOfRows_ || countOfColumns_ != matrix.countOfColumns_)
            {
                return null;
            }
            
            Matrix resultOfSubtraction = new Matrix(countOfRows_, countOfColumns_);
            for (uint i = 0; i < countOfRows_; ++i)
            {
                for (uint j = 0; j < countOfColumns_; ++j)
                {
                    resultOfSubtraction.values_[i, j] = values_[i, j] - matrix.values_[i, j];
                }
            }
            
            return resultOfSubtraction;
        }
        
        public Matrix Multiplication(Matrix matrix)
        {
            if (countOfColumns_ != matrix.countOfRows_ )
            {
                return null;
            }
            
            Matrix resultOfMultiplication = new Matrix(countOfRows_, matrix.countOfColumns_);
            for (uint i = 0; i < countOfRows_; ++i)
            {
                for (uint j = 0; j < matrix.countOfColumns_; ++j)
                {
                    for (uint k = 0; k < matrix.countOfRows_; ++k)
                        resultOfMultiplication.values_[i, j] += values_[i, k] * matrix.values_[k, j];
                }
            }
            
            return resultOfMultiplication;
        }
        
        public static Matrix E(uint countOfRows)
        {
            Matrix E = new Matrix(countOfRows, countOfRows);
            for (int i = 0; i < countOfRows; ++i) {
                E.values_[i, i] = 1;
            }
            
            return E;
        }
        
        public Matrix InDegree(uint degree)
        {
            if (countOfRows_ != countOfColumns_)
            {
                return null;
            }
            
            Matrix resultOfMatrixDegree = Matrix.E(countOfRows_);
            for (int k = 0; k < degree; ++k) {
                resultOfMatrixDegree = resultOfMatrixDegree.Multiplication(this);
            }
            
            return resultOfMatrixDegree;
        }
        
        public void Fill()
        {
            Random rand = new Random();
            for (uint i = 0; i < countOfRows_; ++i) {
                for (uint j = 0; j < countOfColumns_; ++j) {
                    values_[i, j] = rand.Next( DefaultMaxValue );
                }
            }
        }
        
        public void Print()
        {
            for (uint i = 0; i < countOfRows_; ++i) {
                for (uint j = 0; j < countOfColumns_; ++j) {
                    Console.Write("{0:D}\t", values_[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        public static void Main() {
            Matrix A = new Matrix(2, 2);
            A.Fill();
            Console.WriteLine("A:");
            A.Print();
            
            Console.WriteLine("B:");
            Matrix B = new Matrix(2, 2);
            B.Fill();
            B.Print();
            
            Matrix resultOfAddition = A.Addition(B);
            if (resultOfAddition != null) {
                Console.WriteLine ("A+B:");
                resultOfAddition.Print ();
            }
            else
            {
                Console.WriteLine("A+B: Error");
            }
            
            Matrix resultOfSubtraction = A.Subtraction(B);
            if (resultOfSubtraction != null)
            {
                Console.WriteLine("A-B:");
                resultOfSubtraction.Print();
            }
            else
            {
                Console.WriteLine("A-B: Error");
            }
            
            Matrix resultOfMultiplication = A.Multiplication(B);
            if (resultOfMultiplication != null)
            {
                Console.WriteLine("A*B:");
                resultOfMultiplication.Print();
            }
            else
            {
                Console.WriteLine("A*B: Error");
            }
            
            uint degree = 2;
            Matrix resultOfDegree = A.InDegree(degree);
            if (resultOfDegree != null)
            {
                Console.WriteLine("A^{0:D}:", degree);
                resultOfDegree.Print();
            }
            else
            {
                Console.WriteLine("A^{0:D}: Error", degree);
            }
        }
    }
}