namespace Tests;

using Model.Interfaces;

/// <summary>
/// Делегат создания данных для теста
/// </summary>
/// <param name="item">Созданная фигура</param>
/// <param name="area">Ожидаемая площадь</param>
/// <param name="isValid">Элемент прошёл валидацию</param>
/// <remarks>Я бы предпочёл валидацию вынести в отдельный тест, а не смешивать его с проверкой правильности вычислений, но это займёт дополнительное время.</remarks>
public delegate void CreateFigureTestDataDelegate(out IFigure item, out double? area, out bool isValid);

public class FigureTestCase
{
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="testNumber">Номер теста</param>
    /// <param name="providerType">Тип провайдера</param>
    /// <param name="itemType">Тип элемента</param>
    public FigureTestCase(int testNumber, Type providerType, Type itemType)
    {
        TestNumber = testNumber;
        ProviderType = providerType;
        ItemType = itemType;
    }

    /// <summary>
    /// Номер теста
    /// </summary>
    public int TestNumber { get; set; }

    /// <summary>
    /// Тип провайдера
    /// </summary>
    public Type ProviderType { get; set; }

    /// <summary>
    /// Тип элемента
    /// </summary>
    public Type ItemType { get; set; }

    /// <summary>
    /// Метод, создающий данные для теста
    /// </summary>
    public CreateFigureTestDataDelegate CreateTestData { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Калькулятор площади фигуры {ProviderType.FullName} тест № {TestNumber}";
    }
}