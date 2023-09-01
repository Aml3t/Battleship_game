using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Battleship.Models;

namespace Battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();


        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship game");
            Console.WriteLine("Enjoy the game");
            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer()
        {
            PlayerInfoModel output = new PlayerInfoModel();

            // Ask users name
            output.UsersName = AskForUsersName();

            // Load up the shot grid
            GameLogic.InitializeGrid(output);

            // Ask the user for their 5 ship placements
            PlaceShips(output);
            // Clear

            return output;
        }

        private static string AskForUsersName()
        {
            Console.Write("Enter player name: ");
            string output = Console.ReadLine();
            return output;
        }

        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"Place the ship number {model.ShipLocation.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(model, location);

                if (isValidLocation == false)
                {
                    Console.WriteLine("You entered a wrong location. Try again");
                }

            } while (model.ShipLocation.Count < 5);

        }
    }
}
