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
using Microsoft.Web.SessionState;

namespace CarRent.Controllers
{
    public class CarRentController : Controller
    {
        private readonly ICarRentRepository carRentRepository;

        public CarRentController(ICarRentRepository carRentRepository)
        {
            this.carRentRepository = carRentRepository;
        }


        // GET: CarRent
        public ActionResult Index()
        {
            IEnumerable<CarRentRegister> allCarRents = carRentRepository.GetAllCarRents();
            return View(allCarRents);
        }

        // GET: CarRent/Details/5
        public ActionResult Details(int id)
        {

            CarRentRegister carRent = carRentRepository.GetCarRentById(id);
            CarRentModel model = new CarRentModel();
            model.InjectFrom(carRent);

            return View(model);
        }

        // GET: CarRent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarRent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarRentModel model)
        {
            if (ModelState.IsValid)
            {

                DateTime startDate = model.StartDate;
                DateTime endDate = model.EndDate;


                if (startDate > endDate)
                {
                    return RedirectToAction(nameof(Create));
                }
                else
                {
                    CarRentRegister carRentRegister = new CarRentRegister();
                    carRentRegister.InjectFrom(model);
                    var createCarRegister = carRentRepository.AddCarRent(carRentRegister);
                    return RedirectToAction(nameof(Index));

                }
            }

            return View(model);
        }

        // GET: CarRent/Edit/5
        public ActionResult Edit(int id)
        {
            var carRent = carRentRepository.GetCarRentById(id);
            CarRentRegister model = new CarRentRegister();
            model.InjectFrom(carRent);
            return View(model);
        }

        // POST: CarRent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarRentRegister model)
        {
            if (ModelState.IsValid)
            {
                CarRentRegister carRentRegister = new CarRentRegister();
                carRentRegister.InjectFrom(model);
                var customerToUpdate = carRentRepository.UpdateCarRent(carRentRegister);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CarRent/Delete/5
        public ActionResult Delete(int id)
        {
            var carRentToDelete = carRentRepository.GetCarRentById(id);
            CarRentRegister model = new CarRentRegister();
            model.InjectFrom(carRentToDelete);
            return View(model);
        }

        // POST: CarRent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CarRentRegister model)
        {
            CarRentRegister carRentToDelete = new CarRentRegister();
            carRentToDelete = carRentRepository.GetCarRentById(id);
            model.InjectFrom(carRentToDelete);
            carRentRepository.DeleteCarRent(carRentToDelete);
            return RedirectToAction(nameof(Index));
        }
    }
}