using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagonal_Difference
{
    class Result
    {

        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        /*
        public static int diagonalDifference(List<List<int>> arr)
        {

            //Console.WriteLine(arr[0][0]);
            //Console.WriteLine(arr[1][0]);
            //Console.WriteLine(arr[2][0]);

            int countX1, countX2, countY1, countY2;
            
            int diagonal1,diagonal2;

            countX1 = 0;
            countY1 = 0;
            diagonal1 = 0;
            countX2 = 0;
            countY2 = arr.Count()-1;
            diagonal2 = 0;
            foreach (var (sublist, i) in arr.Select((sublist, i) => (sublist, i)))
            {                
                foreach (var (value, j) in sublist.Select((value, j) => (value, j)))
                {                    
                    if (countX1 == i && countY1 == j)
                    {
                        diagonal1 += value;
                        countX1++;
                        countY1++;

                        Console.WriteLine(i+ " "+ j + " diagonal 1 = "+ diagonal1);
                    }

                    if (countX2 == i && countY2 == j)
                    {
                        diagonal2 += value;
                        countX2++;
                        countY2--;

                        Console.WriteLine(i + " " + j + " diagonal 2  = " + diagonal2);
                    }
                }
                Console.WriteLine(diagonal2-diagonal1);
            }
            Console.ReadLine();

            return 5;
        }
        */

        public static int diagonalDifference(List<List<int>> arr)
        {
            int diagonal1 = 0, diagonal2 = 0, countX1 = 1, countY1 = 0, countX2 = 1, countY2 = arr.Count() - 2, result = 0;

            for (int i = 1; i < arr.Count(); i++)
            {
                for (int j = 0; j < arr.Count(); j++)
                {
                    if (countX1 == i && countY1 == j)
                    {
                        diagonal1 += arr[i][j];
                        countY1++;
                        countX1++;
                    }
                    if (countX2 == i && countY2 == j)
                    {
                        diagonal2 += arr[i][j];
                        countY2--;
                        countX2++;
                    }
                }
            }

            Console.WriteLine(diagonal2 + " - " + diagonal1);
            result = diagonal2 - diagonal1;


            return result;
        

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.IO.TextWriter textWriter = new System.IO.StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int n = Convert.ToInt32(Console.ReadLine().Trim());

            //int n = 3;

            List<List<int>> arr = new List<List<int>>();
            arr.Add(new List<int> { 3 });
            arr.Add(new List<int> { 11, 2, 4 });
            arr.Add(new List<int> { 4, 5, 6 });
            arr.Add(new List<int> { 10, 8, -12 });                

            //for (int i = 0; i < n; i++)
            //{
                //arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            //}

            int result = Result.diagonalDifference(arr);

            Console.WriteLine(result);
            Console.ReadLine();

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
