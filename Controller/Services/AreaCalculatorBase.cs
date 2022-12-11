namespace Controller.Services;

using Interfaces;
using Model.Interfaces;

/// <summary>
/// Калькулятор площади (базовый)
/// </summary>
/// <typeparam name="TFigure">Тип фигуры</typeparam>
public abstract class AreaCalculatorBase<TFigure> : IAreaCalculator
    where TFigure : class, IFigure
{
    /// <summary>
    /// Найти площадь фигуры
    /// </summary>
    /// <param name="figure">Фигура</param>
    /// <returns>Площадь фигуры</returns>
    /// <exception cref="Exception">Ошибка типа фигуры</exception>
    public double GetArea(IFigure figure)
    {
        if (figure is not TFigure figureToFindArea)
        {
            throw new ArgumentException("Фигура неверного типа.", nameof(figure));
        }

        figure.Validate();
        return GetAreaInternal(figureToFindArea);
    }

    /// <summary>
    /// Реализация вычислений площади
    /// </summary>
    /// <param name="figure">Фигура</param>
    /// <returns>Площадь фигуры</returns>
    protected abstract double GetAreaInternal(TFigure figure);
}