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
            //Console.WriteLine("Please type the file location where Super Bowl Stats is saved:");
            string NFLFile = @"C:\Users\olubeno\OneDrive - dunwoody.edu\Spring 2018\CWEB - Advanced Programming\Visual Studio\Project 2\Super_Bowl_Project.csv";
            List<Stats> statsIn = new List<Stats>();
            string[] StatsFromFile;
            Stats OneRow;

            try
            {
                    
                    FileStream Stats = new FileStream(NFLFile, FileMode.Open, FileAccess.Read);
                    StreamReader readIn = new StreamReader(Stats);
                string header = readIn.ReadLine();
  

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
              
                
            }
            
            catch (Exception e)
            {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);
                Console.WriteLine("The program will now end");
                Console.ReadLine();
            }

            WriteDataTXT(statsIn);

        }//End of TXT

         //write the the csv to txt
        public static void WriteDataTXT(List<Stats> statsIn)
        {
            try
            {
                string FilePath;
                string FileName;

                //Creating the txt File
                Console.WriteLine("Please type the name of the file. (You don't need to type the extention)");
                FileName = Console.ReadLine();
                Console.WriteLine("Where would you like to save the file to?");
                FilePath = Console.ReadLine() + @"\" + FileName + ".txt"; //The Full name of txt file
                Console.WriteLine("Here is your full file name:");
                Console.WriteLine(FilePath);
                Console.ReadLine();

                
                TextWriter writeText = new StreamWriter(FilePath);

                //Writing each row of statsIn to the txt file
                foreach (var row in statsIn)
                {
                    writeText.WriteLine(row);
                    writeText.WriteLine();
                }


  
                
                writeText.Close();
               
            }

            catch (Exception i)
            {
                Console.WriteLine("The file could not be created.");
                Console.WriteLine(i.Message);
                Console.WriteLine("The program will now close");
                Console.ReadLine();
            }
        }

 

        //HTML STARTING. COME BACK TO THIS IF YOU HAVE TIME.
        public static void ReadDataHTML()
        {
            string NFLFile = @"C:\Users\olubeno\OneDrive - dunwoody.edu\Spring 2018\CWEB - Advanced Programming\Visual Studio\Project 2\Super_Bowl_Project.csv";
            List<Stats> statsIn = new List<Stats>();
            string[] StatsFromFile;
            Stats OneRow;

            try
            {

                FileStream Stats = new FileStream(NFLFile, FileMode.Open, FileAccess.Read);
                StreamReader readIn = new StreamReader(Stats);
                string header = readIn.ReadLine();


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


            }

            catch (Exception e)
            {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);
                Console.WriteLine("The program will now end");
                Console.ReadLine();
            }

            WriteDataHTML(statsIn);

          
        }//end of HTML

        public static void WriteDataHTML(List<Stats> statsIn)
        {
            try
            {
                string FilePath;
                string FileName;


                Console.WriteLine("Please type the name of the file. (You don't need to type the extention)");
                FileName = Console.ReadLine();
                Console.WriteLine("Where would you like to save the file to?");
                FilePath = Console.ReadLine() + @"\" + FileName + ".html"; //The Full name of html file
                Console.WriteLine("Here is your full file name:");
                Console.WriteLine(FilePath);
                Console.ReadLine();

                //COME BACK TO THIS MAY NOT BE RIGHT
                TextWriter writeHTML = new StreamWriter(FilePath);

                //Writing each row of statsIn to the html file
                foreach (var row in statsIn)
                {
                    writeHTML.WriteLine(row);
                    writeHTML.WriteLine();
                }

                writeHTML.Close();
            }

            catch (Exception i)
            {
                Console.WriteLine("The file could not be created.");
                Console.WriteLine(i.Message);
            }
        }
        //Winners displayed in text
        public static void Winners(List<Stats> statsIn)
        {
            foreach (var row in statsIn)
            {
                //WriteDataTXT
            }
        }

    }

    class Stats
    {
        public string DateFromFile { get; set; }
        public string SBFromFile { get; set; }
        public double AttFromFile { get; set; }
        public string QBWinFromFile { get; set; }
        public string CoachWinFromFile { get; set; }
        public string WinnerFromFile { get; set; }
        public int WinPtFromFile { get; set; }
        public string QBLoserFromFile { get; set; }
        public string CoachLostFromFile { get; set; }
        public string LoserFromFile { get; set; }
        public int LosingPtFromFile { get; set; }
        public string MVPFromFile { get; set; }
        public string StadiumFromFile { get; set; }
        public string CityFromFile { get; set; }
        public string StateFromFile { get; set; }

        public Stats(string DateFromFile, string SBFromFile, double AttFromFile,
            string QBWinFromFile, string CoachWinFromFile, string WinnerFromFile,
            int WinPtFromFile, string QBLoserFromFile, string CoachLostFromFile,
            string LoserFromFile, int LosingPtFromFile, string MVPFromFile, 
            string StadiumFromFile, string CityFromFile, string StateFromFile)
        {
            this.DateFromFile = DateFromFile;
            this.SBFromFile = SBFromFile;
            this.AttFromFile = AttFromFile;
            this.QBWinFromFile = QBWinFromFile;
            this.CoachWinFromFile = CoachWinFromFile;
            this.WinnerFromFile = WinnerFromFile;
            this.WinPtFromFile = WinPtFromFile;
            this.QBLoserFromFile = QBLoserFromFile;
            this.CoachLostFromFile = CoachLostFromFile;
            this.LoserFromFile = LoserFromFile;
            this.LosingPtFromFile = LosingPtFromFile;
            this.MVPFromFile = MVPFromFile;
            this.StadiumFromFile = StadiumFromFile;
            this.CityFromFile = CityFromFile;
            this.StateFromFile = StateFromFile;

        }

        public override string ToString()
        {
            return String.Format($"Date: {DateFromFile} \nSuperBowl: {SBFromFile} \nAttendance: {AttFromFile} \nWinning QuarterBack: {QBWinFromFile} \nWinning Coach: {CoachWinFromFile} \nWinning Team:{WinnerFromFile}" +
                                $"\nWinning Points: {WinPtFromFile} \nLosing QuarterBack: {QBLoserFromFile} \nLosing Coach: {CoachLostFromFile} \nLosing Team: {LoserFromFile} \nLosing Points: {LosingPtFromFile}" +
                                $"\nMVP For the Game: {MVPFromFile} \nStadium: {StadiumFromFile} \nCity: {CityFromFile} \nState: {StateFromFile}");
        }
        

    }

    
}

