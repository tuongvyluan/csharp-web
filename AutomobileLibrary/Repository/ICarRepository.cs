using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCarById(int carId);
        void InsertCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }
}
