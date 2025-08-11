using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public class Box : SizedObject
    {
        public int Material { get; set; } = 0;

        public Box(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            PB2Map.MapObjects.Add(this);
        }

        public Box(int x, int y, int width, int height, int material)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Material = material;
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var boxElement = new XElement("box");
            
            boxElement.SetAttributeValue("x", X.ToString());
            boxElement.SetAttributeValue("y", Y.ToString());
            boxElement.SetAttributeValue("w", Width.ToString());
            boxElement.SetAttributeValue("h", Height.ToString());
            boxElement.SetAttributeValue("m", Material.ToString());
            
            return boxElement;
        }
    }
}