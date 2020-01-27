using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Entities;
using CarRent.Models;
using CarRent.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace CarRent.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        
        
        // GET: Customers
        public ActionResult Index()
        {
            IEnumerable<Customers> allCustomers = _customerRepository.GetAllCustomers();
            return View(allCustomers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            Customers customer = _customerRepository.GetCustomerById(id);
            CustomerModel model = new CustomerModel();
            model.InjectFrom(customer);

            if (customer == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                Customers customers = new Customers();
                customers.InjectFrom(model);
                var createCustomer = _customerRepository.AddCustomer(customers);
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

            // GET: Customers/Edit/5
            public ActionResult Edit(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            CustomerModel model = new CustomerModel();
            model.InjectFrom(customer);
            return View(model);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                Customers customers = new Customers();
                customers.InjectFrom(model);
                var customerToUpdate = _customerRepository.UpdateCustomer(customers);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customerToDelete = _customerRepository.GetCustomerById(id);
            CustomerModel model = new CustomerModel();
            model.InjectFrom(customerToDelete);
            return View(model);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CustomerModel model)
        {
            Customers customerToDelete = new Customers();
            customerToDelete = _customerRepository.GetCustomerById(id);
            model.InjectFrom(customerToDelete);
            _customerRepository.DeleteCustomer(customerToDelete);
            return RedirectToAction(nameof(Index));
        }
    }
}