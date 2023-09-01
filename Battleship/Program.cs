using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            // Clear

            return output;
        }

        private static string AskForUsersName()
        {
            Console.Write("Enter player name: ");
            string output = Console.ReadLine();
            return output;
        }

        private static void SetGrid(PlayerInfoModel model)
        {

        }

    }
}
