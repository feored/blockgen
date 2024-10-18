using System;
using GBX.NET;

public class MapTool
{

    public static void Main(string[] args)
    {
        BlockBuilder blockBuilder = new BlockBuilder("basic_big");
        // foreach (var block in blockBuilder.map.Blocks)
        // {
        //     Console.WriteLine(block.Name);
        // }
        // foreach (var block in blockBuilder.map.GetAnchoredObjects())
        // {
        //     Console.WriteLine(block.ItemModel);
        //     Console.WriteLine(block.PackDesc);
        // }
        var scale = 4;
        var max_y = 32 * 32;
        List<Pixel> pixels = ImageHelper.GetPixels("YOUR_FILE_HERE.jpg");
        Console.WriteLine("Drawable pixels: " + pixels.Count);
        foreach (Pixel pixel in pixels)
        {
            var basex = 32 * 24;
            var basez = 32 * 24;
            //var pos = new Int3(pixel.coords.X * scale, 64 * 4 - (pixel.coords.Y * scale), 0);
            var pos = new Int3(basex + pixel.coords.X * scale, 16, basez + pixel.coords.Y * scale);
            var block = ImageHelper.getClosestIdent(pixel.color);
            blockBuilder.addAnchordObject(block, pos);
        }
        blockBuilder.save_map("Test");
    }
}
