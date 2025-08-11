using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public class Player : LinkedObject
    {
        public int TargetX { get; set; } = 0;
        public int TargetY { get; set; } = 0;
        public int Health { get; set; } = 130;
        public int MaxHealth { get; set; } = 130;
        public int Team { get; set; } = 0;
        public int Side { get; set; } = 1;
        public int Character { get; set; } = 1; // Character model ID
        public int InCar { get; set; } = -1;
        public int BotAction { get; set; } = 0;
        public int OnDeath { get; set; } = -1;

        public Player(string uid, int x, int y)
        {
            Uid = uid;
            X = x;
            Y = y;
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Set the player's health to a specific value
        /// </summary>
        /// <param name="health">Health value</param>
        public TriggerAction SetHealth(int health)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = health.ToString(),
                TriggerId = 4
            };
        }

        /// <summary>
        /// Move this player to a region
        /// </summary>
        /// <param name="region">The target region</param>
        public TriggerAction MoveToRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 14
            };
        }

        /// <summary>
        /// Put this player into a vehicle
        /// </summary>
        /// <param name="vehicle">The vehicle to enter</param>
        public TriggerAction EnterVehicle(Vehicle vehicle)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = vehicle.Uid,
                TriggerId = 13
            };
        }

        public override XElement CreateXmlElement()
        {
            var playerElement = new XElement("player");
            playerElement.SetAttributeValue("uid", Uid);
            playerElement.SetAttributeValue("x", X.ToString());
            playerElement.SetAttributeValue("y", Y.ToString());
            playerElement.SetAttributeValue("tox", TargetX.ToString());
            playerElement.SetAttributeValue("toy", TargetY.ToString());
            playerElement.SetAttributeValue("hea", Health.ToString());
            playerElement.SetAttributeValue("hmax", MaxHealth.ToString());
            playerElement.SetAttributeValue("team", Team.ToString());
            playerElement.SetAttributeValue("side", Side.ToString());
            playerElement.SetAttributeValue("char", Character.ToString());
            playerElement.SetAttributeValue("incar", InCar.ToString());
            playerElement.SetAttributeValue("botaction", BotAction.ToString());
            playerElement.SetAttributeValue("ondeath", OnDeath.ToString());
            return playerElement;
        }
    }
}