using System.Collections.Generic;

namespace Battleship.Models
{
    public class PlayerInfoModel
    {
        public string UsersName { get; set; }
        public List<GridSpotModel> ShipLocation { get; set; }
        public List<GridSpotModel> ShotGrind { get; set; }
        

    }
}