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
            xElement.SetAttributeValue("comp", Pb2Config.Fragment.Id);
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

    }
}
