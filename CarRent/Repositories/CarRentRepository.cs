using CarRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Repositories
{
    public interface ICarRentRepository
    {
        IEnumerable<CarRentRegister> GetAllCarRents();
        CarRentRegister GetCarRentById(int id);
        CarRentRegister UpdateCarRent(CarRentRegister carRentToUpdate);
        CarRentRegister AddCarRent(CarRentRegister carRentToBeAdded);
        void DeleteCarRent(CarRentRegister carRentToDelete);
    }



    public class CarRentRepository:ICarRentRepository
    {

        private readonly CarRentContext carRentContext;
        public CarRentRepository(CarRentContext carRentContext)
        {
            this.carRentContext = carRentContext;
        }
        public IEnumerable<CarRentRegister> GetAllCarRents()
        {
            return carRentContext.CarRentRegister.ToList();
        }
        public CarRentRegister AddCarRent(CarRentRegister carRentToBeAdded)
        {
            var addedCarRent = carRentContext.Add(carRentToBeAdded);
            carRentContext.SaveChanges();
            return addedCarRent.Entity;
        }
        public CarRentRegister UpdateCarRent(CarRentRegister carRentToUpdate)
        {
            var editCarRent = carRentContext.Update(carRentToUpdate);
            carRentContext.SaveChanges();
            return editCarRent.Entity;
        }

        public CarRentRegister GetCarRentById(int id)
        {
            return carRentContext.CarRentRegister.Find(id);
        }

        public void DeleteCarRent(CarRentRegister carRentToDelete)
        {
            carRentToDelete = carRentContext.CarRentRegister.Find(carRentToDelete.CarRentId);
            carRentContext.CarRentRegister.Remove(carRentToDelete);
            carRentContext.SaveChanges();
        }
    }
}
