internal interface ICarBuilder
{
    ICarBuilder ChooseCarBodyShape();
    ICarBuilder ChooseColor();
    ICarBuilder ChooseEngine();
    ICarBuilder ChooseGearboxe();
}
