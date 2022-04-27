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
            int ep = matrix.Count - 1;

            void print(string param, int cant, string msg)
            {
                switch (param)
                {
                    case "msg":
                        for (int i = 0; i < cant; i++)
                            Console.WriteLine("---------- " + msg + " ---------------");
                        break;
                    case "max":
                        for (int i = 0; i < cant; i++)
                            Console.WriteLine("Max " + (i + 1) + " = " + getMaxValue(i + 1));
                        break;
                    case "matrix":
                        if (cant == 0)
                        {
                            for (int row = 0; row < matrix.Count; row++)
                            {
                                for (int col = 0; col < matrix.Count; col++)
                                {
                                    Console.Write(row + "-" + col + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            foreach (var subLista in matrix)
                            {
                                foreach (var item in subLista)
                                {
                                    Console.Write(item + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                        break;
                }
                Console.WriteLine("-------- " + msg + " ---------");
            }

            int getMaxValue(int number)
            {
                List<int> listaTotal = new List<int>();
                foreach (var subLista in matrix)
                    foreach (var item in subLista)
                    {
                        listaTotal.Add(item);
                    }
                listaTotal.Sort();
                return listaTotal[listaTotal.Count - number];
            }

            int getOppositeRowValue(int row, int col)
            {                
                return matrix[row][ep-col];
            }

            int getOppositeColumnValue(int row, int col)
            {
                return matrix[ep - row][col];
            }

            int getOppositeValue(int row, int col)
            {
                return matrix[ep - row][ep-col];
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
                        subMatrix.Add(matrixCol[col][row]);
                    }
                    matrix.Add(subMatrix);
                }

            }

            int rowReverse(int row, int col)
            {
                if (matrix[row][col] > getOppositeRowValue(row, col))
                {
                    while (col > 1)
                    {
                        if (ep - col == 0)
                        {
                            if (matrix[row][1] > getOppositeRowValue(row, 1))
                            {
                                columnReverse(1);
                                matrix[row].Reverse();
                                columnReverse(1);
                                col = ep - col;
                                print("matrix", 1, "col > 1 y columna 1 mayor");
                                return col;
                            }
                            else
                            {
                                matrix[row].Reverse();
                                col = ep - col;
                                print("matrix", 1, "col > 1 y columna 1 menor");
                                return col;
                            }
                        }
                        else if (ep - col == 1)
                        {
                            if (matrix[row][0] > getOppositeRowValue(row, 0))
                            {
                                columnReverse(0);
                                matrix[row].Reverse();
                                columnReverse(0);
                                col = ep - col;
                                print("matrix", 1, "col > 1 y columna 0 mayor");
                                return col;
                            }
                            else
                            {
                                matrix[row].Reverse();
                                col = ep - col;
                                print("matrix", 1, "col > 1 y columna 0 menor");
                                return col;
                            }
                        }
                    }
                    return col;
                }
                return col;
            }

            int colReverse(int row, int col)
            {
                if (matrix[row][col] > getOppositeColumnValue(row, col))
                {
                    while (row > 1)
                    {
                        if (ep - row == 0)
                        {
                            if (matrix[1][col] > getOppositeColumnValue(1, col))
                            {
                                matrix[1].Reverse();
                                columnReverse(col);
                                matrix[1].Reverse();
                                row = ep - row;
                                print("matrix", 1, "row > 1 y renglon 1 mayor");
                                return row;
                            }
                            else
                            {
                                columnReverse(col);
                                row = ep - row;
                                print("matrix", 1, "row > 1 y renglon 1 menor");
                                return row;
                            }
                        }
                        else if (ep - row == 1)
                        {
                            if (matrix[0][col] > getOppositeColumnValue(1, col))
                            {
                                matrix[0].Reverse();
                                columnReverse(col);
                                matrix[0].Reverse();
                                row = ep - row;
                                print("matrix", 1, "row > 1 y renglon 0 mayor");
                                return row;
                            }
                            else
                            {
                                columnReverse(col);
                                row = ep - row;

                                print("matrix", 1, "row > 1 y renglon 0 menor");
                                return row;
                            }
                        }
                    }
                    return row;
                }
                return row;
            }

            print("matrix",1,"Start");
                                    
            

            string moving(int row, int col, int val)
            {
                if (matrix[row][col] > getOppositeValue(row, col) && (row > 1 && col > 1))
                {
                    print("msg", 1, matrix[row][col] + " > " + getOppositeValue(row, col));
                    while (row > 1)
                    {
                        row = colReverse(row, col);                                          
                    }
                    while (col > 1)
                    {
                        col = rowReverse(row, col);
                    }
                    return "col-row";
                }else if (matrix[row][col] > getOppositeRowValue(row, col) && (row > 1))
                {
                    while (col > 1)
                    {
                        col = rowReverse(row, col);
                    }
                    return "row";
                }
                else if (matrix[row][col] > getOppositeColumnValue(row, col) && (col > 1))
                {
                    while (row > 1)
                    {
                        row = colReverse(row, col);
                    }
                    return "col";
                }
                return "0";
            }

           
            for (int row = 0; row < matrix.Count; row++)
            {                
                for (int col = 0; col < matrix.Count; col++)
                {
                    if (moving(row, col, matrix[row][col])=="row-col")
                    {
                        print("matrix", 1, "row - col");
                        print("msg", 1, "row " + row + " - col " + col);
                        row = ep-row;
                        col = ep-col;                        
                    }else if (moving(row, col, matrix[row][col]) == "row")
                    {
                        print("matrix", 1, "row");
                        print("msg", 1, "row " + row + " - col " + col);
                        col = ep - col;
                        
                    }else if (moving(row, col, matrix[row][col]) == "col")
                    {
                        print("matrix", 1, "col");
                        print("msg", 1, "row " + row + " - col " + col);
                        row = ep - row;
                    }
                    else if (moving(row, col, matrix[row][col]) == "0")
                    {
                        print("matrix", 1, "-");
                        print("msg", 1, "row " + row + " - col " + col);
                    }
                }
            }

            print("matrix", 1, "After all");

            print("msg", 1, (matrix[0][0] + matrix[0][1] + matrix[1][0] + matrix[1][1]).ToString());

            print("max",5,"Max Values");

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
