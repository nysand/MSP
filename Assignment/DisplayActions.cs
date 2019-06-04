using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    class DisplayActions
    {
        public static void DisplayData()
        {
            //Read Data first
            Marina.ReadData();

            for (int i = 0; i < Marina.Boats.Count; i++)//adds index number for the boat entries
            {
                Boat boat = Marina.Boats[i];
                Console.WriteLine("Entry:" + i + "\nOwner Name: {0}\nBoat Name: {1}\nBoat Type: {2}\nBoat Length: {3} m\nBoat Draft: {4} m\nPeriod of stay in months: {5}\nPrice of the booking: {6} £\nBooking end date: {7}\n==================", boat.OwnerName, boat.BoatName, boat.BoatType, boat.BoatLength, boat.BoatDraft, boat.MonthInput, boat.TotalPrice, boat.ExactDate);
            }
        }
               
        public static void RemoveBoat(int index)
        {
            Marina.ReadData();
            Console.WriteLine("Please select the entry number coresponding to the booking you wish to delete.");
            string removeIndex = Console.ReadLine();
            bool checkIndex;
            int removeBoatIndex;
            checkIndex = int.TryParse(removeIndex, out removeBoatIndex);

            if (checkIndex == true)
            {
                if (removeBoatIndex >= 0 && removeBoatIndex < Marina.Boats.Count)
                {
                    var removedBoat = Marina.Boats[removeBoatIndex];
                    Marina.Boats.RemoveAt(removeBoatIndex);//removes the boat based on the assinged index
                    Marina.WriteData();//Update data after deleting entry
                    for (int i = removeBoatIndex; i < Marina.Boats.Count; i++)//counting the boats after the deleted boat to get the boat name and move them to the holding bay
                    {
                        Boat boat = Marina.Boats[i];
                        Console.WriteLine("Boat {0}, has been moved to the holding bay to make way for boat {1}.", boat.BoatName, removedBoat.BoatName);
                        Thread.Sleep(2000);//(Forum For Electronics, 2018)
                    }
                    Console.WriteLine("Boat {0} is now moving toward the entrance.", removedBoat.BoatName);
                    Thread.Sleep(2000);
                    Console.WriteLine("Boat {0} leaving the marina.", removedBoat.BoatName);
                    Thread.Sleep(1000);
                    Console.WriteLine("Booking has been deleted. Boat {0} left the marina.", removedBoat.BoatName);
                    for (int i = removeBoatIndex; i < Marina.Boats.Count; i++)
                    {
                        Boat boat = Marina.Boats[i];
                        Console.WriteLine("Boat {0}, has been moved back in the marina.", boat.BoatName);
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("The value you have entered does not match any index number. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("The value you have entered does not match any index number. Please try again.");
            }
            return;
        }
    }
}
