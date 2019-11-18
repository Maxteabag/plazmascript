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


        public Trigger(string uid = "", bool ExecuteAtStart = false)
        {
            if(string.IsNullOrEmpty(uid))
            {
                uid = RandomGenerator.RandomString(10);
            }
            Uid = uid;
            X = 0;
            Y = 0;
            Actions = new List<TriggerAction>();

            PB2Map.MapObjects.Add(this);

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



        public override XElement CreateXmlElement()
        {
            var triggerElement = new XElement("trigger");
            triggerElement.SetAttributeValue("uid", Uid);
            triggerElement.SetAttributeValue("x", X.ToString());
            triggerElement.SetAttributeValue("y", Y.ToString());
            triggerElement.SetAttributeValue("enabled", Enabled.ToString().ToLower());
            triggerElement.SetAttributeValue("maxcalls", MaxCalls.ToString());

            for (int i = 0; i < Actions.Count; i++)
            {
                if (i > 10)
                {
                    throw new Exception("Actions on trigger exceeded 10 on " + Uid);
                }
                var triggerAction = Actions[i];

                var actionIndex = i + 1;

                var actionAttributeType = "actions_" + actionIndex + "_type";
                var actionAttributeParameterA = "actions_" + actionIndex + "_targetA";
                var actionAttributeParameterB = "actions_" + actionIndex + "_targetB";

                triggerElement.SetAttributeValue(actionAttributeType, triggerAction.TriggerId.ToString());
                triggerElement.SetAttributeValue(actionAttributeParameterA, triggerAction.ParameterA.ToString());
                triggerElement.SetAttributeValue(actionAttributeParameterB, triggerAction.ParameterB.ToString());
            }

            return triggerElement;
        }
    }
}
