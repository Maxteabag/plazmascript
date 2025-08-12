using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public class Trigger : LinkedObject
    {
        public Trigger Child { get; set; }
        public bool HasCreatedChild { get; set; }
        public List<TriggerAction> Actions { get; private set; }
        public bool Enabled { get; set; } = true;
        public int MaxCalls { get; set; } = -1; //Infinite by default


        public Trigger(string uid = "", bool ExecuteAtStart = false, bool autoAddToMap = true)
        {
            if(string.IsNullOrEmpty(uid))
            {
                uid = RandomGenerator.RandomString(10);
            }
            
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Uid = uid;
            X = 0;
            Y = 0;
            Actions = new List<TriggerAction>();

            if (autoAddToMap)
            {
                PB2Map.MapObjects.Add(this);
            }

            if (ExecuteAtStart)
            {
                var executeTimer = new Timer
                {
                    Delay = 0,
                    LaunchedOnStart = true,
                    MaxCalls = 1,
                    Target = this,
                };
            }
        }

        public void AddAction(TriggerAction triggeraction)
        {
            if (Actions.Count == 9 && !HasCreatedChild)
            {
                HasCreatedChild = true;
                Child = new Trigger();
                Execute(Child);
                Child.AddAction(triggeraction);
            }
            else if (Actions.Count == 10)
            {
                if (Child == null)
                {
                    throw new Exception("Child was not set despite action count is 10");
                }
                Child.AddAction(triggeraction);
            }
            else
            {
                Actions.Add(triggeraction);
            }
        }

        public void SetAsChatReciever()
        {
            AddAction(new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 156
            });
        }
        public void ContinueIf(TriggerAction triggeraction)
        {
            AddAction(triggeraction);
        }

        public void ContinueIf(List<TriggerAction> triggeractions)
        {
            foreach (var action in triggeractions)
            {
                AddAction(action);
            }
        }


        public void SetVariable(string variableName, int value)
        {
            SetVariable(variableName, value.ToString());
        }

        public void SetVariable(Variable variable, int value)
        {
            SetVariable(variable.Name, value.ToString());
        }

        public void SetVariable(Variable variable, string value)
        {
            SetVariable(variable.Name, value);
        }



        public void SetVariable(string variableName, string value)
        {
            AddAction(new TriggerAction
            {
                ParameterA = variableName,
                ParameterB = value,
                TriggerId = 100
            });
        }

        internal object LaunchAtStart()
        {
            throw new NotImplementedException();
        }

        public void ContinueIfVariableEqualsValue(string variable, int value)
        {
            ContinueIfVariableEqualsValue(variable, value.ToString());
        }

        public void ContinueIfVariableEqualsValue(string variable, string value)
        {
            AddAction(new TriggerAction
            {
                ParameterA = variable,
                ParameterB = value,
                TriggerId = 116
            });
        }

        internal void ShowText(Variable text, string color = "#FFFFFF")
        {
            AddAction(new TriggerAction
            {
                ParameterA = text.Name,
                ParameterB = color,
                TriggerId = 42
            });
        }

        internal void ShowText(string text, string color = "#FFFFFF")
        {
            AddAction(new TriggerAction
            {
                ParameterA = text,
                ParameterB = color,
                TriggerId = 42
            });
        }

        internal void ShowHint(Variable variable)
        {
            AddAction(new TriggerAction
            {
                ParameterA = variable.Name,
                ParameterB = "-1",
                TriggerId = 43
            });
        }
        internal void ShowHint(string text)
        {
            AddAction(new TriggerAction
            {
                ParameterA = text,
                ParameterB = "-1",
                TriggerId = 43
            });
        }

        internal void HideHint()
        {
            AddAction(new TriggerAction
            {
                ParameterA = "",
                ParameterB = "-1",
                TriggerId = 43
            });
        }

        public void Execute(string triggerUid)
        {
            AddAction(new TriggerAction
            {
                ParameterA = triggerUid,
                ParameterB = "-1",
                TriggerId = 99
            });
        }
        public void Execute(Trigger trigger)
        {
            trigger.X = X + 30;
            trigger.Y = Y;

            Execute(trigger.Uid);
        }

        /// <summary>
        /// Execute a trigger on the next tick (after current execution chain completes).
        /// Uses a Timer with infinite calls that disables itself after first execution to prevent intra-tick variable conflicts.
        /// </summary>
        /// <param name="triggerUid">UID of trigger to execute next tick</param>
        public void ExecuteOnNextTick(string triggerUid)
        {
            // Create cleanup trigger that disables the timer and executes the target
            var cleanupTrigger = new Trigger()
            {
                X = X + 60,
                Y = Y
            };
            
            // Create timer with infinite calls but disabled initially
            var deferredTimer = new Timer(0, -1, false, cleanupTrigger.Uid, true)
            {
                X = X + 30,
                Y = Y
            };
            
            // Cleanup trigger disables the timer and executes the target
            cleanupTrigger.AddAction(deferredTimer.Deactivate());
            cleanupTrigger.Execute(triggerUid);
            
            // Activate the timer to start the next-tick execution
            AddAction(deferredTimer.Activate());
        }

        /// <summary>
        /// Execute a trigger on the next tick (after current execution chain completes).
        /// Uses a Timer with delay 0 to defer execution, preventing intra-tick variable conflicts.
        /// </summary>
        /// <param name="trigger">Trigger to execute next tick</param>
        public void ExecuteOnNextTick(Trigger trigger)
        {
            trigger.X = X + 30;
            trigger.Y = Y;
            ExecuteOnNextTick(trigger.Uid);
        }

        /// <summary>
        /// Request webpage with URL stored in <paramref name="request"/> to <paramref name="response"/>. <paramref name="response"/> will be "loading..." for some time.
        /// </summary>
        /// <param name="trigger"></param>
        public void PostRequest(Variable request, Variable response)
        {
            Actions.Add(new TriggerAction
            {
                ParameterA = request.Name,
                ParameterB = response.Name,
                TriggerId = 169
            });
        }

        /// <summary>
        /// Deactivate another trigger
        /// </summary>
        /// <param name="trigger">The trigger to deactivate</param>
        public void Deactivate(Trigger trigger)
        {
            AddAction(new TriggerAction
            {
                ParameterA = trigger.Uid,
                ParameterB = "-1",
                TriggerId = 19
            });
        }

        /// <summary>
        /// Activate another trigger
        /// </summary>
        /// <param name="trigger">The trigger to activate</param>
        public void Activate(Trigger trigger)
        {
            AddAction(new TriggerAction
            {
                ParameterA = trigger.Uid,
                ParameterB = "-1",
                TriggerId = 20
            });
        }

        /// <summary>
        /// Reset the number of remaining calls for another trigger to 0
        /// </summary>
        /// <param name="trigger">The trigger to reset</param>
        public void ResetCalls(Trigger trigger)
        {
            AddAction(new TriggerAction
            {
                ParameterA = trigger.Uid,
                ParameterB = "-1",
                TriggerId = 21
            });
        }

        /// <summary>
        /// Set number of remain calls of another trigger to a specific value
        /// </summary>
        /// <param name="trigger">The target trigger</param>
        /// <param name="remainingCalls">Number of remaining calls</param>
        public void SetRemainingCalls(Trigger trigger, int remainingCalls)
        {
            AddAction(new TriggerAction
            {
                ParameterA = trigger.Uid,
                ParameterB = remainingCalls.ToString(),
                TriggerId = 22
            });
        }

        /// <summary>
        /// Call this trigger each time new player joins the match
        /// </summary>
        public TriggerAction CallOnNewPlayerJoin()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 228
            };
        }

        /// <summary>
        /// Continue execution only if session variable was set by map with specific ID(s)
        /// </summary>
        /// <param name="sessionVariable">Session variable to check</param>
        /// <param name="mapIds">Map ID(s) - can be comma-separated list without spaces</param>
        public TriggerAction ContinueIfSessionVariableFromMap(Variable sessionVariable, string mapIds)
        {
            return new TriggerAction
            {
                ParameterA = sessionVariable.Name,
                ParameterB = mapIds,
                TriggerId = 230
            };
        }

        public override XElement CreateXmlElement()
        {
            var triggerElement = new XElement("trigger");
            triggerElement.SetAttributeValue("uid", Uid);
            triggerElement.SetAttributeValue("x", X.ToString());
            triggerElement.SetAttributeValue("y", Y.ToString());
            triggerElement.SetAttributeValue("enabled", Enabled.ToString().ToLower());
            triggerElement.SetAttributeValue("maxcalls", MaxCalls.ToString());

            // Always generate all 10 action slots
            for (int i = 0; i < 10; i++)
            {
                var actionIndex = i + 1;
                var actionAttributeType = "actions_" + actionIndex + "_type";
                var actionAttributeParameterA = "actions_" + actionIndex + "_targetA";
                var actionAttributeParameterB = "actions_" + actionIndex + "_targetB";

                if (i < Actions.Count)
                {
                    // Use actual action
                    var triggerAction = Actions[i];
                    triggerElement.SetAttributeValue(actionAttributeType, triggerAction.TriggerId.ToString());
                    triggerElement.SetAttributeValue(actionAttributeParameterA, triggerAction.ParameterA ?? "0");
                    triggerElement.SetAttributeValue(actionAttributeParameterB, triggerAction.ParameterB ?? "0");
                }
                else
                {
                    // Empty action slot
                    triggerElement.SetAttributeValue(actionAttributeType, "-1");
                    triggerElement.SetAttributeValue(actionAttributeParameterA, "0");
                    triggerElement.SetAttributeValue(actionAttributeParameterB, "0");
                }
            }

            return triggerElement;
        }
    }
}
