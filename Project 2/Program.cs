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
            else if (fileType == "HTML")
            {
                ReadDataHTML();
            }
            else
            {
                Console.WriteLine("Invalid Entry. Please try again.");
                Main(args);
            }
        }
        public static void ReadDataTXT()
        {
            const string NFLFile = @"C:\Users\olubeno\OneDrive - dunwoody.edu\Spring 2018\CWEB - Advanced Programming\Visual Studio\Project 2\Super_Bowl_Project.csv";
            List<Stats> statsIn = new List<Stats>();
            string[] StatsFromFile;
            Stats OneRow;
            

            try
            {
                //Change file path if needed.
                //using (var NFL = new StreamReader(@"C:\Users\olubeno\OneDrive - dunwoody.edu\Spring 2018\CWEB - Advanced Programming\Visual Studio\Project 2\Super_Bowl_Project.csv"))
                {
                    //string line;
                    FileStream Stats = new FileStream(NFLFile, FileMode.Open, FileAccess.Read);
                    StreamReader readIn = new StreamReader(Stats);

                    while (!readIn.EndOfStream)
                    {
                        StatsFromFile = readIn.ReadLine().Split(',');
                        OneRow = new Stats(StatsFromFile[0], StatsFromFile[1], Convert.ToDouble(StatsFromFile[2]), StatsFromFile[3],
                                            StatsFromFile[4], StatsFromFile[5], Convert.ToInt32(StatsFromFile[6]), StatsFromFile[7],
                                            StatsFromFile[8], StatsFromFile[9], Convert.ToInt32(StatsFromFile[10]), StatsFromFile[11],
                                            StatsFromFile[12], StatsFromFile[13], StatsFromFile[14]);
                        statsIn.Add(OneRow);
                    }
                    readIn.Close();
                    Stats.Close();
                
                    
                    /*foreach (var lineNumber in NFL)
                    {
                        line = NFL.ReadToEnd();
                        WriteDataTXT(line); //call to write the file to txt
                    }*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }//End of TXT

         //write the the csv to txt
        public static void WriteDataTXT(string line)
        {
            //THIS SHOULDN'T BE HERE. IT IS REPEATING WHERE TO SAVE THE FILE EVERY TIME
            try
            {
                string SuperBowlStats;
                string FilePath;
                var EachRow = line.Split(',');
                
                Console.WriteLine("Please type the name of the file. (You don't need to type the extention)");
                SuperBowlStats = Console.ReadLine();

                Console.WriteLine("Where would you like to save the file to?");
                FilePath = Console.ReadLine();

                //COME BACK TO THIS MAY NOT BE RIGHT
                if (!File.Exists(FilePath))
                {
                    File.Create(FilePath);
                    TextWriter text = new StreamWriter(FilePath);
                    text.WriteLine(line);
                    text.Close();
                }
            }

            catch (Exception i)
            {
                Console.WriteLine("The file could not be created.");
                Console.WriteLine(i.Message);
            }
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

        public bool EndOfStream { get; }
    }
    class Stats
    {
        public string DateFromFile { get; set; }
        public string SBFromFile { get; set; }
        public double AttFromFile { get; set; }
        public string[] QBWinFromFile { get; set; }
        public string[] CoachWinFromFile { get; set; }
        public string[] WinnerFromFile { get; set; }
        public int WinPtFromFile { get; set; }
        public string[] QBLoserFromFile { get; set; }
        public string[] CoachLostFromFile { get; set; }
        public string[] LoserFromFile { get; set; }
        public int LosingPtFromFile { get; set; }
        public string[] MVPFromFile { get; set; }
        public string[] StadiumFromFile { get; set; }
        public string[] CityFromFile { get; set; }
        public string[] StateFromFile { get; set; }

        public Stats(string DateFromFile, string SBFromFile, double AttFromFile,
            string QBWinFromFile, string CoachWinFromFile, string WinnerFromFile,
            int WinPtFromFile, string QBLoserFromFile, string CoachLostFromFile,
            string LoserFromFile, int LosingPtFromFile, string MVPFromFile, 
            string StadiumFromFile, string CityFromFile, string StateFromFile)
        {
            this.DateFromFile = DateFromFile;
        }

    }

    
}

