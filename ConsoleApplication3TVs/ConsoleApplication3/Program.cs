using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{

    class Program
    {
        private static string subdivision = "brand";
        private static string quantity = "quantity";
        private static string filePath = "D:\\workspace\\c_sharp\\files\\lb5\\file_tvsets.txt";
        
        static void Main(string[] args)
        {
            run();
        }
        

        static void showMenu()
        {
            Console.WriteLine("Choose an option:\n" +
                " 1 - Enter new record\n" +
                " 2 - View all the data\n" +
                " 3 - View data of {0}\n" +
                " 4 - Remove record\n" +
                " 5 - Edit record\n" +
                " 6 - Sort by {0}\n" +
                " 7 - Exit", subdivision);
        }

        static void run()
        {
            bool t = true;
            while (t)
            {
                showMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    {
                        t = enterNewRecord(); break;
                    }
                    case "2":
                    {
                        t = viewAllTheData(); break;
                    }
                    case "3":
                    {
                        t = viewSubdivData(); break;
                    }
                    case "4":
                    {
                        t = removeRecord(); break;
                    }
                    case "5":
                    {
                        t = editRecord(); break;
                    }
                    case "6":
                    {
                        t = sortBySubdevision(); break;
                    }
                    case "7":
                    {
                        t = exit(); break;
                    }
                }
            }
        }

        static bool enterNewRecord()
        {
            string stringToWrite = getRecord();
            writeStringInFile(stringToWrite);

            Console.WriteLine("A new record has been entereed.\n");
            return true;
        }

        static bool viewAllTheData()
        {
            string[] text = getAllDataFromFile();
            Console.WriteLine("All data of application is:\n");
            printLines(text);

            Console.WriteLine("\n");
                            
            return true;
        }

        static bool viewSubdivData() 
        {
            Console.WriteLine("Enter name of {0} you want to look through\n", subdivision);
            string criteria = Console.ReadLine().Trim();

            string[] text = getAllDataFromFile();
            List<string> result = new List<string>();

            foreach (string s in text) 
            {
                if (s.Trim().StartsWith(criteria)) 
                {
                    result.Add(s);
                }
            }

            printLines(result);
            Console.WriteLine("\n");
            
            return true;
        }
       
        static bool removeRecord()
        {
           
            Console.WriteLine("Enter number of the record to be deleted: \n");
            int d = Int32.Parse(Console.ReadLine()) - 1;

            string[] lines = getAllDataFromFile();
            int kol = lines.Length;

            if (d > kol)
            {
                Console.WriteLine("There is no record with such number.");
            }
            else
            {
                File.WriteAllText(filePath, string.Empty);
                writeStringsInFile(lines, 0, d);
                writeStringsInFile(lines, d+1, kol);
            }
            Console.WriteLine("Record has been removed.");
            Console.WriteLine("\n");
            return true;
        }

        static bool sortBySubdevision()
        {          
            string[] text = getAllDataFromFile();

            List<string> subdivItems = text.ToList();
            subdivItems.Sort();


            File.WriteAllText(filePath, string.Empty);
            writeStringsInFile(subdivItems);

            Console.WriteLine("Items have been sort by {0}.\n", subdivision);
            
            return true;
        }

        static bool editRecord()
        {
            Console.WriteLine("Enter number of the record to be edited: \n");
            int d = Int32.Parse(Console.ReadLine()) - 1;

            string[] lines = getAllDataFromFile();
            int kol = lines.Length;

            if (d > kol)
            {
                Console.WriteLine("There is no record with such number.");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Enter new record: \n");
                lines[d] = getRecord();
                File.WriteAllText(filePath, string.Empty);
                writeStringsInFile(lines, 0, kol);
                Console.WriteLine("\n");
            }
            return true;
        }

        static bool exit()
        {
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
            return false;
        }

        static void writeStringInFile(string line)
        {
            using (StreamWriter file = new StreamWriter(filePath, true))
            {
                file.WriteLine(line);
            }
        }

        static void writeStringsInFile(List<string> list)
        {
            using (StreamWriter file = new StreamWriter(filePath, true))
            {
                foreach(string s in list)
                {
                    file.WriteLine(s);
                }
            }
        }

        static void writeStringsInFile(string[] strings, int first, int last) 
        {
            if (first < last) 
            {
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    for (int i = first; i < last; i++)
                    {
                        file.WriteLine(strings[i]);
                    }

                }
            }
        }

        static string[] getAllDataFromFile()
        {
            string text = System.IO.File.ReadAllText(filePath);
            string[] separators = { "\n" };
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        static void printLines(string[] lines)
        {
            foreach (string s in lines)
            {
                Console.WriteLine(s);
            }
        }

        static void printLines(List<string> lines)
        {
            foreach (string s in lines)
            {
                Console.WriteLine(s);
            }
        }

        static string getRecord() 
        {
            Console.WriteLine("Enter " + subdivision);
            string inputSubdevision = Console.ReadLine();
            Console.WriteLine("Enter " + quantity);
            int inputQuantity = Int32.Parse(Console.ReadLine());

            return inputSubdevision + " " + inputQuantity.ToString() + " ";
        }
    }
}