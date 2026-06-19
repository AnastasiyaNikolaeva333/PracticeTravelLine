public class Car : ICar
{
    private ICarBodyShape _carBodyShape;
    private IColor _color;
    private IEngine _engine;
    private IGearboxe _gearboxe;
    private ISteeringWheel _steeringWheel;

    public Car(ICarBodyShape carBodyShape, IColor color, IEngine engine, IGearboxe gearboxe, ISteeringWheel steeringWheel)
    {
        _carBodyShape = carBodyShape;
        _color = color;
        _engine = engine;
        _gearboxe = gearboxe;
        _steeringWheel = steeringWheel;
    }
    public double GetMaxSpeed()
    {
        double speed = _carBodyShape.MaxSpeed * _engine.CoefficientInfluenceSpeed * _gearboxe.CoefficientInfluenceSpeed;
        return speed;
    }
    public int GetGearsCount()
    {
        return _gearboxe.Gears;
    }
    public int GetPower()
    {
        return _engine.Power;
    }
    public int GetLoadCapacity()
    {
        return _carBodyShape.LoadCapacity;
    }
    public override string ToString()
    {
        return $"Автомобиль:\n" +
               $"Кузов: {_carBodyShape.Name}\n" +
               $"Цвет: {_color.Name}\n" +
               $"Двигатель: {_engine.Name}\n" +
               $"Коробка передач: {_gearboxe.Name}\n" +
               $"Позиция руля: {_steeringWheel.Position}\n" +
               $"Максимальная скорость: {GetMaxSpeed():F2} км/ч\n" +
               $"Количество передач: {GetGearsCount()}\n" +
               $"Мощность: {GetPower()} л.с.\n" +
               $"Грузоподъемность: {GetLoadCapacity()} кг";
    }
}