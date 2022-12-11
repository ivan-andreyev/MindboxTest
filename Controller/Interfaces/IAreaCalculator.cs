namespace Controller.Interfaces;

using Model.Interfaces;
using Utils.Interfaces;

/// <summary>
/// Интерфейс калькулятора площади фигуры
/// </summary>
public interface IAreaCalculator : IResolvable
{
    /// <summary>
    /// Найти площадь фигуры
    /// </summary>
    /// <param name="figure">Фигура</param>
    /// <returns>Площадь фигуры</returns>
    double GetArea(IFigure figure);
}