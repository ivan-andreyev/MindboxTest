namespace Model;

using Interfaces;

/// <summary>
/// Треугольник
/// </summary>
public class Triangle : Figure
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="side1">Сторона № 1</param>
    /// <param name="side2">Сторона № 2</param>
    /// <param name="side3">Сторона № 3</param>
    public Triangle(double side1, double side2, double side3)
    {
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    /// <summary>
    /// Сторона 1
    /// </summary>
    public double Side1 { get; set; }

    /// <summary>
    /// Сторона 2
    /// </summary>
    public double Side2 { get; set; }

    /// <summary>
    /// Сторона 3
    /// </summary>
    public double Side3 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Треугольник со сторонами {Side1}, {Side2} и {Side3}";
    }

    /// <inheritdoc />
    public override bool InternalValidate()
    {
        return Side1 > 0
               && Side2 > 0
               && Side3 > 0
               && Side1 < Side2 + Side3
               && Side2 < Side1 + Side3
               && Side3 < Side1 + Side2;
    }
}