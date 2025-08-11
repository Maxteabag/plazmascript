using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public class GravitatorAreaField : LinkedObject
    {
        public double XAcceleration { get; set; } = 0;
        public double YAcceleration { get; set; } = 0;
        public double StabilityDamage { get; set; } = 0;
        public double Damage { get; set; } = 0;

        public GravitatorAreaField(string uid, int x, int y, int width, int height)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }

            Uid = uid;
            X = x;
            Y = y;
            // Note: GravitatorAreaField might need width and height properties
            // Adding them as needed for the physics field area
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Set X acceleration of this Gravitator Area Field to value
        /// </summary>
        /// <param name="acceleration">X acceleration value</param>
        public TriggerAction SetXAcceleration(double acceleration)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = acceleration.ToString(),
                TriggerId = 35
            };
        }

        /// <summary>
        /// Set Y acceleration of this Gravitator Area Field to value
        /// </summary>
        /// <param name="acceleration">Y acceleration value</param>
        public TriggerAction SetYAcceleration(double acceleration)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = acceleration.ToString(),
                TriggerId = 36
            };
        }

        /// <summary>
        /// Set stability damage of this Gravitator Area Field to value (0 for disable)
        /// </summary>
        /// <param name="damage">Stability damage value (0 to disable)</param>
        public TriggerAction SetStabilityDamage(double damage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = damage.ToString(),
                TriggerId = 37
            };
        }

        /// <summary>
        /// Set damage of this Gravitator Area Field to value (0 for disable)
        /// </summary>
        /// <param name="damage">Damage value (0 to disable)</param>
        public TriggerAction SetDamage(double damage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = damage.ToString(),
                TriggerId = 38
            };
        }

        public override XElement CreateXmlElement()
        {
            //TODO: Verify actual XML structure for GravitatorAreaField elements in PB2
            var element = new XElement("gravitator_area_field");
            element.SetAttributeValue("uid", Uid);
            element.SetAttributeValue("x", X.ToString());
            element.SetAttributeValue("y", Y.ToString());
            element.SetAttributeValue("x_accel", XAcceleration.ToString());
            element.SetAttributeValue("y_accel", YAcceleration.ToString());
            element.SetAttributeValue("stability_damage", StabilityDamage.ToString());
            element.SetAttributeValue("damage", Damage.ToString());
            return element;
        }
    }
}