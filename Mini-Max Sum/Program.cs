using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
        List<long> sumList = new List<long>();
        long sum = 0;
        //long sumMax = sum - min;
        //long sumMin = sum - max;


        for (int i = 0; i < arr.Count; i++)
        {
            sum = 0;
            Console.WriteLine("la suma de: ");
            for (int j = 0; j < arr.Count; j++)
            {
                if (i != j)
                {
                    sum += Convert.ToInt64(arr[j]);
                    Console.WriteLine(" + " + Convert.ToString(arr[j]));
                }
            }
            sumList.Insert(i, sum);

            Console.WriteLine("es igual a: ");
            Console.WriteLine(Convert.ToString("sum[ " + i + " ] = " + sumList[i]));
        }

        Console.WriteLine(Convert.ToString(sumList.Min()) + " " + Convert.ToString(sumList.Max()));
        Console.ReadLine();
    }


    class Solution
    {
        public static void Main(string[] args)
        {

            //   List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            // Result.miniMaxSum(arr);

            String lista = "1 2 3 4 5";
            
            List<int> arr = lista.TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            Result.miniMaxSum(arr);

        }
    }
}