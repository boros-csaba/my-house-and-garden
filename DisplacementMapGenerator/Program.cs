
using System.Drawing;
using System.Drawing.Imaging;

const int MapSize = 8196;
Color defaultColor = Color.Red;

Console.WriteLine("Start drawing map");
DrawMap();
Console.WriteLine("Map is done!");
Console.ReadLine();


void DrawMap()
{
    var image = new Bitmap(MapSize, MapSize);

    Console.WriteLine("Filling image with default color");
    for (var x = 0; x < MapSize; x++)
    {
        for (var y = 0; y < MapSize; y++)
        {
            image.SetPixel(x, y, defaultColor);
        }
    }

    image.Save("dispalcement_map.png", ImageFormat.Png);
}






class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

class Area
{
    public int Elevation { get; set; }
    public Point Start { get; set; } = null!;
    public Point End { get; set; } = null!;
}

class Triangle
{
    public Point A { get; set; } = null!;
    public Point B { get; set; } = null!;
    public Point C { get; set; } = null!;

    public bool Includes(Point point)
    {
        var d1 = GetSign(point, A, B);
        var d2 = GetSign(point, B, C);
        var d3 = GetSign(point, C, A);

        var has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
        var has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

        return has_neg && has_pos;
    }

    float GetSign(Point p1, Point p2, Point p3)
    {
        return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
    }
}