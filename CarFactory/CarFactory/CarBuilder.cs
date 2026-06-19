public class CarBuilder
{
    private ICarBodyShape _carBodyShape;
    private IColor _color;
    private IEngine _engine;
    private IGearboxe _gearboxe;
    private ISteeringWheel _steeringWheel;
    public CarBuilder ChooseCarBodyShape()
    {
        _carBodyShape = Response.ChooseCarBodyShape();
        return this;
    }
    public CarBuilder ChooseColor()
    {
        _color = Response.ChooseColor();
        return this;
    }
    public CarBuilder ChooseEngine()
    {
        _engine = Response.ChooseEngine();
        return this;
    }
    public CarBuilder ChooseGearboxe()
    {
        _gearboxe = _engine is ElectricEngine
           ? new Reducer()
           : Response.ChooseGearboxe();
        return this;
    }
    public CarBuilder ChooseSteeringWheel()
    {
        _steeringWheel = Response.ChooseSteeringWheel();
        return this;
    }
    public ICar Build()
    {
        ICar car = new Car(_carBodyShape, _color, _engine, _gearboxe, _steeringWheel);
        return car;
    }
}