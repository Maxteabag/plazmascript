using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlazmaScript.Core
{

   
    public class Variable
    {
        public string Name { get; set; }
        public string Value { get; set; }



        public Variable(string name)
        {
            this.Name = name;
        }
        public Variable()
        {
            this.Name = RandomGenerator.RandomString(10);
        }
        public Variable(int name)
        {
            this.Name = name.ToString();
        }

        public TriggerAction SetValue(int value)
        {
            return SetValue(value.ToString());
        }
        public TriggerAction SetValue(string value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value,
                TriggerId = 100
            };
        }
        public TriggerAction SetValue(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 125
            };
        }

        public TriggerAction SetToTextBeingSaid()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 160
            };
        }

        /// <summary>
        /// Syncronize the variable with all other players overriding value
        /// </summary>
        /// <returns></returns>
        public TriggerAction Sync()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 223
            };
        }

        public List<TriggerAction> Contains(string value)
        {
            var actions = new List<TriggerAction>();

            var testVariable = new Variable();

            actions.Add(testVariable.SetValue(this));
            actions.Add(testVariable.SetToBooleanIfContains(value));
            actions.Add(testVariable == 1); //Continue if....

            return actions;
        }

        /// <summary>
        /// Set value to 1 if contains <paramref name="value"/> and set 0 in else case
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetToBooleanIfContains(string value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value,
                TriggerId = 149
            };
        }

        /// <summary>
        /// Set value to 1 if contains <paramref name="value"/> and set 0 in else case
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetToBooleanIfContains(Variable value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.Name,
                TriggerId = 150
            };
        }

        public TriggerAction SetValueIfNotDefined(int value)
        {
            return SetValueIfNotDefined(value.ToString());
        }
        public TriggerAction SetValueIfNotDefined(string value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value,
                TriggerId = 101
            };
        }

        public TriggerAction Add(int value)
        {
            return Add(value.ToString());
        }
        public TriggerAction Add(string value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value,
                TriggerId = 102
            };
        }
        public TriggerAction Multiply(int value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.ToString(),
                TriggerId = 103
            };
        }

        public TriggerAction Add(Variable b)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = b.Name.ToString(),
                TriggerId = 104
            };
        }
        public TriggerAction Multiply(Variable b)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = b.Name.ToString(),
                TriggerId = 105
            };
        }

        /// <summary>
        /// Set value of variable 'A' to random number with floating point in range 0...[value]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetRandom(int value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.ToString(),
                TriggerId = 106
            };
        }
        /// <summary>
        /// Set value of variable 'A' to random number with floating point in range 0...[value]-1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetRandomMinusOne(int value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.ToString(),
                TriggerId = 107
            };
        }

        public TriggerAction Round()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 108
            };
        }

        public TriggerAction Floor()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 109
            };
        }

        /// <summary>
        /// Set value of variable to value of region X position left corner
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetToRegionXLeftCorner(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = region.Uid,
                TriggerId = 118
            };
        }

        internal TriggerAction SkipNextActionIfNotEquals(string v)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = v,
                TriggerId = 123
            };
        }

        internal TriggerAction SetToPlayerHp(string v)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = v,
                TriggerId = 122
            };
        }

        /// <summary>
        /// Set value of variable to value of region Y position left corner
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetToRegionYLeftCorner(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = region.Uid,
                TriggerId = 119
            };
        }



        public static TriggerAction operator +(Variable a, int value)
        {
            return a.Add(value);
        }
        public static TriggerAction operator +(Variable a, string value)
        {
            return a.Add(value);
        }
        public static TriggerAction operator +(Variable a, Variable b)
        {
            return a.Add(b);
        }


        public static TriggerAction operator *(Variable a, int value)
        {
            return a.Multiply(value);
        }
        public static TriggerAction operator *(Variable a, Variable b)
        {
            return a.Multiply(b);
        }

        public static TriggerAction operator ==(Variable a, int value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value.ToString(),
                TriggerId = 116
            };
        }

        public static TriggerAction operator !=(Variable a, int value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value.ToString(),
                TriggerId = 117
            };
        }

        public static TriggerAction operator ==(Variable a, string value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value,
                TriggerId = 116
            };
        }

        public static TriggerAction operator !=(Variable a, string value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value,
                TriggerId = 117
            };
        }

        public static TriggerAction operator <(Variable a, int value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value.ToString(),
                TriggerId = 115
            };
        }

        public static TriggerAction operator >(Variable a, int value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value.ToString(),
                TriggerId = 114
            };
        }

        public static TriggerAction operator ==(Variable a, Variable b)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = b.Name,
                TriggerId = 112
            };
        }

        public static TriggerAction operator !=(Variable a, Variable b)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = b.Name,
                TriggerId = 113
            };
        }

        public static TriggerAction operator <(Variable a, Variable b)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = b.Name,
                TriggerId = 111
            };
        }

        public static TriggerAction operator >(Variable a, Variable b)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = b.Name,
                TriggerId = 110
            };
        }
    }
}
