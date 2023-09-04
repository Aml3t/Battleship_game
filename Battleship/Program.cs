using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

            PlayerInfoModel activePlayer = CreatePlayer("Player 1");
            PlayerInfoModel opponent = CreatePlayer("Player 2");
            PlayerInfoModel winner = null;

            do
            {
                // Display grind from activePlayer on where they fired
                DisplayShotGrid(activePlayer);

                // Ask activePlayer of a spot
                // Determine if it is a valid shot
                // Determine shot results
                RecordPlayerShot(activePlayer, opponent);

                // Determine if the game should continue
                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);


                // If true, set activePlayer as winner
                // else, swap positions (activePlayer to opponent)

                if (doesGameContinue == true)
                {

                }
                else
                {
                    winner = activePlayer;
                }

            } while (winner == null);

            Console.ReadLine();

        }

        private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            throw new NotImplementedException();
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrind[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrind)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }

                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write(" X ");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O ");
                }
                else
                {
                    Console.Write(" ? ");
                }
            }
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship game");
            Console.WriteLine("Enjoy the game");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            Console.WriteLine($"Player information for {playerTitle}");
            PlayerInfoModel output = new PlayerInfoModel();

            // Ask users name
            output.UsersName = AskForUsersName();

            // Load up the shot grid
            GameLogic.InitializeGrid(output);

            // Ask the user for their 5 ship placements
            PlaceShips(output);

            // Clear the screen
            Console.Clear();

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
                    continue;
                }

            } while (model.ShipLocation.Count < 5);

        }
    }
}
