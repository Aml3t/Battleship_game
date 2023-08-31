using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    public class GrindSpotModel
    {
        public char Letter { get; set; }
        public int Number { get; set; }

        public GrindSpotModel(char letter, int number)
        {
            Letter = letter;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Letter}{Number}";
        }
    }
}
