namespace Controller.Services;

using Interfaces;

/// <summary>
/// Хелпер для вычисления площади
/// </summary>
internal static class AreaHelper
{
    /// <summary>
    /// Получить калькулятор площади для фигуры
    /// </summary>
    /// <param name="figure">Фигура</param>
    /// <typeparam name="TFigure">Тип фигуры</typeparam>
    /// <returns>Имплементацию Калькулятора площади</returns>
    /// <exception cref="Exception">Исключение для несуществующих имплементаций</exception>
    internal static IAreaCalculator GetAreaCalculatorForFigure<TFigure>(TFigure figure)
    {
        // Здесь явно много пространства для выстрела себе в ногу, например открытый дженерик в наследнике,
        // или несколько провайдеров для одной фигуры и т.д.
        // Можно либо обработать всевозможные исключения и брать какую-то "первую" имплементацию, либо воспользоваться
        // нормальной DI библиотекой, например Simple Injector, которым пользуюсь на текущем месте работы (в местной удобнейшей обёртке)
        // Но "на коленке" это показалось лучше словарика-карты с сопоставлениями типов =)
        var baseType = Type.MakeGenericSignatureType(typeof(AreaCalculatorBase<>), figure.GetType());

        return ServiceFinder.GetSingleImplementationByGeneric<TFigure, IAreaCalculator>(figure, baseType);
    }
}