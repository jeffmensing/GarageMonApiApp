# GarageMonApiApp

example Garage Object
{ Id = 10, GarageName = "200 San Antonio Garage", MaxParkingSpots = 500, NumParkingSpotsOccupied = 476},

Routing

Get garage list
GET: api/Garages

Increase Parking Spots Occupied Count
[HttpGet("[action]/{id}")]
GET: api/Garages/IncrementCarCount/22

Decrease Parking Spots Occupied Count
api/Garages/DecrementCarCount/22
[HttpGet("[action]/{id}")

POST: api/Garages
[HttpPost]

Update a Specific Garage
api/Garages/22
[HttpPut("{id}")]

Delete a Specific Garage
DELETE: api/Garages/22
[HttpDelete("{id}")





