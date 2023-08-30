﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player user1 = new Player();
            Player user2 = new Player();

            Console.Write($"Player 1 enter your First Name: ");
            user1.FirstName = Console.ReadLine();
            Console.Write($"Player 1 enter your Last Name: ");
            user1.LastName = Console.ReadLine();

            Console.Write($"Player 2 enter your First Name: ");
            user2.FirstName = Console.ReadLine();
            Console.Write($"Player 2 enter your Last Name: ");
            user2.LastName = Console.ReadLine();

            Console.WriteLine($"Continuing with the game....");

            List<string> user1List = new List<string>();
            List<string> user2List = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter ship number {i + 1}: ");
                string shipNumber = Console.ReadLine();
                user1List.Add(shipNumber);
            }

            Console.WriteLine("All ships of Player 1 are set. Continuing with Player 2");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter ship number {i +1}: ");
                string shipNumber = Console.ReadLine();
                user2List.Add(shipNumber);
            }

            string list1 = string.Join(", ", user1List);
            string list2 = string.Join(", ", user2List);

            Console.WriteLine("All ships of Player 2 are set. Continuing with the game");

            Console.WriteLine("Let's take a peek at players ships positions(hehe)");

            Console.WriteLine($"First Player boat positions: {list1}");
            Console.WriteLine($"Second Player boat positions: {list2}");


            Console.WriteLine("Player 1 give coordinates: ");

            List<string> grind1hits = new List<string>();
            List<string> grind2hits = new List<string>();

            grind1hits.AddRange(user1List);
            grind2hits.AddRange(user2List);


            while (grind1hits.Count != 0 || grind2hits.Count != 0)
            {
                Console.WriteLine("Player 1 give coordinates: ");
                string hit1 = Console.ReadLine();
                if (grind2hits.Contains(hit1))
                {
                    grind2hits.Remove(hit1);
                }

                if (grind2hits.Count ==0)
                {
                    Console.WriteLine("Player 1 is the WINNER!");
                    break;
                }

                Console.WriteLine("Player 2 give coordinates: ");
                string hit2 = Console.ReadLine();

                if (grind1hits.Contains(hit2))
                {
                    grind1hits.Remove(hit2);
                }

                if (grind1hits.Count == 0)
                {
                    Console.WriteLine("Player 2 is the WINNER!");
                    break;
                }
            }


        }
    }
}
