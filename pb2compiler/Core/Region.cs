using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public class Region : SizedObject
    {
        public Region(string uid, int x, int y, int width, int height)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Uid = uid;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var xElement = new XElement("region");

            xElement.SetAttributeValue("uid", Uid);
            xElement.SetAttributeValue("x", X.ToString());
            xElement.SetAttributeValue("y", Y.ToString());
            xElement.SetAttributeValue("w", Width.ToString());
            xElement.SetAttributeValue("h", Height.ToString());

            return xElement;
        }

        /// <summary>
        /// Set X position of left-top corner point
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetXLeftTopCornerPoint(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = variable.Name,
                TriggerId = 120
            };
        }

        /// <summary>
        /// Set Y position of left-top corner point
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetYLeftTopCornerPoint(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = variable.Name,
                TriggerId = 121
            };
        }

        /// <summary>
        /// Quickly move this region to the position of another region
        /// </summary>
        /// <param name="targetRegion">The target region to move to</param>
        public TriggerAction QuickMoveToRegion(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 2
            };
        }

        /// <summary>
        /// Move this region to the center of another region
        /// </summary>
        /// <param name="targetRegion">The target region</param>
        public TriggerAction MoveToCenterOf(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 18
            };
        }

        /// <summary>
        /// Make damage in this region with specified power
        /// </summary>
        /// <param name="damage">The damage power in hit points</param>
        public TriggerAction MakeDamage(int damage)
        {
            return new TriggerAction
            {
                ParameterA = damage.ToString(),
                ParameterB = Uid,
                TriggerId = 6
            };
        }

        /// <summary>
        /// Destroy all vehicles in this region
        /// </summary>
        public TriggerAction DestroyAllVehicles()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 12
            };
        }

        /// <summary>
        /// Kill all characters in this region that are not allied to a specific character
        /// </summary>
        /// <param name="allyCharacter">Characters allied to this will be spared</param>
        public TriggerAction KillEnemiesOf(Character allyCharacter)
        {
            return new TriggerAction
            {
                ParameterA = allyCharacter.Uid,
                ParameterB = Uid,
                TriggerId = 11
            };
        }

        /// <summary>
        /// Harm the stability of all characters in this region
        /// </summary>
        /// <param name="power">The power of the stability harm</param>
        public TriggerAction HarmStability(int power)
        {
            return new TriggerAction
            {
                ParameterA = power.ToString(),
                ParameterB = Uid,
                TriggerId = 10
            };
        }

        /// <summary>
        /// Make an explosion with specified power at this region
        /// </summary>
        /// <param name="power">The explosion power</param>
        public TriggerAction MakeExplosion(int power)
        {
            return new TriggerAction
            {
                ParameterA = power.ToString(),
                ParameterB = Uid,
                TriggerId = 24
            };
        }

        /// <summary>
        /// Teleport all players from this region to another region
        /// </summary>
        /// <param name="targetRegion">The destination region</param>
        public TriggerAction TeleportAllPlayersTo(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 30
            };
        }

        /// <summary>
        /// Teleport all players from this region to another region and invert speed by X axis
        /// </summary>
        /// <param name="targetRegion">The destination region</param>
        public TriggerAction TeleportAllPlayersToWithSpeedInvert(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 31
            };
        }

    }
}
