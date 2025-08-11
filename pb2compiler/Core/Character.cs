using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public enum AIBehavior
    {
        Default = 0,
        FollowThePlayer = 1,
        LookAround = 2,
        Investigate = 3,
        DoNothing = 4
    }

    public enum CharacterTeam
    {
        Alpha = 0,
        Beta = 1,
        Gamma = 2,
        Delta = 3,
        Zeta = 4,
        Lambda = 5,
        Sigma = 6,
        Omega = 7,
        CounterTerrorists = 8,
        Terrorists = 9,
        UsurpationForces = 10,
        CitizenSecurity = 11,
        RedTeam = 12,
        BlueTeam = 13,
        GreenTeam = 14,
        WhiteTeam = 15,
        BlackTeam = 16,
        SpecialA = -1,
        SpecialB = -2,
        SpecialC = -3,
        SpecialD = -4,
        SpecialE = -5,
        SpecialF = -6
    }

    public class Character : LinkedObject
    {
        public Character(string uid, int x, int y)
        {
            Uid = uid;
            X = x;
            Y = y;
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Set the character's hit points to a percentage (0-100)
        /// </summary>
        /// <param name="percentage">Hit points percentage</param>
        public TriggerAction SetHitPoints(int percentage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = percentage.ToString(),
                TriggerId = 4
            };
        }

        /// <summary>
        /// Move this character to a region (if alive)
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
        /// Put this character into a vehicle
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
        /// Set current hit points of this character to a specific value
        /// </summary>
        /// <param name="hitPoints">Hit points value</param>
        public TriggerAction SetHitPoints(int hitPoints)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = hitPoints.ToString(),
                TriggerId = 23
            };
        }

        /// <summary>
        /// Clone this character and spawn it in the centre of a region
        /// </summary>
        /// <param name="region">The region to spawn the clone in</param>
        public TriggerAction CloneAndSpawn(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 28
            };
        }

        /// <summary>
        /// Force all enemies of this character who are located in a region to hunt for this character
        /// </summary>
        /// <param name="region">The region containing enemies</param>
        public TriggerAction ForceEnemiesInRegionHunt(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 29
            };
        }

        /// <summary>
        /// Set AI Behavior parameter of this computer-controlled character
        /// </summary>
        /// <param name="behavior">The AI behavior enum value</param>
        public TriggerAction SetAIBehavior(AIBehavior behavior)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = ((int)behavior).ToString(),
                TriggerId = 32
            };
        }

        /// <summary>
        /// Set AI Behavior parameter of this computer-controlled character
        /// </summary>
        /// <param name="behavior">The AI behavior value (0-4)</param>
        public TriggerAction SetAIBehavior(int behavior)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = behavior.ToString(),
                TriggerId = 32
            };
        }

        /// <summary>
        /// Change the team of this character
        /// </summary>
        /// <param name="team">The new team enum value</param>
        public TriggerAction ChangeTeam(CharacterTeam team)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = ((int)team).ToString(),
                TriggerId = 33
            };
        }

        /// <summary>
        /// Change the team of this character
        /// </summary>
        /// <param name="team">The new team value (-6 to 16)</param>
        public TriggerAction ChangeTeam(int team)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = team.ToString(),
                TriggerId = 33
            };
        }

        /// <summary>
        /// Multiply maximal and current hit points of this character by percentage
        /// </summary>
        /// <param name="percentage">Percentage multiplier</param>
        public TriggerAction MultiplyHitPoints(int percentage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = percentage.ToString(),
                TriggerId = 48
            };
        }

        /// <summary>
        /// Change the nickname of this character
        /// </summary>
        /// <param name="nickname">The new nickname</param>
        public TriggerAction ChangeNickname(string nickname)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = nickname,
                TriggerId = 52
            };
        }

        /// <summary>
        /// Clone this character and spawn it in a random place in a region
        /// </summary>
        /// <param name="region">The region to spawn the clone in</param>
        public TriggerAction CloneAndSpawnRandom(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 53
            };
        }

        public override XElement CreateXmlElement()
        {
            var characterElement = new XElement("character");
            characterElement.SetAttributeValue("uid", Uid);
            characterElement.SetAttributeValue("x", X.ToString());
            characterElement.SetAttributeValue("y", Y.ToString());
            return characterElement;
        }
    }
}