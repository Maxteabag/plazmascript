using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public class Light : LinkedObject
    {
        public Light(string uid, int x, int y)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Uid = uid;
            X = x;
            Y = y;
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Turn this light on
        /// </summary>
        public TriggerAction TurnOn()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 54
            };
        }

        /// <summary>
        /// Turn this light off
        /// </summary>
        public TriggerAction TurnOff()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 55
            };
        }

        /// <summary>
        /// Change this light's color
        /// </summary>
        /// <param name="color">Color value</param>
        public TriggerAction ChangeColor(string color)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = color,
                TriggerId = 379
            };
        }

        public override XElement CreateXmlElement()
        {
            //TODO: Verify actual XML structure for light elements in PB2
            var lightElement = new XElement("light");
            lightElement.SetAttributeValue("uid", Uid);
            lightElement.SetAttributeValue("x", X.ToString());
            lightElement.SetAttributeValue("y", Y.ToString());
            return lightElement;
        }
    }
}