namespace Controller.Services;

using Model;

/// <summary>
/// Хелпер для работы с треугольником
/// </summary>
internal static class TriangleHelper
{
    /// <summary>
    /// Прямой угол
    /// </summary>
    private const double RightAngle = 90;

    /// <summary>
    /// Является ли треугольник прямоугольным
    /// </summary>
    /// <param name="triangle">Треугольник</param>
    /// <returns><b>true</b>, если треугольник является прямоугольным.</returns>
    internal static bool IsRightTriangle(Triangle triangle)
    {
        return GetAngleBySides(triangle.Side1, triangle.Side2, triangle.Side3) == RightAngle
               || GetAngleBySides(triangle.Side2, triangle.Side1, triangle.Side3) == RightAngle
               || GetAngleBySides(triangle.Side3, triangle.Side1, triangle.Side2) == RightAngle;
    }

    /// <summary>
    /// Получить размер угла в градусах по трём сторонам треугольника
    /// </summary>
    /// <param name="sideOppositeAngle">Противолежащая сторона от искомого угла</param>
    /// <param name="adjacentSide1">Прилежащая к углу сторона 1</param>
    /// <param name="adjacentSide2">Прилежащая к углу сторона 2</param>
    /// <returns>Угол в градусах</returns>
    private static double GetAngleBySides(double sideOppositeAngle, double adjacentSide1, double adjacentSide2)
    {
        return Math.Cos((adjacentSide1 * adjacentSide1
                + adjacentSide2 * adjacentSide2
                - sideOppositeAngle * sideOppositeAngle)
            / 2 * adjacentSide1 * adjacentSide2);
    }
}