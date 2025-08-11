using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public enum WallMaterial
    {
        Concrete = 0,
        Grass = 1,
        Sand = 2,
        BrownConcrete = 3,
        DarkPlate = 4,
        DryGrass = 5,
        DarkGrass = 6,
        CleanDarkPlate = 7,
        BrightPlate = 8,
        CleanBrightPlate = 9,
        UsurpationPlate = 10,
        Stripes = 11,
        Asphalt = 12,
        WhiteConcrete = 13,
        PBFTTPLikeConcrete = 14,
        WetSand = 15,
        Mud = 16,
        UsurpationTiles = 17,
        StoneBricks = 18,
        Wood = 19,
        Rocks = 20,
        Black = -1
    }

    public class Box : SizedObject
    {
        public WallMaterial Material { get; set; } = WallMaterial.Concrete;

        public Box(int x, int y, int width, int height, WallMaterial material = WallMaterial.Concrete)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Material = material;
            PB2Map.MapObjects.Add(this);
        }

        // Backward compatibility constructor
        public Box(int x, int y, int width, int height, int material)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Material = (WallMaterial)material;
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var boxElement = new XElement("box");
            
            boxElement.SetAttributeValue("x", X.ToString());
            boxElement.SetAttributeValue("y", Y.ToString());
            boxElement.SetAttributeValue("w", Width.ToString());
            boxElement.SetAttributeValue("h", Height.ToString());
            boxElement.SetAttributeValue("m", ((int)Material).ToString());
            
            return boxElement;
        }
    }
}