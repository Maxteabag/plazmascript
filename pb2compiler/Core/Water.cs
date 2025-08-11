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

        /// <summary>
        /// Move this water to a region
        /// </summary>
        /// <param name="region">Region to move water to</param>
        public TriggerAction MoveToRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 392
            };
        }

        /// <summary>
        /// Set water damage to string-value or variable
        /// </summary>
        /// <param name="damage">Damage value as string</param>
        public TriggerAction SetDamage(string damage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = damage,
                TriggerId = 395
            };
        }

        /// <summary>
        /// Set water damage using a variable
        /// </summary>
        /// <param name="damageVariable">Variable containing damage value</param>
        public TriggerAction SetDamage(Variable damageVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = damageVariable.Name,
                TriggerId = 395
            };
        }

        /// <summary>
        /// Change water color to string-value or variable
        /// </summary>
        /// <param name="color">Color value as string</param>
        public TriggerAction ChangeColor(string color)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = color,
                TriggerId = 409
            };
        }

        /// <summary>
        /// Change water color using a variable
        /// </summary>
        /// <param name="colorVariable">Variable containing color value</param>
        public TriggerAction ChangeColor(Variable colorVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = colorVariable.Name,
                TriggerId = 409
            };
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