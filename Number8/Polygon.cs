using System;
using System.Collections.Generic;
using System.Drawing;

namespace Number8;

/// <summary>
/// Представляет многоугольник
/// </summary>
public class Polygon
{
    private List<Point> _points = new();
    
    public IReadOnlyList<Point> Points => _points;
    
    public bool IsValid => Points.Count >= 3;

    public void AddPoint(Point point)
    {
        _points.Add(point);
    }
    
    public void Clear()
    {
        _points.Clear();
    }
    
    /// <summary>
    /// Проверяет, находится ли точка внутри многоугольника.
    /// </summary>
    /// <param name="point">Точка, которую нужно проверить.</param>
    /// <returns>1, если точка внутри многоугольника, -1, если точка снаружи многоугольника</returns>
    /// <exception cref="InvalidOperationException">Многоугольник не задан.</exception>
    public int IsPointInPolygon(Point point)
    {
        if (!IsValid)
            throw new InvalidOperationException("Многоугольник не задан.");
        
        int result = -1;
        for (int i = 0; i < _points.Count; i++)
        {
            Point a = _points[i];
            Point b = _points[(i + 1) % _points.Count];
            if (a.Y <= point.Y && b.Y > point.Y || b.Y <= point.Y && a.Y > point.Y)
            {
                double x1 = a.X + (double)(point.Y - a.Y) / (b.Y - a.Y) * (b.X - a.X);
                if (point.X < x1)
                    result = -result;
            }
        }
        return result;
    }
}