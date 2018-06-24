using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace topo_api_1.Models
{
    public class Route
    {
        public enum RouteType
        {
            Sport,
            Boulder,
            Trad,
            MountainSummer,
            MountainWinter,
            Icefall
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public RouteType Type { get; set; }
        public string Grade { get; set; }
        public string Img { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        
        [NotMapped]
        public double? Distance { get; set; }

        public Route()
        {
            Distance = null;
        }
    }
}
