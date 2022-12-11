namespace Tests;

using Controller.Services;
using Model;
using Model.Interfaces;

public class CircleTestDataProvider : FigureTestDataProviderBase<Circle>
{
    /// <inheritdoc />
    public override List<FigureTestCase> TestCases => new List<FigureTestCase>()
    {
        new FigureTestCase(1, AreaProvider, FigureType)
        {
            CreateTestData = delegate(out IFigure item, out double? area, out bool isValid)
            {
                item = new Circle(1);
                area = Math.PI;
                isValid = true;
            }
        },
        new FigureTestCase(2, AreaProvider, FigureType)
        {
            CreateTestData = delegate(out IFigure item, out double? area, out bool isValid)
            {
                item = new Circle(5);
                area = 78.53981633974483;
                isValid = true;
            }
        },
        new FigureTestCase(3, AreaProvider, FigureType)
        {
            CreateTestData = delegate(out IFigure item, out double? area, out bool isValid)
            {
                item = new Circle(-5);
                area = null;
                isValid = false;
            }
        },
    };

    /// <inheritdoc />
    public override Type AreaProvider => typeof(AreaCalculatorCircle);
}