using System;
using System.Collections.Generic;

namespace Lab9
{
    public struct SunMatrixInfo
    {
        public int SumElements;
        public int LeftPosition;
        public int TopPosition;
        public int Width;
        public int Height;
    }

    class MatrixHelper
    {
        public static SunMatrixInfo FindMaxSubmatrix(int[,] matrix, int height, int width, int numThreads)
        {
            var threads = new List<IAsyncResult>();

            var func = new Func<int[,], int, int, int, int, int, int, SunMatrixInfo>(FindMaxSunMatrixFromRange);

            var minH = 1;
            var maxH = height / numThreads;
            threads.Add(func.BeginInvoke(matrix, height, width, minH, maxH, 0, width, null, null));

            for (int i = 1; i < numThreads - 1; i++)
            {
                minH = maxH;
                maxH += height / numThreads;
                threads.Add(func.BeginInvoke(matrix, height, width, minH, maxH, 0, width, null, null));
            }

            minH = maxH;
            maxH = height;
            threads.Add(func.BeginInvoke(matrix, height, width, minH, maxH, 0, width, null, null));

            bool isWorking;
            do
            {
                isWorking = false;
                foreach (var thread in threads)
                {
                    if (!thread.IsCompleted)
                    {
                        isWorking = true;
                        break;
                    }
                }
            } while (isWorking);


            var answer = func.EndInvoke(threads[0]);

            for(int i = 1; i < threads.Count; i++)
            {
                var result = func.EndInvoke(threads[i]);
                if (result.SumElements > answer.SumElements)
                {
                    answer = result;
                }
            }

            return answer;
        }

        private static SunMatrixInfo FindMaxSunMatrixFromRange(int[,] matrix, int height, int width, int minHeight, int maxHeight, int minWidth, int maxWidth)
        {
            SunMatrixInfo answer = new SunMatrixInfo
            {
                SumElements = int.MinValue
            };

            for(int i = minHeight; i <= maxHeight; i++)
                for(int j = minWidth; j <= maxWidth; j++)
                {
                    var result = FindMaxSunMatrixWithSize(matrix, height, width, i, j);

                    if (result.SumElements > answer.SumElements)
                        answer = result;
                }

            return answer;
        }

        private static SunMatrixInfo FindMaxSunMatrixWithSize(int[,] matrix, int height, int width, int subMatrixHeight, int subMatrixWidth)
        {
            SunMatrixInfo answer = new SunMatrixInfo
            {
                SumElements = int.MinValue,
                Height = subMatrixHeight,
                Width = subMatrixWidth
            };

            for (int i = 0; i <= height - subMatrixHeight; i++)
                for (int j = 0; j <= width - subMatrixWidth; j++)
                {
                    var sum = CalcSubmatrixSum(matrix, i, j, subMatrixHeight, subMatrixWidth);

                    if(sum > answer.SumElements)
                    {
                        answer.SumElements = sum;
                        answer.TopPosition = i;
                        answer.LeftPosition = j;
                    }
                }

            return answer;
        }

        private static int CalcSubmatrixSum(int[,] matrix, int topPosition, int leftPosition, int height, int width)
        {
            var sum = 0;

            for(int i = topPosition; i < topPosition + height; i++)
                for(int j = leftPosition; j < leftPosition + width; j++)
                    sum += matrix[i, j];

            return sum;
        }
    }
}
