using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Assignment
{
    class Boat
    {
        private static string ownerName;
        private static string boatName;
        private static string boatLength;
        private static string boatDraft;
        private static string boatType;
        private static string monthInput;
        
        //Boat Constructor
        public Boat(string ownerName, string boatName, int boatLength, double boatDraft, string boatType, int monthInput, int totalPrice, string exactDate)
        {
            OwnerName = ownerName;
            BoatName = boatName;
            BoatLength = boatLength;
            BoatDraft = boatDraft;
            BoatType = boatType;
            MonthInput = monthInput;
            TotalPrice = totalPrice;
            ExactDate = exactDate;            
        }

        public string OwnerName { get; set; }
        public string BoatName { get; set; }
        public int BoatLength { get; set; }
        public double BoatDraft { get; set; }
        public string BoatType { get; set; }
        public int MonthInput { get; set; }
        public int TotalPrice { get; set; }
        public string ExactDate { get; set; }

        public static int StayPrice(int time, int boatLength)//Price of the booking method/formula
        {
            int price = 10;
            int totalPrice = boatLength * price * time;
            return totalPrice;
        }

        public static string DateTimeEnd(int bookingTime)//Datetime method and conversion to string
        {
            var now = DateTime.Now;
            var nowPlus = now.AddMonths(bookingTime);
            var StartOfMonth = new DateTime(now.Year, now.Month, now.Day);
            var StartOfNextMonth = StartOfMonth.AddMonths(bookingTime);
            string dateString = StartOfNextMonth.ToString("dd/MM/yyyy");
            return dateString;
        }

        public static void NewBoatEntry()//Assignning input to the variables and variable validation
        {
            Console.WriteLine("Please enter the name of the owner.");

            while (true)
            {
                ownerName = Console.ReadLine();
                    if (string.IsNullOrEmpty(ownerName))
                    {
                        Console.WriteLine("Please enter your name.");
                        continue;
                    }
                    else break;
            }

            Console.WriteLine("Please enter the name of the boat.");

            while (true)
            {
                boatName = Console.ReadLine();
                    if (string.IsNullOrEmpty(boatName))
                    {
                        Console.WriteLine("Please enter the name of the boat.");
                        continue;
                    }
                    else break;
             }

            Console.WriteLine("Please enter the boat type. (motor, narrow or sailing)");

            while (true)
            {
                boatType = Console.ReadLine();
                if (boatType == "motor")
                {
                    break;
                }
                else if (boatType == "sailing")
                {
                    break;
                }
                else if (boatType == "narrow")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The boat type can be only: motor, narrow or sailing. Please try again.");
                    continue;
                }
            }
            
            bool checkLength;
            int boatLengthInt = 0;            
            while (true)
            {
                Console.WriteLine("Please enter the length of the boat.");
                boatLength = Console.ReadLine();
                checkLength = int.TryParse(boatLength, out boatLengthInt);
                int verifySpace = Marina.TotalMarinaSpaceCheck();//Checking the marina space against the new boat length entry

                if (checkLength && boatLengthInt > 15)
                {
                    Console.WriteLine("The boat lenght cannot exced 15 meters.");
                    continue;
                }
                else if (checkLength && boatLengthInt < 1)
                {
                    Console.WriteLine("The boat lenght cannot be 0 meters or less.");
                    continue;
                }
                else if (!checkLength)
                {
                    Console.WriteLine("Please enter a valid value.");
                    continue;
                }
                else if (verifySpace < boatLengthInt)
                {
                    Console.WriteLine("There is no more space in the marina.");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                else
                {
                    break;
                }               
            }

            Console.WriteLine("Please enter the draft of the boat.");

            while (true)
            {
                boatDraft = Console.ReadLine();
                bool checkDraft;
                double boatDraftInt;
                checkDraft = double.TryParse(boatDraft, out boatDraftInt);

                if (checkDraft && boatDraftInt > 5)
                {
                    Console.WriteLine("The boat draft cannot exced 5 meters.");
                    continue;
                }
                else if (checkDraft && boatDraftInt< 1)
                {
                    Console.WriteLine("The boat draft cannot be 0 meters.");
                    continue;
                }
                else if (!checkDraft)
                {
                    Console.WriteLine("Please enter a valid value.");
                    continue;
                }
                else break;
            }            

                Console.WriteLine("Please enter the duration of your stay in months.");
                
                while (true)
                {
                    monthInput = Console.ReadLine();
                    bool checkMonthInput;
                    int monthInputInt;
                    checkMonthInput = int.TryParse(monthInput, out monthInputInt);                    

                if (!checkMonthInput)
                    {
                        Console.WriteLine("Please enter a valid value.");
                        continue;
                    }
                    else
                    {                       
                        Console.WriteLine("The price for the stay is: {0} £", StayPrice(monthInputInt, boatLengthInt));
                        Console.WriteLine("Your booking ends on {0}",DateTimeEnd(monthInputInt));
                        break;
                    }
                }            

            Console.WriteLine("Press the return key to accept or enter -1 to reject");
            string lastinput = Console.ReadLine();
            bool checkLastInput;
            int lastInputInt;
            checkLastInput = int.TryParse(lastinput, out lastInputInt);

            while (true)
            {
                if (lastInputInt != -1)
                {   
                    //creating the boat object
                    Boat boat = new Boat(ownerName, boatName, int.Parse(boatLength), double.Parse(boatDraft), boatType, int.Parse(monthInput), StayPrice(int.Parse(Boat.monthInput), int.Parse(Boat.boatLength)), DateTimeEnd(int.Parse(Boat.monthInput)));
                    Marina.AddBoat(boat);//Add new boat to list                 
                    break;                    
                }
                else
                {
                    Environment.Exit(0);
                    break;
                }                
            }          
        }
    }
}
    
