public class Healer : IRole
{
    public string Name => "Целитель";
    public int Damage => 20;
    public int Health => 80 + +Random.Shared.Next( 1, 20 );//может иногда себя подлечить
}