
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