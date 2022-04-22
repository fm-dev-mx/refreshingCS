using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Conversion
{
    class Result
    {

        /*
         * Complete the 'timeConversion' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string timeConversion(string s)
        {

            char[] hour = s.ToCharArray();                        
            
            string horaP = Convert.ToString(hour[0]) + Convert.ToString(hour[1]);
            string minP = Convert.ToString(hour[3]) + Convert.ToString(hour[4]);
            string segP = Convert.ToString(hour[6]) + Convert.ToString(hour[7]);
            string m = Convert.ToString(hour[8]) + Convert.ToString(hour[9]);

            string convertedTime = "";
            int hora24 = Convert.ToInt32(horaP);

            if (m == "PM" && horaP != "12")
                horaP = (hora24+12).ToString();            
            else if (m == "AM" && hora24 == 12)
                horaP = "00";
            
            convertedTime = horaP + ":" + minP + ":" + segP;

            return convertedTime;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {


            //TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("PATH"), true);

            //Console.WriteLine(TimeZoneInfo.Local.DisplayName);
            
           

            string result = Result.timeConversion("11:59:00PM");

            Console.WriteLine(result);            
            string s = Console.ReadLine();
        }
    }
}
