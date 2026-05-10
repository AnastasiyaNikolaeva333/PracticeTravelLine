public class Destroyer : IRole
{
    public string Name => "Разрушитель";
    public int Damage => 100 + Random.Shared.Next( 1, 30 );//может увелиться урон
    public int Health => 30;
}