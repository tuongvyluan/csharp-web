﻿using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileWebApp
{
    public class CarsController : Controller
    {
        readonly ICarRepository carRepository = new CarRepository();
        public CarsController() => carRepository = new CarRepository();
        // GET: CarsController
        public ActionResult Index()
        {
            var cars = carRepository.GetCars();
            return View(cars);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = carRepository.GetCarById(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: CarsController/Create
        public ActionResult Create() => View();

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carRepository.InsertCar(car);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = carRepository.GetCarById(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                if (id != car.CarId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    carRepository.UpdateCar(car);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = carRepository.GetCarById(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                carRepository.DeleteCar(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
