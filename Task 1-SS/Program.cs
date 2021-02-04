using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fileExists = false;
            string path;
            do
            {
                Console.WriteLine("Please enter full valid text file path:");
                path = Console.ReadLine();
                if (File.Exists(path)) { fileExists = true; }
            } while (!fileExists);

            string readText = File.ReadAllText(path);
            if (readText.Length == 0)
            {
                Console.WriteLine("Text File contains no text");
                Environment.Exit(0);
            }

            string[] cust = File.ReadAllLines(path);
            
            List<Customer> CustomersList = new List<Customer>();

            string[] data = new string[5];

            foreach (string readLn in cust) {
               
                data = readLn.Split(",");
                CustomersList.Add(new Customer(data[0], data[1], data[2], data[3], data[4]));

            }


            Console.WriteLine("\nSelect property by which to sort \n1) First Name\n2) Last Name\n3) ID Number\n4) Cell Phone Number\n5) Email Address\n0) No Sorting Neccessary");


            switch (Console.ReadLine())
            {
                case "1":     //sort by first name
                    {
                        CustomersList = CustomersList.OrderBy(o => o.FName).ToList();
                        break;
                    }

                case "2": 
                    {
                        CustomersList = CustomersList.OrderBy(o => o.LName).ToList();
                        break; 
                    }

                case "3": 
                    {
                        CustomersList = CustomersList.OrderBy(o => o.ID).ToList();
                        break; 
                    }

                case "4": 
                    {
                        CustomersList = CustomersList.OrderBy(o => o.CellNo).ToList();
                        break; 
                    }

                case "5": 
                    {
                        CustomersList = CustomersList.OrderBy(o => o.Email).ToList();
                        break; 
                    }

                case "0": 
                    {

                        break; 
                    }

                default: 
                    {
                        Console.WriteLine("Invalid option selected. Program will now exit...");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                        break; 
                    }


            }

            Console.WriteLine("\n");
            foreach (var customer in CustomersList)
            {
                Console.WriteLine("{0},{1},{2},{3},{4}\n", customer.FName, customer.LName, customer.ID, customer.CellNo, customer.Email);
            }
            Console.WriteLine("\nExport ordered list to new txt file?\nYes / No ");


            switch (Console.ReadLine().ToLower())
            {
                
                case "yes": 
                    {
                        Console.WriteLine("Please enter valid Path for new file:  ");
                        string newFilePath = Console.ReadLine();
                        //File.Create(newFilePath);
                        string readLn = "";
                        foreach (var customer in CustomersList)
                        {
                            readLn = readLn + customer.FName+", "+ customer.LName + ", " + customer.ID + ", " + customer.CellNo + ", " + customer.Email + "\n";
                            using StreamWriter outputFile = new StreamWriter(newFilePath);
                            outputFile.Write(readLn);
                        }
                        break;
                    }
                
                default: 
                    {
                        break;
                    }

            }




        }

    }

    class Customer
    {
        private string fName;
        private string lName;
        private string id;
        private string cellNo;
        private string email;

        public Customer(string fName, string lName, string id, string cellNo, string email)
        {
            this.fName = fName;
            this.lName = lName;
            this.id = id;
            this.cellNo = cellNo;
            this.email = email;
            
        }

        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }

        public string LName
        {
            get { return lName; }
            set { lName = value; }
            
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string CellNo
        {
            get { return cellNo; }
            set { cellNo = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }





    }
}
