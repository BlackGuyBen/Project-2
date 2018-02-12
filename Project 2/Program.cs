using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileType;
            Console.WriteLine("This program will show the SuperBowl stats in a preferred viewing method (HTLM or TXT)");

            Console.WriteLine("Please enter your preferred method - TXT or HTML");
            fileType = Console.ReadLine();
            fileType = fileType.ToUpper();

            if (fileType == "TXT")
            {
                ReadDataTXT();
            }
            else
            {
                ReadDataHTML();
            }
        }
        static void ReadDataTXT()
        {
            try
            {
                using (var NFL = new StreamReader(@"C:Super_Bowl_Project.csv"))
                {
                    foreach (var lineNumber in NFL)
                    {
                        String line = NFL.ReadToEnd();
                        //write the file to txt
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);
            }
        }//End of TXT
        
        static void ReadDataHTML()
        {
            try
            {
                using (var NFL = new StreamReader(@"C:Super_Bowl_Project.csv"))
                {
                    foreach (var lineNumber in NFL)
                    {
                        String line = NFL.ReadToEnd();
                        //write the file to html
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The File could not be read");
                Console.WriteLine(e.Message);
            }
        }//end of HTML
    }

    
}

