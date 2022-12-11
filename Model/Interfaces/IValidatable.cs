namespace Model.Interfaces;

/// <summary>
/// Требует валидации
/// TODO По-хорошему тоже сделать сервисом и резолвить для конкретного типа. Не реализовал для упрощения
/// </summary>
public interface IValidatable
{
    /// <summary>
    /// Валидация данных
    /// </summary>
    /// <returns>true, если фигура валидна</returns>
    bool Validate();
}