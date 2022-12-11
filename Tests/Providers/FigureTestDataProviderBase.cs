namespace Tests;

using Model;

public abstract class FigureTestDataProviderBase<TFigure> : IFigureTestProvider
    where TFigure : Figure
{
    public Type FigureType => typeof(TFigure);

    public abstract List<FigureTestCase> TestCases { get; }

    public abstract Type AreaProvider { get; }

    public bool CanWorkWith(Type areaProvider) => areaProvider == AreaProvider;
}