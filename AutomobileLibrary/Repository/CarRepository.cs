using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public void DeleteCar(int id) => CarDAO.Instance.Delete(id);

        public Car GetCarById(int carId) => CarDAO.Instance.GetCar(carId);

        public IEnumerable<Car> GetCars() => CarDAO.Instance.GetCars();

        public void InsertCar(Car car) => CarDAO.Instance.Add(car);

        public void UpdateCar(Car car) => CarDAO.Instance.Update(car);
    }
}
