using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using GarageApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private static List<Garage> garages = new List<Garage>
        {
        new Garage() { Id = 10, GarageName = "200 San Antonio Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 476},
        new Garage() { Id = 11, GarageName = "311 San Jacinto Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 200},
        new Garage() { Id = 22, GarageName = "25 Trinity Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 333},
        new Garage() { Id = 34, GarageName = "2235 Lavaca Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 411},
        new Garage() { Id = 44, GarageName = "567 East 5th Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 150},
        new Garage() { Id = 55, GarageName = "897 South Congress Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 222},
        new Garage() { Id = 66, GarageName = "200 Red River Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 199},
        new Garage() { Id = 77, GarageName = "Univ Texas Garage 1", MaxParkingSpots = 500, NumParkingSpotsOccupied = 497},
        new Garage() { Id = 88, GarageName = "Univ Texas Garage 2", MaxParkingSpots = 500, NumParkingSpotsOccupied = 459},
        new Garage() { Id = 99, GarageName = "Univ Texas Garage 3", MaxParkingSpots = 500, NumParkingSpotsOccupied = 389},
        new Garage() { Id = 110, GarageName = "120 South 1st Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 62},
        new Garage() { Id = 121, GarageName = "476 Rio Grande Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 219},
        };

        // GET: api/Garages
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(garages);
        }

        // GET: api/Garages/IncrementCarCount/22
        [HttpGet("[action]/{id}")]
        public IActionResult IncrementCarCount(int id)
        {
            int index = CheckId(id);
            if (garages[index].NumParkingSpotsOccupied >= 500)
            {
                return BadRequest("This Garage is Full");
            }
            if (index != -1)
            {
                garages[index].NumParkingSpotsOccupied++;
                return Ok("Count Updated Successfully!");
            }
            else
            {
                return NotFound("Id not Found");
            }
        }

        // GET: api/Garages/DecrementCarCount/22
        [HttpGet("[action]/{id}")]
        public IActionResult DecrementCarCount(int id)
        {
            int index = CheckId(id);
            if (garages[index].NumParkingSpotsOccupied == 0)
            {
                return BadRequest("Cannot decrement. There are 0 spots occupied in this garage");
            }
            if (index != -1)
            {
                garages[index].NumParkingSpotsOccupied--;
                return Ok("Count Updated Successfully!");
            }
            else
            {
                return NotFound("Id not Found");
            }
        }

        // POST: api/Garages
        [HttpPost]
        public IActionResult Post([FromBody]Garage garage)
        {
            int index = CheckId(garage.Id);
            if (index == -1)
            {
                garages.Add(garage);
                return Ok("Garage Added");
            }
            else
            {
                return BadRequest("Id is already beind used.");
            }
        }

        // PUT: api/Garages/22
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Garage garage)
        {   //use for loop to loop through garages check for Id matching id
            int index = CheckId(id);
            if (index != -1)
            {
                garages[index].GarageName = garage.GarageName;
                garages[index].MaxParkingSpots = garage.MaxParkingSpots;
                garages[index].NumParkingSpotsOccupied = garage.NumParkingSpotsOccupied;
                return Ok("Record Updated Successfully!");
            }
            else
            {
                return NotFound("Id not Found");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int index = CheckId(id);
            if (index != -1)
            {
                garages.RemoveAt(index);
                return Ok("Record Deleted Successfully!");
            }
            else
            {
                return NotFound("Id not Found");
            }

        }

        //Create private function to send true or false
        //find garage method return garage obj or null
        private int CheckId(int id)
        {
            int i = 0;
            int index = -1;
            //loop through garage list check for valid Id
            foreach (var garage in garages)
            {
                if (garage.Id == id)
                {
                    index = i;
                    return index;
                }
                i++;
            }
            return index;
        }
    }

}
