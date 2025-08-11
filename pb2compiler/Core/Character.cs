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