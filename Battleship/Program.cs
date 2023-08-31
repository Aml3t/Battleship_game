using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Models;

namespace Battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerInfoModel playerOne = new PlayerInfoModel();
            PlayerInfoModel playerTwo = new PlayerInfoModel();

            Console.Write("Enter Player One name: ");
            playerOne.UsersName = Console.ReadLine();

            Console.Write("Enter Player Two name: ");
            playerTwo.UsersName = Console.ReadLine();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter ship's number {i + 1} location Letter");
                string hitLetter = Console.ReadLine();
                Console.Write($"Enter ship's number {i + 1} location Number");
                string hitNumber = Console.ReadLine();
                string hit = string.Concat(hitLetter, hitNumber);

                playerOne.ShipLocation.Add(hit);
            }

        }
    }
}
