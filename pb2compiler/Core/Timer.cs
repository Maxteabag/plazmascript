using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public class Timer : LinkedObject
    {
        public bool LaunchedOnStart { get; set; } = false;
        public int Delay { get; set; } = 30;
        public int MaxCalls { get; set; } = 1;
        public Trigger Target { get; set; }
        private string _targetUid;


        public Timer(string uid)
        {
            Uid = uid;
            X = 0;
            Y = 0;
            PB2Map.MapObjects.Add(this);
        }

        public Timer()
        {
            Uid = RandomGenerator.RandomString(10);
            X = 0;
            Y = 0;
            PB2Map.MapObjects.Add(this);
        }

        public Timer(int delay, int maxCalls, bool launchedOnStart, string targetUid, bool autoAddToMap = true)
        {
            Uid = RandomGenerator.RandomString(10);
            X = 0;
            Y = 0;
            Delay = delay;
            MaxCalls = maxCalls;
            LaunchedOnStart = launchedOnStart;
            _targetUid = targetUid;
            
            if (autoAddToMap)
            {
                PB2Map.MapObjects.Add(this);
            }
        }

        public override XElement CreateXmlElement()
        {
            var element = new XElement("timer");

            element.SetAttributeValue("uid", Uid);
            element.SetAttributeValue("x", X.ToString());
            element.SetAttributeValue("y", Y.ToString());
            element.SetAttributeValue("maxcalls", MaxCalls.ToString());
            element.SetAttributeValue("delay", Delay.ToString());
            element.SetAttributeValue("enabled", LaunchedOnStart.ToString().ToLower());

            if (Target != null)
            {
                element.SetAttributeValue("target", Target.Uid);
            }
            else if (!string.IsNullOrEmpty(_targetUid))
            {
                element.SetAttributeValue("target", _targetUid);
            }
            else
            {
                element.SetAttributeValue("target", "-1");
            }

            return element;
        }

        internal TriggerAction Activate()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 25
            };
        }

        internal TriggerAction Deactivate()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 26
            };
        }

        internal TriggerAction SetRemainingCalls(int v)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = v.ToString(),
                TriggerId = 46
            };
        }

        /// <summary>
        /// Set the frequency of calls of this timer to a specific value
        /// </summary>
        /// <param name="frequency">The new frequency value</param>
        public TriggerAction SetFrequency(int frequency)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = frequency.ToString(),
                TriggerId = 27
            };
        }

        /// <summary>
        /// Reset current phase of between-call waiting of this timer
        /// </summary>
        public TriggerAction ResetPhase()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 44
            };
        }
    }
}
