using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public class Door : SizedObject
    {
        public bool Moving { get; set; } = false;
        public int TarX { get; set; } = 0;
        public int TarY { get; set; } = 0;
        public int MaxSpeed { get; set; } = 10;
        public bool Visible { get; set; } = true;
        public int Attach { get; set; } = -1;

        public Door(string uid, int x, int y, int width, int height)
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

        public TriggerAction MoveTo(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 0
            };
        }

        /// <summary>
        /// Change the movement speed of this door/movable
        /// </summary>
        /// <param name="speed">The new speed value</param>
        public TriggerAction SetSpeed(double speed)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = speed.ToString(),
                TriggerId = 1
            };
        }

        public override XElement CreateXmlElement()
        {
            var element = new XElement("door");

            element.SetAttributeValue("uid", Uid);
            element.SetAttributeValue("x", X.ToString());
            element.SetAttributeValue("y", Y.ToString());
            element.SetAttributeValue("w", Width.ToString());
            element.SetAttributeValue("h", Height.ToString());
            element.SetAttributeValue("tarx", TarX.ToString());
            element.SetAttributeValue("tary", TarY.ToString());
            element.SetAttributeValue("maxspeed", MaxSpeed.ToString());
            element.SetAttributeValue("vis", Visible.ToString().ToLower());
            element.SetAttributeValue("moving", Moving.ToString().ToLower());
            element.SetAttributeValue("attach", Attach.ToString());

            return element;
        }
    }
}
