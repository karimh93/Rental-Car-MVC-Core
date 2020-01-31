
using CarRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAllCustomers();
        Customers GetCustomerById(int id);
        Customers UpdateCustomer(Customers customerToUpdate);
        Customers AddCustomer(Customers customerToBeAdded);
        void DeleteCustomer(Customers customerToDelete);
    }



    public class CustomerRepository : ICustomerRepository
    {

        private readonly CarRentContext carRentContext;
        
        public CustomerRepository(CarRentContext carRentContext)
        {
            this.carRentContext = carRentContext;
        }
        public IEnumerable<Customers> GetAllCustomers()
        {
            return carRentContext.Customers.ToList();
        }
        public Customers AddCustomer(Customers customerToBeAdded)
        {
            var addedCustomer = carRentContext.Add(customerToBeAdded);
            carRentContext.SaveChanges();
            return addedCustomer.Entity;
        }


        public Customers GetCustomerById(int id)
        {
            return carRentContext.Customers.Find(id);
        }
        
        public Customers UpdateCustomer(Customers customerToUpdate)
        {
            var editCustomer = carRentContext.Update(customerToUpdate);
            carRentContext.SaveChanges();
            return editCustomer.Entity;
        }
        public void DeleteCustomer(Customers customerToDelete)
        {
            customerToDelete = carRentContext.Customers.Find(customerToDelete.CostumerId);
            carRentContext.Customers.Remove(customerToDelete);
            carRentContext.SaveChanges();
        }

    }
}
