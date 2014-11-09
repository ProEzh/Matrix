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
            Matrix A = new Matrix(3, 4);
            A.Fill();
            Console.WriteLine("A:");
            A.Print();
            
            Console.WriteLine("B:");
            Matrix B = new Matrix(3, 4);
            B.Fill();
            B.Print();
            
            Matrix resultOfAddition = A.Addition(B);
            if (resultOfAddition != null) {
                Console.WriteLine ("A+B:");
                resultOfAddition.Print ();
            }
            else {
                Console.WriteLine("A+B: Error");
            }
            
        }
    }
}