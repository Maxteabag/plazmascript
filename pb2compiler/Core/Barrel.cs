using System.Collections.Generic;
using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public enum BarrelModel
    {
        Orange,
        Blue,
        Red,
        Green
    }

    public class Barrel : LinkedObject
    {
        public BarrelModel Model { get; set; }
        public int TargetX { get; set; } = 0;
        public int TargetY { get; set; } = 0;

        public Barrel(string uid, int x, int y, BarrelModel model = BarrelModel.Orange)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Uid = uid;
            X = x;
            Y = y;
            Model = model;
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var barrelElement = new XElement("barrel");
            
            var modelMap = new Dictionary<BarrelModel, string>
            {
                { BarrelModel.Orange, "bar_orange" },
                { BarrelModel.Blue, "bar_blue" },
                { BarrelModel.Red, "bar_red" },
                { BarrelModel.Green, "bar_green" }
            };

            barrelElement.SetAttributeValue("uid", Uid);
            barrelElement.SetAttributeValue("model", modelMap[Model]);
            barrelElement.SetAttributeValue("x", X.ToString());
            barrelElement.SetAttributeValue("y", Y.ToString());
            barrelElement.SetAttributeValue("tox", TargetX.ToString());
            barrelElement.SetAttributeValue("toy", TargetY.ToString());
            
            return barrelElement;
        }

        /// <summary>
        /// Move this barrel to a region (if barrel not exploded)
        /// </summary>
        /// <param name="region">The target region</param>
        public TriggerAction MoveToRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 16
            };
        }
    }
}