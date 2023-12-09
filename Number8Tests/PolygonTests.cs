using System;
using System.Drawing;
using Number8;

namespace Number8Tests;

public class PolygonTests
{
    private readonly Polygon _polygon;
    
    public PolygonTests()
    {
        _polygon = new Polygon();
        _polygon.AddPoint(new Point(153, 134));
        _polygon.AddPoint(new Point(267, 64));
        _polygon.AddPoint(new Point(365, 123));
        _polygon.AddPoint(new Point(354, 226));
        _polygon.AddPoint(new Point(233, 259));
        _polygon.AddPoint(new Point(110, 262));
    }

    [Theory]
    [InlineData(243, 139, 1)]
    [InlineData(342, 133, 1)]
    [InlineData(205, 118, 1)]
    [InlineData(153, 134, 1)]
    [InlineData(155, 300, -1)]
    [InlineData(529, 205, -1)]
    [InlineData(330, 92, -1)]
    [InlineData(124, 204, -1)]
    public void IsPointInPolygon_ReturnsCorrectly(int x, int y, int expected)
    {
        var point = new Point(x, y);
        Assert.Equal(expected, _polygon.IsPointInPolygon(point));
    }
    
    [Fact]
    public void IsPointInPolygon_ThrowsInvalidOperationException()
    {
        var polygon = new Polygon();
        Assert.Throws<InvalidOperationException>(() => polygon.IsPointInPolygon(new Point(0, 0)));
    }

    [Fact]
    public void AddPoint()
    {
        var p1 = new Point(153, 134);
        var p2 = new Point(267, 64);
        var p3 = new Point(354, 226);
        var polygon = new Polygon();
        
        Assert.False(polygon.IsValid);
        polygon.AddPoint(p1);
        Assert.False(polygon.IsValid);
        Assert.Contains(p1, polygon.Points);
        
        polygon.AddPoint(p2);
        Assert.False(polygon.IsValid);
        Assert.Contains(p2, polygon.Points);
        
        polygon.AddPoint(p3);
        Assert.True(polygon.IsValid);
        Assert.Contains(p3, polygon.Points);
        Assert.Equal(3, polygon.Points.Count);
    }
    
    [Fact]
    public void Clear()
    {
        var polygon = new Polygon();
        polygon.AddPoint(new Point(153, 134));
        polygon.AddPoint(new Point(267, 64));
        polygon.AddPoint(new Point(354, 226));
        
        Assert.NotEmpty(polygon.Points);
        polygon.Clear();
        Assert.Empty(polygon.Points);
    }
}