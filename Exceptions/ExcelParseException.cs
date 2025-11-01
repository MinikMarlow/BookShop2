namespace BookApp.Exceptions;

public class ExcelParseException(string worksheet, int row) : Exception($"Ошибка в импорте в таблице {worksheet}, строка - {row}")
{
}
