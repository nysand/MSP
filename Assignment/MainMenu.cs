using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class MainMenu
    {
        public static void MainMenuDisplay()//Display Method - Main Menu

        {            
            Console.WriteLine("##############################################################################");
            Console.WriteLine("###   ####  ##  #####  ##         #######    ######   ####  ####       #######");
            Console.WriteLine("###  #  ##  ###  ###  ##  ##############  ##  #####  #  ##  ####  ####  ######");
            Console.WriteLine("###  ##  #  ####     ####         #####  ####  ####  ##  #  ####  #####  #####");
            Console.WriteLine("###  ###    ###### #############   ###  #    #  ###  ###    ####  #####  #####");
            Console.WriteLine("###  #####  ###### ############   ###  ########  ##  #####  ####  ####  ######");
            Console.WriteLine("###  #####  ###### #####         ###  ##########  #  #####  ####       #######");
            Console.WriteLine("##############################################################################");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("==================");
            Console.WriteLine("1. New booking");
            Console.WriteLine("2. View bookings");
            Console.WriteLine("3. Delete bookings");
            Console.WriteLine("4. Exit program");
            Console.WriteLine("==================");
            Console.Write("Please select your option: ");
            return;
        }

        public static void NextMainMenu()//Display Method - Next Menu
        {
            int input;
            int.TryParse(Console.ReadLine(), out input);//Convert input to int

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("New booking");
                    Console.WriteLine("==================");
                    Boat.NewBoatEntry();
                    Console.WriteLine("Press enter to return to the main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                    
                case 2:
                    Console.Clear();
                    Console.WriteLine("View bookings");
                    Console.WriteLine("The total marina space left is {0} m.",Marina.TotalMarinaSpaceCheck());
                    Console.WriteLine("==================");
                    DisplayActions.DisplayData();
                    Console.WriteLine("Press enter to return to the main menu.");                    
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Delete bookings");
                    Console.WriteLine("==================");
                    DisplayActions.DisplayData();
                    DisplayActions.RemoveBoat(input);
                    Console.WriteLine("Press enter to return to the main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;
                    
                default:
                    Console.WriteLine("Please select a number from 1 to 4");
                    Console.ReadLine();
                    Console.WriteLine("Press any key to continue");
                    Console.Clear();
                    break;
            }

            return;//return the method
        }   
    }
}
