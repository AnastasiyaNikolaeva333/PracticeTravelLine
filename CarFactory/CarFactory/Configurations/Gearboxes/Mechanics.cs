public class Mechanics : IGearboxe
{
    public string Name => "Механическая коробка передач";
    public double CoefficientInfluenceSpeed => 1.0;
    public int Gears => 6;
}
