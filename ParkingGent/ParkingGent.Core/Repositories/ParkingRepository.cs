using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingGent.Core.Models;
using WineApp.Core.Repositories;

namespace ParkingGent.Core.Repositories
{
    public class ParkingRepository : BaseRepository, IParkingRepository
    {
        private const string _BASEURL = "https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime.json";
        private List<Parking> _parkings;

        public async Task<List<Parking>> GetParkings()
        {
            string url = _BASEURL;
            _parkings = await GetAsync<List<Parking>>(url);

            return _parkings;
        }


        public async Task<Parking> GetParkingById(int parkingId)
        {
            if (_parkings == null) await GetParkings();
            return _parkings.Where(parking => parking.id == parkingId)?.First();
        }
    }
}
