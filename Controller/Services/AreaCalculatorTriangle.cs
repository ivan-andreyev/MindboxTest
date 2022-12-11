namespace Controller.Services;

using Model;

/// <summary>
/// Калькулятор площади треугольника
/// </summary>
public class AreaCalculatorTriangle : AreaCalculatorBase<Triangle>
{
    /// <inheritdoc />
    protected override double GetAreaInternal(Triangle figure)
    {
        var p = (figure.Side1 + figure.Side2 + figure.Side3) / 2;
        return Math.Sqrt(p * (p - figure.Side1) * (p - figure.Side2) * (p - figure.Side3));
    }
}