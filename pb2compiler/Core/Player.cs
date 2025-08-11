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

        /// <summary>
        /// Damage this player's head hitpoints by specified value
        /// </summary>
        /// <param name="damage">Damage amount</param>
        public TriggerAction DamageHead(int damage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = damage.ToString(),
                TriggerId = 141
            };
        }

        /// <summary>
        /// Damage this player's arms hitpoints by specified value
        /// </summary>
        /// <param name="damage">Damage amount</param>
        public TriggerAction DamageArms(int damage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = damage.ToString(),
                TriggerId = 142
            };
        }

        /// <summary>
        /// Damage this player's body hitpoints by specified value
        /// </summary>
        /// <param name="damage">Damage amount</param>
        public TriggerAction DamageBody(int damage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = damage.ToString(),
                TriggerId = 143
            };
        }

        /// <summary>
        /// Damage this player's legs hitpoints by specified value
        /// </summary>
        /// <param name="damage">Damage amount</param>
        public TriggerAction DamageLegs(int damage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = damage.ToString(),
                TriggerId = 144
            };
        }

        /// <summary>
        /// Heal this player by specified hit points
        /// </summary>
        /// <param name="healAmount">Amount to heal</param>
        public TriggerAction Heal(int healAmount)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = healAmount.ToString(),
                TriggerId = 255
            };
        }

        /// <summary>
        /// Heal this player by value from a variable
        /// </summary>
        /// <param name="healVariable">Variable containing heal amount</param>
        public TriggerAction Heal(Variable healVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = healVariable.Name,
                TriggerId = 256
            };
        }

        /// <summary>
        /// Set jump multiplier for this player
        /// </summary>
        /// <param name="multiplier">Jump multiplier value</param>
        public TriggerAction SetJumpMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = multiplier.ToString(),
                TriggerId = 297
            };
        }

        /// <summary>
        /// Set intensity scale of entity pushing force for this player (default 0)
        /// </summary>
        /// <param name="intensity">Pushing force intensity</param>
        public TriggerAction SetPushingForceIntensity(double intensity)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = intensity.ToString(),
                TriggerId = 270
            };
        }

        /// <summary>
        /// Set radius of entity pushing force for this player (default 200)
        /// </summary>
        /// <param name="radius">Pushing force radius</param>
        public TriggerAction SetPushingForceRadius(double radius)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = radius.ToString(),
                TriggerId = 271
            };
        }

        /// <summary>
        /// Set player-initiator team to specified value
        /// </summary>
        /// <param name="team">Team ID</param>
        public static TriggerAction SetPlayerInitiatorTeam(int team)
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = team.ToString(),
                TriggerId = 317
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