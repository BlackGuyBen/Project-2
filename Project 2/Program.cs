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
        public static void ReadDataTXT()
        {
            try
            {
                using (var NFL = new StreamReader(@"C:\Users\olubeno\OneDrive - dunwoody.edu\Spring 2018\CWEB - Advanced Programming\Visual Studio\Project 2\Super_Bowl_Project.csv"))
                {
                    string line;
                    while ((line = NFL.ReadLine())  != null)
                    {
                        WriteDataTXT(line);
                    }
                    /*foreach (var lineNumber in NFL)
                    {
                        String line = NFL.ReadToEnd();
                        WriteDataTXT(line); //write the file to txt
                    }*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);
            }

        }//End of TXT

         //write the the csv to txt
        public static void WriteDataTXT(string line)
        {
            string SuperBowlStats;

            Console.WriteLine("Please type the location you would like to" +
                               "to save the file to?");
            SuperBowlStats = Console.ReadLine();


            //COME BACK TO THIS MAY NOT BE RIGHT
            if (!File.Exists(SuperBowlStats))
            {
                File.Create(SuperBowlStats);
            }
            

            List<string> ListA = new List<string>();
            List<string> ListB = new List<string>();
            List<string> ListC = new List<string>();
            

            var EachRow = line.Split(',');



        }
        

        //HTML STARTING. COME BACK TO THIS IF YOU HAVE TIME.
        public static void ReadDataHTML()
        {
            try
            {
                using (var NFL = new StreamReader(@"C:\Users\olubeno\OneDrive - dunwoody.edu\Spring 2018\CWEB - Advanced Programming\Visual Studio\Project 2\Super_Bowl_Project.csv"))
                {
                    string line;
                    while ((line = NFL.ReadLine()) != null)
                    {
                        WriteDataHTML(line);
                    }
                    /*foreach (var lineNumber in NFL)
                    {
                        String line = NFL.ReadToEnd();
                        //write the file to html
                    }*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The File could not be read");
                Console.WriteLine(e.Message);
            }
        }//end of HTML

        public static void WriteDataHTML(string line)
        {
            string SuperBowlStats;

            Console.WriteLine("Please type the location you would like to" +
                               "to save the file to?");
            SuperBowlStats = Console.ReadLine();
        }
    }

    
}

