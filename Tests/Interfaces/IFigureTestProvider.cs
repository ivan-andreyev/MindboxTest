namespace Tests;

using Utils.Interfaces;

public interface IFigureTestProvider : IResolvable
{
    List<FigureTestCase> TestCases { get; }

    bool CanWorkWith(Type areaProvider);
}