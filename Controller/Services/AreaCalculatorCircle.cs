namespace Controller.Services;

using Model;

/// <summary>
/// Калькулятор площади круга
/// </summary>
public class AreaCalculatorCircle : AreaCalculatorBase<Circle>
{
    /// <inheritdoc />
    protected override double GetAreaInternal(Circle figure)
    {
        return Math.PI * Math.Pow(figure.Radius, 2);
    }
}