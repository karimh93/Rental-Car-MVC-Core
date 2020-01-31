using CarRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Repositories
{
    public interface ICarsRepository
    {
        IEnumerable<Cars> GetCars();
    }
    public class CarsRepository:ICarsRepository
    {
        private readonly CarRentContext carRentContext;
        public CarsRepository(CarRentContext carRentContext)
        {
            this.carRentContext = carRentContext;
        }
        
        public IEnumerable<Cars> GetCars()
        {
            return carRentContext.Cars.ToList();
        }
    }
}
