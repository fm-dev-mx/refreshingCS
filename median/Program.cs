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
     * Complete the 'findMedian' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int findMedian(List<int> arr)
    {
        int median;
        
        arr.Sort();

        if (arr.Count() % 2 == 0)
            median = (arr[(arr.Count / 2) + 1] + arr[(arr.Count / 2) - 1]) / 2;
        else
            median = arr[(arr.Count / 2)];

        foreach(int i in arr)
            Console.WriteLine(i);
        Console.WriteLine("---------");
        Console.WriteLine(arr[(arr.Count / 2)]);
        Console.WriteLine(arr[(arr.Count / 2) + 1]);
        Console.WriteLine(arr[(arr.Count / 2) + -1]);
        Console.WriteLine("---------");
        return median;

    }

}
class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //int n = Convert.ToInt32(Console.ReadLine().Trim());

        //List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        List<int> arr = new List<int>() { 1, 5, 8, 4, 3, 7, 2, 10,11,6};

        int result = Result.findMedian(arr);

        Console.WriteLine(result);
        Console.ReadLine();

        //textWriter.Flush();
        //textWriter.Close();
    }
}