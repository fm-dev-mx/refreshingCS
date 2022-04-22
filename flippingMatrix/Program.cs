using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flippingMatrix
{

    class Result
    {
        private static object retun;

        /*
         * Complete the 'flippingMatrix' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
         */

        public static int flippingMatrix(List<List<int>> matrix)
        {
            printMatrix("first");

            int max1 = 0, max2 = 0, max3 = 0, max4 = 0, ep = matrix.Count - 1, count=0, rowBan=-1, colBan=-1;
            bool ban00 = false, ban01 = false, ban10 = false, ban11 = false;
           
            void maxValues()
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix.Count; j++)
                    {
                        if (max1 < matrix[i][j] && matrix[i][j] != max1 && matrix[i][j] != max2 && matrix[i][j] != max3 && matrix[i][j] != max4)
                        {
                            max4 = max3;
                            max3 = max2;
                            max2 = max1;
                            max1 = matrix[i][j];
                        }
                        else if (max2 < matrix[i][j] && matrix[i][j] != max1 && matrix[i][j] != max2 && matrix[i][j] != max3 && matrix[i][j] != max4)
                        {
                            max4 = max3;
                            max3 = max2;
                            max2 = matrix[i][j];
                        }
                        else if (max3 < matrix[i][j] && matrix[i][j] != max1 && matrix[i][j] != max2 && matrix[i][j] != max3 && matrix[i][j] != max4)
                        {
                            max4 = max3;
                            max3 = matrix[i][j];
                        }
                        else if (max4 < matrix[i][j] && matrix[i][j] != max1 && matrix[i][j] != max2 && matrix[i][j] != max3 && matrix[i][j] != max4)
                        {
                            max4 = matrix[i][j];
                        }

                    }
                }
            }
            
            void printMax()
            {
                maxValues();
                Console.WriteLine("Max 1 => " + max1);
                Console.WriteLine("Max 2 => " + max2);
                Console.WriteLine("Max 3 => " + max3);
                Console.WriteLine("Max 4 => " + max4);
                Console.WriteLine("------------------");
            }
            
            void printMatrix(string msg)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    for (int col = 0; col < matrix.Count; col++)
                    {                        
                        Console.Write(matrix[row][col] + " ");                        
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-----------" + msg + "--------------");
            }

            void printPositions()
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    for (int col = 0; col < matrix.Count; col++)
                    {
                        Console.Write(row + "-" + col +" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------");
            }

            void printMsg(string msg)
            {
                Console.WriteLine(msg);
            }

            void columnReverse(int y)
            {
                List<List<int>> matrixCol = new List<List<int>>();


                for (int row = 0; row < matrix.Count; row++)
                {
                    List<int> subMatrixCol = new List<int>();
                    for (int col = 0; col < matrix.Count; col++)
                    {
                        subMatrixCol.Add(matrix[col][row]);
                    }
                    matrixCol.Add(subMatrixCol);
                }

                matrixCol[y].Reverse();

                matrix.Clear();

                for (int row = 0; row < matrixCol.Count; row++)
                {
                    List<int> subMatrix = new List<int>();
                    for (int col = 0; col < matrixCol.Count; col++)
                    {
                        subMatrix.Add(matrixCol[row][col]);
                    }
                    matrix.Add(subMatrix);
                }

            }

            void actives(int row, int col, int val)
            {
                printMsg("Actives");
                if (ban00 == true)
                {
                    while (rowBan == 0 && colBan == 1 || rowBan == 1 && colBan == 1 || rowBan == 1 && colBan == 0)
                    {
                        if ((row == 0 && col == ep && val < matrix[0][0]) || (col == 0 && row == ep && val < matrix[0][0]))
                        {
                            rowBan = -1;
                            colBan = -1;
                            break;
                        }
                        else if (row == 0 && col == ep && val > matrix[0][0])
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                            break;
                        }
                        else if (col == 0 && row == ep && val > matrix[0][0])
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                            break;
                        }
                        else if (row == ep - 1)
                        {
                            matrix[row].Reverse();
                            columnReverse(ep - col);
                            matrix[ep - row].Reverse();
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if (col == ep - 1)
                        {
                            columnReverse(col);
                            matrix[ep - row].Reverse();
                            columnReverse(ep - col);
                            rowBan = row;
                            colBan = ep - col;
                        }
                        else if ((col != 0) && (ep - row <= 1))
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if ((row != 0) && (ep - col <= 1))
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                        }
                        else if ((col != 0))
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if ((row != 0))
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                        }

                    }
                    if (rowBan == 0 && colBan == 0)
                        printMsg("Se capturo movimiento erroneo");
                }
                if (ban10 == true)
                {
                    while (rowBan == 0 && colBan == 1 || rowBan == 1 && colBan == 1 || rowBan == 0 && colBan == 0)
                    {
                        if ((row == 1 && col == ep && val < matrix[1][0]) || (col == 0 && row == ep - 1 && val < matrix[1][0]))
                        {
                            rowBan = -1;
                            colBan = -1;
                            break;
                        }
                        else if (row == 0 && col == ep - 1 && val > matrix[0][0])
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                            break;
                        }
                        else if (col == ep && row == 1 && val > matrix[0][0])
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                            break;
                        }
                        /* else if (row == ep - 1)
                         {
                             matrix[row].Reverse();
                             columnReverse(ep - col);
                             matrix[ep - row].Reverse();
                             rowBan = ep - row;
                             colBan = col;
                         }
                         else if (col == ep - 1)
                         {
                             columnReverse(col);
                             matrix[ep - row].Reverse();
                             columnReverse(ep - col);
                             rowBan = row;
                             colBan = ep - col;
                         }*/
                        else if ((col != 0) && (ep - row <= 1))
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if ((row != 1) && (ep - col <= 1))
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                        }
                        else if ((col != 0))
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if ((row != 1))
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                        }

                    }
                    if (rowBan == 1 && colBan == 0)
                        printMsg("Se capturo movimiento erroneo");

                }
                if (ban01 == true)
                {
                    while (rowBan == 0 && colBan == 0 || rowBan == 1 && colBan == 0 || rowBan == 1 && colBan == 1)
                    {
                        if ((row == ep && col == 1 && val < matrix[0][1]) || (col == ep - 1 && row == 0 && val < matrix[0][1]) || (col == ep - 1 && row == ep && val < matrix[0][1]))
                        {
                            rowBan = -1;
                            colBan = -1;
                            break;
                        }
                        else if (row == 0 && col == ep - 1 && val > matrix[0][1])
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                            break;
                        }
                        else if (col == ep - 1 && row == 0 && val > matrix[0][1])
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                            break;
                        }
                        else if (col == ep - 1 && row == ep && val > matrix[0][1])
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                            break;
                        }
                        /* else if (row == ep - 1)
                         {
                             matrix[row].Reverse();
                             columnReverse(ep - col);
                             matrix[ep - row].Reverse();
                             rowBan = ep - row;
                             colBan = col;
                         }
                         else if (col == ep - 1)
                         {
                             columnReverse(col);
                             matrix[ep - row].Reverse();
                             columnReverse(ep - col);
                             rowBan = row;
                             colBan = ep - col;
                         }*/
                        else if ((col != 1) && (ep - row <= 1))
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if ((row != 0) && (ep - col <= 1))
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                        }
                        else if ((col != 1))
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if ((row != 0))
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                        }

                    }
                    if (rowBan == 0 && colBan == 1)
                        printMsg("Se capturo movimiento erroneo");

                }
                if (ban11 == true)
                {
                    while (rowBan == 0 && colBan == 0 || rowBan == 1 && colBan == 0 || rowBan == 0 && colBan == 1)
                    {
                        if ((row == ep - 1 && col == 1 && val < matrix[1][1]) || (col == ep - 1 && row == 1 && val < matrix[1][1]) || (col == ep - 1 && row == ep - 1 && val < matrix[1][1]))
                        {
                            rowBan = -1;
                            colBan = -1;
                            break;
                        }
                        else if (row == ep - 1 && col == 1 && val > matrix[1][1])
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                            break;
                        }
                        else if (col == ep - 1 && row == 1 && val > matrix[1][1])
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                            break;
                        }
                        else if (col == ep - 1 && row == ep - 1 && val > matrix[1][1])
                        {
                            matrix[row].Reverse();
                            columnReverse(ep - col);
                            rowBan = ep - row;
                            colBan = ep - col;
                            break;
                        }
                        /* else if (row == ep - 1)
                         {
                             matrix[row].Reverse();
                             columnReverse(ep - col);
                             matrix[ep - row].Reverse();
                             rowBan = ep - row;
                             colBan = col;
                         }
                         else if (col == ep - 1)
                         {
                             columnReverse(col);
                             matrix[ep - row].Reverse();
                             columnReverse(ep - col);
                             rowBan = row;
                             colBan = ep - col;
                         }*/
                        else if ((col != 1) && (ep - row <= 1))
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if ((row != 1) && (ep - col <= 1))
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                        }
                        else if ((col != 1))
                        {
                            columnReverse(col);
                            rowBan = ep - row;
                            colBan = col;
                        }
                        else if ((row != 1))
                        {
                            matrix[row].Reverse();
                            rowBan = row;
                            colBan = ep - col;
                        }

                    }
                    if (rowBan == 1 && colBan == 1)
                        printMsg("Se capturo movimiento erroneo");

                }

            }

            void moving(int row, int col, int val)
            {
                if (ban00 == false && ban01 == false && ban10 == false && ban11 == false)
                {
                    printMsg("moving");
                    if (row > 1 && col > 1)
                    {
                        columnReverse(col);
                        matrix[ep - row].Reverse();
                        rowBan = ep - row;
                        colBan = ep - col;

                        printMatrix("Col reverse + row reverse");
                    }
                    else if (col > 1)
                    {
                        matrix[row].Reverse();
                        rowBan = row;
                        colBan = ep - col;
                        printMatrix("row reverse");
                    }
                    else if (row > 1)
                    {
                        columnReverse(col);
                        rowBan = ep - row;
                        colBan = col;
                        printMatrix(" row reverse ");
                    }
                    else
                    {
                        actives(row, col, val);
                    }
                }
            }

            void ubicate(int row, int col, int val)
            {
                printMsg("row = " + row + "|| col =" + col);
                count++;
                switch (count)
                {
                    case 1:
                        moving(row, col, val);
                        break;
                    case 2:
                        moving(row, col, val);
                        break;
                    case 3:
                        moving(row, col, val);
                        break;
                    case 4:
                        moving(row, col, val);
                        break;
                    default:
                        moving(row, col, val);
                        break;
                }                                    
            }

            maxValues();
            for (int row = 0; row < matrix.Count; row++)
            {                
                for (int col = 0; col < matrix.Count; col++)
                {                    
                    if (max1 == matrix[row][col]) { ubicate(row, col, matrix[row][col]); }
                    if (max2 == matrix[row][col]) { ubicate(row, col, matrix[row][col]); }
                    if (max3 == matrix[row][col]) { ubicate(row, col, matrix[row][col]); }
                    if (max4 == matrix[row][col]) { ubicate(row, col, matrix[row][col]); }
                }
            }

            printMatrix("After all");

            printMsg("Posición 00 => " + ban00);
            printMsg("Posición 10 => " + ban10);
            printMsg("Posición 01 => " + ban01);
            printMsg("Posición 11 => " + ban11);
            printMsg((matrix[0][0]+ matrix[1][0]+ matrix[0][1]+ matrix[1][1]).ToString());

            return 5;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = new List<List<int>>();

            matrix.Add(new List<int>() { 112, 42, 83, 119  });
            matrix.Add(new List<int>() { 56, 125, 56, 49 });
            matrix.Add(new List<int>() { 15, 78, 101, 43 });
            matrix.Add(new List<int>() { 62, 98, 114, 108 });

            int result = Result.flippingMatrix(matrix);

            Console.WriteLine(result);
            Console.ReadLine();
            }

            
    }
}
