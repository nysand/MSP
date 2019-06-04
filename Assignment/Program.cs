using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Assignment
{    
    class Program
    {
        static void Main(string[] args)
        {            
            Console.ForegroundColor = ConsoleColor.Yellow;            

            while (true)
            {
                Marina.ReadData();
                Marina.MarinaSpaceCheck();
                MainMenu.MainMenuDisplay();
                MainMenu.NextMainMenu();
                Marina.MarinaSpaceCheck();
            }
        }
    }
}
