using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public class Enemy : LinkedObject
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

        public Enemy(string uid, int x, int y)
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

        public Enemy(string uid, int x, int y, int side)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Uid = uid;
            X = x;
            Y = y;
            Side = side;
            PB2Map.MapObjects.Add(this);
        }

        public Enemy(string uid, int x, int y, int side, int botAction)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Uid = uid;
            X = x;
            Y = y;
            Side = side;
            BotAction = botAction;
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Set the enemy's health to a specific value
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
        /// Move this enemy to a region
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
        /// Put this enemy into a vehicle
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
            var enemyElement = new XElement("enemy");
            enemyElement.SetAttributeValue("uid", Uid);
            enemyElement.SetAttributeValue("x", X.ToString());
            enemyElement.SetAttributeValue("y", Y.ToString());
            enemyElement.SetAttributeValue("tox", TargetX.ToString());
            enemyElement.SetAttributeValue("toy", TargetY.ToString());
            enemyElement.SetAttributeValue("hea", Health.ToString());
            enemyElement.SetAttributeValue("hmax", MaxHealth.ToString());
            enemyElement.SetAttributeValue("team", Team.ToString());
            enemyElement.SetAttributeValue("side", Side.ToString());
            enemyElement.SetAttributeValue("char", Character.ToString());
            enemyElement.SetAttributeValue("incar", InCar.ToString());
            enemyElement.SetAttributeValue("botaction", BotAction.ToString());
            enemyElement.SetAttributeValue("ondeath", OnDeath.ToString());
            return enemyElement;
        }
    }
}