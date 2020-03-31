namespace Lab7
{
    public class Matrix3X3
    {
        public const int MatrixSize = 3;
        private readonly double[,] _matrix;

        public Matrix3X3(double[,] matrix)
        {
            _matrix = new double[MatrixSize, MatrixSize];

            for (var i = 0; i < MatrixSize; i++)
            {
                for (var j = 0; j < MatrixSize; j++)
                {
                    _matrix[i, j] = matrix[i, j];
                }
            }
        }

        public double this[int i, int j] => _matrix[i, j];

        public static Matrix3X3 operator +(Matrix3X3 leftMatrix, Matrix3X3 rightMatrix)
        {
            return Sum(leftMatrix, rightMatrix);
        }

        public static Matrix3X3 operator -(Matrix3X3 leftMatrix, Matrix3X3 rightMatrix)
        {
            return Sum(leftMatrix, -rightMatrix);
        }

        public static Matrix3X3 operator -(Matrix3X3 matrix)
        {
            var matrixValues = new double[MatrixSize, MatrixSize];

            for (var i = 0; i < MatrixSize; i++)
            {
                for (var j = 0; j < MatrixSize; j++)
                {
                    matrixValues[i, j] = -matrix[i, j];
                }
            }

            return new Matrix3X3(matrixValues);
        }

        public static Matrix3X3 operator *(Matrix3X3 leftMatrix, Matrix3X3 rightMatrix)
        {
            var matrixValues = new double[MatrixSize, MatrixSize];

            for (var i = 0; i < MatrixSize; i++)
            {
                for (var j = 0; j < MatrixSize; j++)
                {
                    matrixValues[i, j] = 0;
                    for (var k = 0; k < MatrixSize; k++)
                    {
                        matrixValues[i, j] += leftMatrix[i, k] + rightMatrix[k, j];
                    }
                }
            }

            return new Matrix3X3(matrixValues);
        }

        public double Determinant()
        {
            //Calculated by rule of Sarrus.
            return
                _matrix[0, 0] * _matrix[1, 1] * _matrix[2, 2] +
                _matrix[0, 1] * _matrix[1, 2] * _matrix[2, 0] +
                _matrix[0, 2] * _matrix[1, 0] * _matrix[2, 1] -
                _matrix[0, 2] * _matrix[1, 1] * _matrix[2, 0] -
                _matrix[0, 0] * _matrix[1, 2] * _matrix[2, 1] -
                _matrix[0, 1] * _matrix[1, 0] * _matrix[2, 2];
        }

        public double SumOfElementsOnMainDiagonal()
        {
            double answer = 0;

            for (var i = 0; i < MatrixSize; i++)
            {
                answer += _matrix[i, i];
            }

            return answer;
        }

        public double SumOfElementsOnSideDiagonal()
        {
            double answer = 0;

            for (var i = 0; i < MatrixSize; i++)
            {
                answer += _matrix[i, MatrixSize - i - 1];
            }

            return answer;
        }

        public override string ToString()
        {
            return "[" +
                   $"\t[{_matrix[0, 0]}, {_matrix[0, 1]}, {_matrix[0, 2]}]\n" +
                   $"\t[{_matrix[1, 0]}, {_matrix[1, 1]}, {_matrix[1, 2]}]\n" +
                   $"\t[{_matrix[2, 0]}, {_matrix[2, 1]}, {_matrix[2, 2]}]\n" +
                   "]";
        }


        private static Matrix3X3 Sum(Matrix3X3 leftMatrix, Matrix3X3 rightMatrix)
        {
            var matrixValues = new double[MatrixSize, MatrixSize];

            for (var i = 0; i < MatrixSize; i++)
            {
                for (var j = 0; j < MatrixSize; j++)
                {
                    matrixValues[i, j] = leftMatrix[i, j] + rightMatrix[i, j];
                }
            }

            return new Matrix3X3(matrixValues);
        }
    }
}