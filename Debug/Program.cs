namespace Tests;

using Controller.Services;
using Model;

/// <summary>
/// Для дебага
/// </summary>
internal static class Program
{
    /// <summary>
    /// Main
    /// </summary>
    internal static void Main()
    {
        List<Figure> figures = new List<Figure>()
        {
            new Circle(5),
            new Circle(6),
            new Circle(7),
            new Triangle(3, 4, 5),
            new Triangle(5, 8, 5),
            // TODO Раскомментировать, чтобы посмотреть на ошибки.
            // new Square(),
            // new Triangle(-5, 8, 5),
            // new Triangle(15, 8, 5),
        };

        figures
            .Select(figure =>
                new
                {
                    Item = figure,
                    Area = FigureHelper.GetAreaForFigure(figure)
                })
            .ToList()
            .ForEach(it => Console.WriteLine($"{it.Item}. Площадь равна {it.Area}"));
    }
}