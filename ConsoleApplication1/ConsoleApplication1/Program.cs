using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        private String department;
        private int quantity;

        Program(String department, int quantity)
        {
            this.department = department;
            this.quantity = quantity;
        }

        static void Main(string[] args)
        {
            Boolean t = true;

            while (t)
            {
                Console.WriteLine("Choose an option:\n 1 - Enter new record\n 2 - View all the data\n 3 - View subdivisin's data\n" + " 4 - Remove record\n 5 - Edit record\n 6 - Sort by subdevision\n 7 - Exit");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter subdivision");
                            String subdevision = Console.ReadLine();
                            Console.WriteLine("Enter quantity of employees");
                            int quantity = Int32.Parse(Console.ReadLine());
                            Program obj = new Program(subdevision, quantity);
                            FileStream fstr = new FileStream(@"D:\workspace\c_sharp\files\lb5\file.txt", FileMode.OpenOrCreate, FileAccess.Write);
                            fstr.Seek(0, SeekOrigin.End);
                            StreamWriter sw = new StreamWriter(fstr);
                            sw.WriteLine(obj.department + " " + obj.quantity.ToString() + " ");
                            sw.Close();
                            fstr.Close();
                            break;
                        }
                    case "2":
                        {
                            string text = System.IO.File.ReadAllText(@"D:\workspace\c_sharp\files\lb5\file.txt");
                            System.Console.WriteLine("All data of application is:\n{0}", text);
                            break;
                        }

                    case "3":
                        {
                            string line;
                            int quant = 0;
                            Console.WriteLine("Enter number of subdivision:\n 01 - Accounting\n 02 - HRD\n 03 - PD\n 04 - R&D\n");
                            String department = Console.ReadLine();
                            System.IO.StreamReader file = new System.IO.StreamReader(@"D:\workspace\c_sharp\files\lb5\file.txt");


                            switch (department)
                            {

                                case "01":
                                    {
                                        while ((line = file.ReadLine()) != null)
                                        {
                                            string[] separators = { " " };
                                            string[] words = line.Split(separators, StringSplitOptions.None);
                                            if (words[0].Equals("Accounting"))
                                            {
                                                quant += Int32.Parse(words[1]);
                                            }
                                        }
                                        Console.WriteLine("Accounting " + quant);
                                        break;
                                    }
                                case "02":
                                    {
                                        while ((line = file.ReadLine()) != null)
                                        {
                                            string[] separators = { " " };
                                            string[] words = line.Split(separators, StringSplitOptions.None);
                                            if (words[0].Equals("HRD"))
                                            {
                                                quant += Int32.Parse(words[1]);
                                            }
                                        }
                                        Console.WriteLine("HRD " + quant);
                                        break;
                                    }
                                case "03":
                                    {
                                        while ((line = file.ReadLine()) != null)
                                        {
                                            string[] separators = { " " };
                                            string[] words = line.Split(separators, StringSplitOptions.None);
                                            if (words[0].Equals("PD"))
                                            {
                                                quant += Int32.Parse(words[1]);
                                            }
                                        }
                                        Console.WriteLine("PD " + quant);
                                        break;
                                    }
                                case "04":
                                    {
                                        while ((line = file.ReadLine()) != null)
                                        {
                                            string[] separators = { " " };
                                            string[] words = line.Split(separators, StringSplitOptions.None);
                                            if (words[0].Equals("R&D"))
                                            {
                                                quant += Int32.Parse(words[1]);
                                            }
                                        }
                                        Console.WriteLine("R&D " + quant);
                                        break;
                                    }
                            }
                            break;
                        }
                    case "4":
                        {
                            string text = System.IO.File.ReadAllText(@"D:\workspace\c_sharp\files\lb5\file.txt");
                            System.Console.WriteLine("All data of application is:\n{0}", text);
                            Console.WriteLine("Enter number of the record to be deleted: \n");
                            int d = Int32.Parse(Console.ReadLine()) - 1;

                            string[] separators = { "\n" };
                            string[] lines = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            int kol = lines.Length;

                            using (var file = new StreamWriter(@"D:\workspace\c_sharp\files\lb5\file.txt"))
                            {
                                for (int i = 0; i < kol; i++)
                                {
                                    if (i != d)
                                    {
                                        file.WriteLine(lines[i]);
                                    }
                                }
                            }
                            text = System.IO.File.ReadAllText(@"D:\workspace\c_sharp\files\lb5\file.txt");
                            System.Console.WriteLine("All data of application is:\n{0}", text);
                            break;
                        }
                    case "5":
                        {
                            string text = System.IO.File.ReadAllText(@"D:\workspace\c_sharp\files\lb5\file.txt");
                            System.Console.WriteLine("All data of application is:\n{0}", text);
                            Console.WriteLine("Enter number of the record to be edited: \n");
                            int d = Int32.Parse(Console.ReadLine()) - 1;

                            string[] separators = { "\n" };
                            string[] lines = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            int kol = lines.Length;

                            Console.WriteLine("Enter new record: \n" + " Enter subdivision: \n");
                            String subdevision = Console.ReadLine();
                            Console.WriteLine("Enter quantity of employees");
                            int quantity = Int32.Parse(Console.ReadLine());

                            lines[d] = subdevision + " " + quantity.ToString();

                            using (var file = new StreamWriter(@"D:\workspace\c_sharp\files\lb5\file.txt"))
                            {
                                for (int i = 0; i < kol; i++)
                                {
                                    {
                                        file.WriteLine(lines[i]);
                                    }
                                }
                            }
                            text = System.IO.File.ReadAllText(@"D:\workspace\c_sharp\files\lb5\file.txt");
                            System.Console.WriteLine("All data of application is:\n{0}", text);
                            break;
                        }
                    case "6":
                        {
                            List<Int32> accounting = new List<Int32>();
                            List<Int32> hrd = new List<Int32>();
                            List<Int32> pd = new List<Int32>();
                            List<Int32> r_d = new List<Int32>();
                            string line;
                            Console.WriteLine("Enter the number of subdivision you want to sort:\n 01 - Accounting\n 02 - HRD\n 03 - PD\n 04 - R&D\n");
                            String department = Console.ReadLine();
                            System.IO.StreamReader file = new System.IO.StreamReader(@"D:\workspace\c_sharp\files\lb5\file.txt");

                            switch (department)
                            {
                                case "01":
                                    {
                                        while ((line = file.ReadLine()) != null)
                                        {
                                            string[] separators = { " " };
                                            string[] words = line.Split(separators, StringSplitOptions.None);
                                            if (words[0].Equals("Accounting"))
                                            {
                                                accounting.Add(Int32.Parse(words[1]));
                                            }
                                        }
                                        accounting.Sort();
                                        Console.Write("Accounting: " + "\n");
                                        foreach (var record in accounting)
                                            Console.Write("   {0}", record + "\n");
                                        break;
                                    }
                                case "02":
                                    {
                                        while ((line = file.ReadLine()) != null)
                                        {
                                            string[] separators = { " " };
                                            string[] words = line.Split(separators, StringSplitOptions.None);
                                            if (words[0].Equals("HRD"))
                                            {
                                                hrd.Add(Int32.Parse(words[1]));
                                            }
                                        }
                                        hrd.Sort();
                                        Console.Write("HRD: " + "\n");
                                        foreach (var record in hrd)
                                            Console.Write("   {0}", record + "\n");
                                        break;
                                    }
                                case "03":
                                    {
                                        while ((line = file.ReadLine()) != null)
                                        {
                                            string[] separators = { " " };
                                            string[] words = line.Split(separators, StringSplitOptions.None);
                                            if (words[0].Equals("PD"))
                                            {
                                                pd.Add(Int32.Parse(words[1]));
                                            }
                                        }
                                        pd.Sort();
                                        Console.Write("PD: " + "\n");
                                        foreach (var record in pd)
                                            Console.Write("   {0}", record + "\n");
                                        break;
                                    }
                                case "04":
                                    {
                                        while ((line = file.ReadLine()) != null)
                                        {
                                            string[] separators = { " " };
                                            string[] words = line.Split(separators, StringSplitOptions.None);
                                            if (words[0].Equals("R&D"))
                                            {
                                                r_d.Add(Int32.Parse(words[1]));
                                            }
                                        }
                                        pd.Sort();
                                        Console.Write("R&D: " + "\n");
                                        foreach (var record in r_d)
                                            Console.Write("   {0}", record + "\n");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "7":
                        {
                            t = false;
                            Console.WriteLine("Press any key to exit.");
                            System.Console.ReadKey();
                            break;
                        }
                }
            }
        }
    }
}
