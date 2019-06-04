using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Assignment
{
    class Marina
    {
        //creating the list where the object will be stored
        public static List<Boat> Boats = new List<Boat>();
        public static int marinaSpace = 150;//total marina space

        public static void WriteData()//writing data to file (Newtonsoft.com, 2018)
        {
            try
            {
                string writeData = JsonConvert.SerializeObject(Marina.Boats);
                File.WriteAllText("NewBoatsEntry.json", writeData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Write to file process could not be started because file is missing.");                
            }
            
        }

        public static void ReadData()//reading data from file
        {
            try
            {
                string readData = File.ReadAllText("NewBoatsEntry.json");
                Marina.Boats = JsonConvert.DeserializeObject<List<Boat>>(readData);
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
                Console.WriteLine("Read from file process could not be started because file is missing.");               
            }
            
        }

        public static int MarinaSpaceCheck()//method which counts the boats stored in the file and summs up the boat lengths.
        {
            //Read Data from file first
            Marina.ReadData();
            int sum = 0;
            for (int i = 0; i < Marina.Boats.Count; i++)//counts the boats in the list
            {
                Boat boat = Marina.Boats[i];
                sum = sum + boat.BoatLength;//sums up the boat lengths
            }
            return sum;
        }

        public static int TotalMarinaSpaceCheck()//subtract all boat lengths from previous method from 150 which is total marina space
        {
            int totalMarinaSpaceCheckInt = marinaSpace - MarinaSpaceCheck();
            return totalMarinaSpaceCheckInt;
        }

        public static bool AddBoat(Boat boat)
        {                                  
            if (TotalMarinaSpaceCheck() < boat.BoatLength)//checking space left
            {                
                Console.WriteLine("There is no more space in the marina. Please try again later.");
                return false;
            }
            else
            {
                Boats.Add(boat);//adding new boat to the list               
                Console.WriteLine("Your new booking has been submitted.");                
                WriteData();//writing data to the file
                return true;
            }  
        } 
    }
}
