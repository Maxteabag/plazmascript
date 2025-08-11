using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public static class PB2Map
    {
        public static List<MapObject> MapObjects { get; set; } = new List<MapObject>();
        private static Trigger _initTrigger;
        private static Timer _initTimer;
        
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
            
            // Don't add objects to the list in constructors during initialization
            _initTrigger = new Trigger("map_init", true, false); // Pass false to skip auto-add
            MapObjects.Add(_initTrigger);
            
            // Create timer to trigger the initialization
            _initTimer = new Timer(0, 1, true, _initTrigger.Uid, false); // Pass false to skip auto-add
            MapObjects.Add(_initTimer);
        }

        /// <summary>
        /// Set the map's gravity (default is 0.5)
        /// </summary>
        public static double Gravity
        {
            set
            {
                _initTrigger.AddAction(new TriggerAction
                {
                    ParameterA = value.ToString(),
                    ParameterB = "-1",
                    TriggerId = 5
                });
            }
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
