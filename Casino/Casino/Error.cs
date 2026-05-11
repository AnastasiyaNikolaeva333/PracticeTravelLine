public class Error
{
    private static readonly Dictionary<OptionHandleResult, string> _errorMessage = new()
    {
        [ OptionHandleResult.InvalidOption ] = "Неправильный вариант управления. Только от 1-4",
        [ OptionHandleResult.InvalidDepositValue ] = "Невалидное значение депозита",
        [ OptionHandleResult.InvalidBet ] = "Невалидная ставка. Только от 1 до баланса",
        [ OptionHandleResult.InvalidBalance ] = "Баланс слишком маленький. Пополните его."
    };
    public static string GetErrorMessage( OptionHandleResult result )
    {
        return _errorMessage.TryGetValue( result, out string message )
            ? message
            : "Эта ошибка отсутствует в списке возможных ошибок";
    }
}