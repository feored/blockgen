using GBX.NET;
using GBX.NET.Engines.Game;
using GBX.NET.LZO;
public class BlockBuilder
{
    public string MAPS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Maniaplanet/Maps/My Maps/";
    private string map_path;
    public CGameCtnChallenge map;

    public BlockBuilder(string map_name)
    {
        Gbx.LZO = new Lzo();
        map_path = MAPS_PATH + map_name + ".Map.Gbx";
        map = Gbx.ParseNode<CGameCtnChallenge>(map_path);
    }

    public void addBlocks(List<Int3> points, string blockName = "StadiumCircuitBase")
    {
        for (int i = 0; i < points.Count; i++)
        {
            map.PlaceBlock(blockName, points[i], Direction.North, false);
        }
    }

    public void addAnchoredObjects(Ident model, List<Int3> points)
    {
        for (int i = 0; i < points.Count; i++)
        {
            map.PlaceAnchoredObject(model, points[i], Vec3.Zero);
        }
    }

    public void addAnchordObject(Ident model, Int3 point)
    {
        map.PlaceAnchoredObject(model, point, Vec3.Zero);
    }

    public void save_map(string new_name = "")
    {

        if (new_name != "")
        {
            map.MapName = new_name;
            map.Save(MAPS_PATH + new_name + ".Map.Gbx");
            return;
        }
        map.Save(map_path);
    }
}
