using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingGent.Core.Models;
using ParkingGent.Core.Repositories;

namespace ParkingGent.Core.Services
{
    public class ParkingService : IParkingService
    {
        //private static List<Parking> _parkings = new List<Parking>();
        private readonly IParkingRepository _parkingRepository;

        //Constructor
        public ParkingService(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        //Service voor 1 parking op ID
        public async Task<Parking> GetParkingById(int restaurantId)
        {
            return await _parkingRepository.GetParkingById(restaurantId);
        }

        //Service voor GetParkings
        public async Task<List<Parking>> GetParkings()
        {
            return await _parkingRepository.GetParkings();
        }
    }
}
