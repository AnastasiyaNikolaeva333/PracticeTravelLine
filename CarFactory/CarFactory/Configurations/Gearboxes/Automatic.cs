public class Automatic : IGearbox
{
    public string Name => "Автоматическая коробка передач";
    public int Gears => 8;
    public double CoefficientInfluenceSpeed => 0.98;
}
