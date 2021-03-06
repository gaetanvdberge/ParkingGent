﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingGent.Core.Models;

namespace ParkingGent.Core.Repositories
{
    public interface IParkingRepository
    {
        Task<List<Parking>> GetParkings();
        Task<Parking> GetParkingById(int restaurantId);
    }
}
