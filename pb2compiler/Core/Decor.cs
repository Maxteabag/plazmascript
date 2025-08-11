using System.Collections.Generic;
using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public enum DecorModel
    {
        Stone,
        Wood,
        Metal,
        Concrete
    }

    public class Decor : LinkedObject
    {
        public DecorModel Model { get; set; }

        public Decor(string uid, int x, int y, DecorModel model)
        {
            Uid = uid;
            X = x;
            Y = y;
            Model = model;
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var decorElement = new XElement("decor");
            
            var modelMap = new Dictionary<DecorModel, string>
            {
                { DecorModel.Stone, "stone" },
                { DecorModel.Wood, "wood" },
                { DecorModel.Metal, "metal" },
                { DecorModel.Concrete, "concrete" }
            };

            decorElement.SetAttributeValue("uid", Uid);
            decorElement.SetAttributeValue("model", modelMap[Model]);
            decorElement.SetAttributeValue("x", X.ToString());
            decorElement.SetAttributeValue("y", Y.ToString());
            
            return decorElement;
        }
    }
}