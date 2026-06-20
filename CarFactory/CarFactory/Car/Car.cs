public class Car : ICar
{
    private ICarBodyShape _carBodyShape;
    private IColor _color;
    private IEngine _engine;
    private IGearbox _gearbox;
    private ISteeringWheel _steeringWheel;

    public Car(ICarBodyShape carBodyShape, IColor color, IEngine engine, IGearbox gearbox, ISteeringWheel steeringWheel)
    {
        _carBodyShape = carBodyShape;
        _color = color;
        _engine = engine;
        _gearbox = gearbox;
        _steeringWheel = steeringWheel;
    }
    public double GetMaxSpeed()
    {
        double speed = _carBodyShape.MaxSpeed * _engine.CoefficientInfluenceSpeed * _gearbox.CoefficientInfluenceSpeed;
        return speed;
    }
    public int GetGearsCount()
    {
        return _gearbox.Gears;
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
               $"Коробка передач: {_gearbox.Name}\n" +
               $"Позиция руля: {_steeringWheel.Position}\n" +
               $"Максимальная скорость: {GetMaxSpeed():F2} км/ч\n" +
               $"Количество передач: {GetGearsCount()}\n" +
               $"Мощность: {GetPower()} л.с.\n" +
               $"Грузоподъемность: {GetLoadCapacity()} кг";
    }
}