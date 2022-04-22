using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonely_Integer
{
    internal class Program
    {
        /*
     * Complete the 'lonelyinteger' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

        class Result
        {

            public static int lonelyinteger(List<int> a)
            {

                List<int> elMero = new List<int>();
                int count;
                for (int i = 0; i < a.Count; i++)
                {
                    count = 0;
                    for (int j = 0; j < a.Count; j++)
                    {
                        if (a[i] == a[j])
                        {
                            count++;
                            if (count > 1)
                            {
                                elMero.Add(a[i]);
                                count--;
                            }

                        }
                    }
                }

                foreach (int num in elMero) 
                {
                    a.Remove(num);
                }
                
                return a[0];
            }
        }
        static void Main()
        {
            //System.IO.TextWriter textWriter = new System.IO.StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> a = new List<int> { 1, 2, 3, 4, 4, 16, 3, 2, 1, 5, 16, 100, 200, 250 ,255, 255, 250, 200, 100 };

            int result = Result.lonelyinteger(a);

            Console.WriteLine(result);
            Console.ReadLine();
            
        }
    
    }
}
