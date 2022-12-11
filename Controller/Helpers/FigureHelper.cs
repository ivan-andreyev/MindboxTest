namespace Controller.Services;

using Model;
using Model.Interfaces;

/// <summary>
/// Хелпер для работы с фигурами
/// </summary>
public static class FigureHelper
{
    /// <summary>
    /// Получить площадь фигуры
    /// </summary>
    /// <param name="figure">Фигура</param>
    /// <typeparam name="TFigure">Тип фигуры</typeparam>
    /// <returns>Площадь фигуры</returns>
    public static double GetAreaForFigure<TFigure>(TFigure figure)
        where TFigure : IFigure
    {
        return AreaHelper.GetAreaCalculatorForFigure(figure).GetArea(figure);
    }

    /// <summary>
    /// Проверить, является ли треугольник прямоугольным
    /// </summary>
    /// <param name="triangle">Треугольник</param>
    /// <returns><b>true</b>, если треугольник является прямоугольным.</returns>
    public static bool CheckIfTriangleIsRight(Triangle triangle)
    {
        return TriangleHelper.IsRightTriangle(triangle);
    }
}