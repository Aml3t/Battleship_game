using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Battleship
{
    public static class GameLogic
    {
        public static void InitializeGrid(PlayerInfoModel model)
        {
            List<string> letters = new List<string> { "A", "B", "C", "D", "E" };

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            foreach (string letter in letters)
            {
                foreach (int number in numbers)
                {
                    AddGridSpot(model, letter, number);
                }
            }
        }
        public static bool PlaceShip(PlayerInfoModel model, string location)
        {
            bool output = false;
            (string row, int column) = SplitShotIntoRowAndColumn(location);

            bool isValidLocation = ValidateGridLocation(model, row, column);
            bool isSpotOpen = ValidateShipLocation(model, row, column);

            if (isValidLocation == true && isSpotOpen == true)
            {
                model.ShipLocations.Add(new GridSpotModel
                {
                    SpotLetter = row.ToUpper(),
                    SpotNumber = column,
                    Status = GridSpotStatus.Ship
                });
                output = true;
            }

            return output;
            /// Verifing if the user input has the correct format
            //if (location.Length == 2 && Regex.IsMatch(location,"^[A-E][1-5]"))
            //{
            //    GridSpotModel output = new GridSpotModel();
            //    //char firstCharacter = location[0];
            //    //output.SpotLetter = firstCharacter.ToString();
            //    //output.SpotNumber = int.Parse(location[1].ToString());
            //    output.Status = GridSpotStatus.Ship;
            //    model.ShipLocations.Add(output);
            //    return true;
            //}
        }

        private static bool ValidateShipLocation(PlayerInfoModel model, string row, int column)
        {
            bool isValidLocation = true;

            foreach (var ship in model.ShipLocations)
            {
                if (ship.SpotLetter == row.ToUpper() && ship.SpotNumber == column)
                {
                    isValidLocation = false;
                }

                // TODO
                // Check the return mechanism if something goes wrong.
                //else
                //{
                //    Console.WriteLine($"You have already a ship in location {row}{column}");
                //    Console.WriteLine("Retry");
                //    continue;
                //}
            }

            return isValidLocation;
        }

        private static bool ValidateGridLocation(PlayerInfoModel model, string row, int column)
        {
            bool isValidLocation = false;

            foreach (var spot in model.ShotGrid)
            {
                if (spot.SpotLetter == row.ToUpper() && spot.SpotNumber == column)
                {
                    isValidLocation = true;
                }
            }

            return isValidLocation;
        }

        internal static int GetShotCount(PlayerInfoModel player)
        {
            int shotCount = 0;

            foreach (var ship in player.ShotGrid)
            {
                if (ship.Status != GridSpotStatus.Empty)
                {
                    shotCount += 1;
                }
            }
            return shotCount;
        }

        internal static bool IdentifyShotResult(PlayerInfoModel player, string row, int column)
        {
            bool isAHit = false;

            foreach (var ship in player.ShipLocations)
            {
                if (ship.SpotLetter == row.ToUpper() && ship.SpotNumber == column)
                {
                    isAHit = true;
                }
            }
            return isAHit;
        }

        internal static void MarkShotResults(PlayerInfoModel player, string row, int column, bool isAHit)
        {
            foreach (var gridSpot in player.ShotGrid)
            {
                if (gridSpot.SpotLetter == row.ToUpper() && gridSpot.SpotNumber == column)
                {
                    if (isAHit)
                    {
                        gridSpot.Status = GridSpotStatus.Hit;
                        Console.WriteLine("Your shot was a HIT");
                        Console.ReadLine();
                    }
                    else
                    {
                        gridSpot.Status = GridSpotStatus.Miss;
                        Console.WriteLine("Your shot was a MISS");
                        Console.ReadLine();

                    }
                }
            }
        }

        internal static bool PlayerStillActive(PlayerInfoModel player)
        {
            bool isActive = false;

            foreach (var ship in player.ShipLocations )
            {
                if (ship.Status != GridSpotStatus.Sunk)
                {
                    isActive = true;
                }
            }

            return isActive;
        }

        internal static (string row, int column) SplitShotIntoRowAndColumn(string shot)
        {
            string row = "";
            int column = 0;

            if (shot.Length == 2 && Regex.IsMatch(shot, "^[A-E][1-5]"))
            {
                row = shot[0].ToString();
                column = int.Parse(shot[1].ToString());
            }

            return (row, column);
        }

        internal static bool ValidateShot(PlayerInfoModel player, string row, int column)
        {
            bool isValidShot = false;

            foreach (var gridSpot in player.ShotGrid)
            {
                if (gridSpot.SpotLetter == row.ToUpper() && gridSpot.SpotNumber == column)
                {
                    if (gridSpot.Status == GridSpotStatus.Empty)
                    {
                        isValidShot = true;
                    }
                }
            }

            return isValidShot;
        }

        private static void AddGridSpot(PlayerInfoModel model, string letter, int number)
        {
            GridSpotModel spot = new GridSpotModel
            {
                SpotLetter = letter,
                SpotNumber = number,
                Status = GridSpotStatus.Empty
            };

            model.ShotGrid.Add(spot);
        }
    }
}
