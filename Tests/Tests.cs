namespace Tests;

using Controller.Interfaces;
using Controller.Services;
using Model.Interfaces;
using NUnit.Framework;

/// <summary>
/// Тесты
/// </summary>
[TestFixture]
public class Tests
{
    /// <summary>
    /// Тест на правильность вычислений
    /// </summary>
    /// <param name="testCase">Тестовый кейс</param>
    [Test]
    [TestCaseSource(nameof(FigureTestCaseSource))]
    public void FigureAreaCalcTests(FigureTestCase testCase)
    {
        var item = default(IFigure);
        double? area = 0;
        bool isValid = false;

        Assert.NotNull(testCase.CreateTestData,
            $"Отсутствует провайдер тест-кейсов для {testCase.ProviderType.FullName}");

        Assert.DoesNotThrow(() => testCase.CreateTestData.Invoke(out item, out area, out isValid),
            "В методе подготовки данных произошла ошибка");

        if (isValid)
        {
            double result = 0;
            Assert.DoesNotThrow(() => result = FigureHelper.GetAreaForFigure(item),
                "В методе подсчёта произошла ошибка");

            Assert.AreEqual(area, result, "Ожидалась другая площадь фигуры.");
        }
        else
        {
            // Нужно своё исключение, чтобы не отловить чего-нибудь лишнего.
            Assert.Throws<Exception>(() => FigureHelper.GetAreaForFigure(item),
                "Фигура оказалась валидна");
        }
    }

    /// <summary>
    /// Источник тестов
    /// </summary>
    /// <returns>Тест-кейсы</returns>
    public static IEnumerable<FigureTestCase> FigureTestCaseSource()
    {
        var testCases = new List<FigureTestCase>();

        var testProviders = ServiceFinder.GetImplementationsTypesOfService<IFigureTestProvider>()
            .Where(it => it.IsClass
                         && !it.IsAbstract)
            .Select(Activator.CreateInstance)
            .OfType<IFigureTestProvider>()
            .ToList();

        var cases = ServiceFinder.GetImplementationsTypesOfService<IAreaCalculator>()
            .Where(it => it.IsClass
                         && !it.IsAbstract)
            .ToList();

        foreach (var type in cases)
        {
            var provider = testProviders.SingleOrDefault(it => it.CanWorkWith(type));

            if (provider != null && provider.TestCases != null)
            {
                testCases.AddRange(provider.TestCases);
            }
        }

        return testCases;
    }
}