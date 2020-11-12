# GarageMonApiApp

https://jamgarageapi.azurewebsites.net/api/garages

example Garage Object
{ Id = 10, GarageName = "200 San Antonio Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 476},

Routing

Get garage list
GET: api/Garages


Increase Parking Spots Occupied Count

[HttpGet("[action]/{id}")]

GET: api/Garages/IncrementCarCount/22



Decrease Parking Spots Occupied Count

[HttpGet("[action]/{id}")

api/Garages/DecrementCarCount/22



POST: api/Garages

[HttpPost]



Update a Specific Garage

[HttpPut("{id}")]

api/Garages/22



Delete a Specific Garage

[HttpDelete("{id}")

DELETE: api/Garages/22








