using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
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