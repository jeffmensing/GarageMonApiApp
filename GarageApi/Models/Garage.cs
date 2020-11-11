using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageApi.Models
{
    public class Garage
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string GarageName { get; set; }
        [Required]
        public int MaxParkingSpots { get; set; }
        [Required]
        public int NumParkingSpotsOccupied { get; set; }
    }
}
