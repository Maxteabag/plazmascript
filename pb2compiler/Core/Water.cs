using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public class Water : SizedObject
    {
        public int Damage { get; set; } = 0;
        public bool Friction { get; set; } = true;

        public Water(string uid, int x, int y, int width, int height)
        {
            Uid = uid;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            PB2Map.MapObjects.Add(this);
        }

        public Water(string uid, int x, int y, int width, int height, int damage)
        {
            Uid = uid;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Damage = damage;
            PB2Map.MapObjects.Add(this);
        }

        public Water(string uid, int x, int y, int width, int height, int damage, bool friction)
        {
            Uid = uid;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Damage = damage;
            Friction = friction;
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var waterElement = new XElement("water");
            
            waterElement.SetAttributeValue("uid", Uid);
            waterElement.SetAttributeValue("x", X.ToString());
            waterElement.SetAttributeValue("y", Y.ToString());
            waterElement.SetAttributeValue("w", Width.ToString());
            waterElement.SetAttributeValue("h", Height.ToString());
            waterElement.SetAttributeValue("damage", Damage.ToString());
            
            if (!Friction)
            {
                waterElement.SetAttributeValue("friction", "false");
            }
            
            return waterElement;
        }
    }
}