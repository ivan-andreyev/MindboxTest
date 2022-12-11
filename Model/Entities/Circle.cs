namespace Model;

/// <summary>
/// Круг
/// </summary>
public class Circle : Figure
{
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="radius">Радиус</param>
    public Circle(double radius)
    {
        Radius = radius;
    }

    /// <summary>
    /// Радиус
    /// </summary>
    public double Radius { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Круг с радиусом {Radius}";
    }

    /// <inheritdoc />
    public override bool InternalValidate()
    {
        return Radius > 0;
    }
}