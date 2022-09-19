namespace AutomobileLibrary.DataAccess;

public class CarDAO
{
    private static CarDAO instance = null;
    private static readonly object instanceLock = new object();
    public static CarDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new CarDAO();
                }
                return instance;
            }
        }
    }

    public IEnumerable<Car> GetCars()
    {
        var cars = new List<Car>();
        try
        {
            using var context = new MyStockDBContext();
            cars = context.Cars.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return cars;
    }

    public Car GetCar(int carId)
    {
        Car car = null;
        try
        {
            using var context = new MyStockDBContext();
            car = context.Cars.SingleOrDefault(c => c.CarId == carId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return car;
    }

    public void Add(Car car)
    {
        try
        {
            Car _car = car;
            using var context = new MyStockDBContext();
            context.Cars.Add(_car);
            context.SaveChanges();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Update(Car car)
    {
        try
        {
            Car _car = GetCar(car.CarId);
            if (_car != null)
            {
                _car = car;
                using var context = new MyStockDBContext();
                context.Cars.Update(_car);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("The car does not already exist");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Delete(int id)
    {
        try
        {
            Car _car = GetCar(id);
            if (_car != null)
            {
                using var context = new MyStockDBContext();
                context.Cars.Remove(_car);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("The car does not already exist");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
