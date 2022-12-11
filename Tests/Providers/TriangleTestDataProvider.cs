namespace Tests;

using Controller.Services;
using JetBrains.Annotations;
using Model;
using Model.Interfaces;

[UsedImplicitly]
public class TriangleTestDataProvider : FigureTestDataProviderBase<Triangle>
{
    /// <inheritdoc />
    public override List<FigureTestCase> TestCases => new List<FigureTestCase>()
    {
        new FigureTestCase(1, AreaProvider, FigureType)
        {
            CreateTestData = delegate(out IFigure item, out double? area, out bool isValid)
            {
                item = new Triangle(3, 4, 5);
                area = 6;
                isValid = true;
            }
        },
        new FigureTestCase(2, AreaProvider, FigureType)
        {
            CreateTestData = delegate(out IFigure item, out double? area, out bool isValid)
            {
                item = new Triangle(5, 8, 5);
                area = 12;
                isValid = true;
            }
        },
        new FigureTestCase(3, AreaProvider, FigureType)
        {
            CreateTestData = delegate(out IFigure item, out double? area, out bool isValid)
            {
                item = new Triangle(-5, 8, 5);
                area = null;
                isValid = false;
            }
        },
    };

    /// <inheritdoc />
    public override Type AreaProvider => typeof(AreaCalculatorTriangle);
}