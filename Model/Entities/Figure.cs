namespace Model;

using Interfaces;

/// <summary>
/// Фигура
/// </summary>
public abstract class Figure : IFigure
{
    /// <inheritdoc />
    public bool Validate()
    {
        if (!InternalValidate())
        {
            throw new Exception(
                "Входные данные не прошли валидацию. Фигура с заданными параметрами не может быть создана");
        }

        return true;
    }

    /// <summary>
    /// Проверить данные
    /// </summary>
    /// <returns></returns>
    public virtual bool InternalValidate()
    {
        return true;
    }
}