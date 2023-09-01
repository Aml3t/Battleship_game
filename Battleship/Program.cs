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



            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write($"Enter ship's number {i + 1} location Letter: ");
            //    string hitLetter = Console.ReadLine();
            //    Console.Write($"Enter ship's number {i + 1} location Number: ");
            //    string hitNumber = Console.ReadLine();
            //    string hit = string.Concat(hitLetter, hitNumber);

            //    //playerOne.ShipLocation.Add(hit);
            //}

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
            output.UsersName = AskForUsersName();

            return output;
        }

        private static string AskForUsersName()
        {
            Console.Write("Enter player name: ");
            string output = Console.ReadLine();
            return output;
        }


    }
}
