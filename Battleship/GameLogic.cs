using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (location.Length == 2 && Regex.IsMatch(location,"^[A-E][1-5]"))
            {
                GridSpotModel output = new GridSpotModel();
                char firstCharacter = location[0];
                //int secondCharacter = location[1];
                output.SpotLetter = firstCharacter.ToString();
                output.SpotNumber = int.Parse(location[1].ToString());
                output.Status = GridSpotStatus.Ship;
                model.ShipLocation.Add(output);
                return true;
            }
            else
            {
                return false;
            }

        }

        private static void AddGridSpot(PlayerInfoModel model, string letter, int number)
        {
            GridSpotModel spot = new GridSpotModel
            {
                SpotLetter = letter,
                SpotNumber = number,
                Status = GridSpotStatus.Empty
            };

            model.ShotGrind.Add(spot);
        }
    }
}
