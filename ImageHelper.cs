using System.Drawing;
using GBX.NET;

public class Pixel
{
    public System.Drawing.Color color;
    public Int2 coords;

    public Pixel(int x, int y, System.Drawing.Color color)
    {
        this.color = color;
        this.coords = new Int2(x, y);
    }
}

public class ImageHelper
{
    public static Dictionary<System.Drawing.Color, Ident> colorToIdent = new Dictionary<System.Drawing.Color, Ident>{
        {System.Drawing.Color.FromArgb(18,80, 150), new Ident("misc\\blue1.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(160, 160, 160), new Ident("misc\\grey.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(100, 62, 37), new Ident("misc\\brown.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(52, 101, 46), new Ident("misc\\green1.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(220, 220, 220), new Ident("misc\\white.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(0, 0, 0), new Ident("misc\\black.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(220, 20, 0), new Ident("misc\\red.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(55, 55, 55), new Ident("misc\\darkgrey.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(220, 200, 0), new Ident("misc\\yellow.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(242, 129, 0), new Ident("misc\\orange.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(123, 214, 255), new Ident("misc\\lightblue.Item.Gbx", "Stadium", "feor")},
        {System.Drawing.Color.FromArgb(53, 172, 74), new Ident("misc\\green3.Item.Gbx", "Stadium", "feor")},
    };

    public static double colorDifference(System.Drawing.Color color1, System.Drawing.Color color2)
    {
        // return Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2);
        double rmean = (color1.R + color2.R) / 2;
        double deltaR = color1.R - color2.R;
        double deltaG = color1.G - color2.G;
        double deltaB = color1.B - color2.B;
        double delta = (2 + rmean / 256) * Math.Pow(deltaR, 2) + 4 * Math.Pow(deltaG, 2) + (2 + (255 - rmean) / 256) * Math.Pow(deltaB, 2);
        return delta;
    }

    public static Ident getClosestIdent(System.Drawing.Color color)
    {
        Ident closestIdent = new Ident("StadiumDecoSet1/Decoration Set I/SmallBlackPillar.Item.Gbx", "Stadium", "szymon4325");
        double minDiff = -1;
        foreach (KeyValuePair<System.Drawing.Color, Ident> entry in colorToIdent)
        {
            double diff = colorDifference(color, entry.Key);
            if (minDiff == -1 || diff < minDiff)
            {
                minDiff = diff;
                closestIdent = entry.Value;
            }
        }
        return closestIdent;
    }

    public static List<Pixel> GetPixels(string imagePath)
    {
        List<Pixel> pixels = new List<Pixel>();
        Bitmap img = new Bitmap(imagePath);
        for (int i = 0; i < img.Width; i++)
        {
            for (int j = 0; j < img.Height; j++)
            {
                System.Drawing.Color pixel = img.GetPixel(i, j);
                if (pixel.A == 255)
                {
                    pixels.Add(new Pixel(i, j, pixel));
                }
            }
        }
        return pixels;
    }
}

