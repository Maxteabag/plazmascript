using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public static class PB2Map
    {
        public static List<MapObject> MapObjects { get; set; } = new List<MapObject>();
        
        static PB2Map()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize or reset the map system
        /// </summary>
        public static void Initialize()
        {
            // Clear any existing objects (in case of multiple runs)
            MapObjects.Clear();
        }

        /// <summary>
        /// Create a trigger action to set map gravity
        /// </summary>
        /// <param name="gravity">Gravity value (default is 0.5)</param>
        public static TriggerAction SetGravity(double gravity)
        {
            return new TriggerAction
            {
                ParameterA = gravity.ToString(),
                ParameterB = "-1",
                TriggerId = 5
            };
        }

        /// <summary>
        /// Create a trigger action to end the mission with a specific reason
        /// </summary>
        /// <param name="reason">The reason for ending the mission</param>
        public static TriggerAction EndMission(string reason)
        {
            return new TriggerAction
            {
                ParameterA = reason,
                ParameterB = "-1",
                TriggerId = 9
            };
        }


    }
}
