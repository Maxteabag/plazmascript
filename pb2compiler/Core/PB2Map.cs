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

        /// <summary>
        /// Set game speed to a specific frames per second value
        /// </summary>
        /// <param name="framesPerSecond">Frames per second (default is 30)</param>
        public static TriggerAction SetGameSpeed(int framesPerSecond)
        {
            return new TriggerAction
            {
                ParameterA = framesPerSecond.ToString(),
                ParameterB = "-1",
                TriggerId = 39
            };
        }

        /// <summary>
        /// Change Strict Casual Mode status
        /// </summary>
        /// <param name="enabled">Enable or disable strict casual mode</param>
        public static TriggerAction SetStrictCasualMode(bool enabled)
        {
            return new TriggerAction
            {
                ParameterA = enabled ? "1" : "0",
                ParameterB = "-1",
                TriggerId = 40
            };
        }

        /// <summary>
        /// Play sound from library
        /// </summary>
        /// <param name="soundName">The name of the sound to play</param>
        public static TriggerAction PlaySound(string soundName)
        {
            return new TriggerAction
            {
                ParameterA = soundName,
                ParameterB = "-1",
                TriggerId = 41
            };
        }

        /// <summary>
        /// Allow or disallow usage of defibrillators by allies
        /// </summary>
        /// <param name="allowed">True to allow, false to disallow</param>
        public static TriggerAction SetDefibrillatorUsage(bool allowed)
        {
            return new TriggerAction
            {
                ParameterA = allowed ? "1" : "0",
                ParameterB = "-1",
                TriggerId = 45
            };
        }

        /// <summary>
        /// Set disabling of psi swords
        /// </summary>
        /// <param name="disabled">True to disable, false to enable</param>
        public static TriggerAction SetPsiSwordsDisabled(bool disabled)
        {
            return new TriggerAction
            {
                ParameterA = disabled ? "1" : "0",
                ParameterB = "-1",
                TriggerId = 49
            };
        }

        /// <summary>
        /// Mission complete and switch to level with specific ID
        /// </summary>
        /// <param name="levelId">The level ID to switch to</param>
        public static TriggerAction CompleteMissionAndSwitchLevel(string levelId)
        {
            return new TriggerAction
            {
                ParameterA = levelId,
                ParameterB = "-1",
                TriggerId = 50
            };
        }

        /// <summary>
        /// Zoom game camera to specific percentage
        /// </summary>
        /// <param name="percentage">Zoom percentage</param>
        public static TriggerAction ZoomCamera(int percentage)
        {
            return new TriggerAction
            {
                ParameterA = percentage.ToString(),
                ParameterB = "-1",
                TriggerId = 51
            };
        }


    }
}
