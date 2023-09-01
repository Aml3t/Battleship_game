using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class GridSpotModel
    {
        public string SpotLetter { get; set; }
        public int SpotNumber { get; set; }
        public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;


        //public GridSpotModel(string letter, int number)
        //{
        //    SpotLetter = letter;
        //    SpotNumber = number;
        //}

        //public override string ToString()
        //{
        //    return $"{SpotLetter}{SpotNumber}";
        //}
    }
}
