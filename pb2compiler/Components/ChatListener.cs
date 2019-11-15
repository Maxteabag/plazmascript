using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlazmaScript.Components
{
    public class ChatListener
    {
        //There may be only 1 text-chat reciver per map
        private Trigger Listener { get; set; }
        public ChatListener()
        {
            Listener = new Trigger(ExecuteAtStart: true)
            {
                MaxCalls = MaxCalls.INFINITE
            };

            Listener.SetAsChatReciever();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command">The command the player says that will trigger the command, for instance: -cmd</param>
        /// <param name="exact">If command shall be trigged if what player says is exactly the command, or just if the text contains the command?</param>
        /// <returns>Returns the trigger that will be executed when the command is triggered</returns>
        public Trigger TriggerOnCommand(string command, bool exact=true)
        {
            var textBeingSaid = new Variable();
            var onExecuted = new Trigger()
            {
                MaxCalls = MaxCalls.INFINITE
            };

            var textChecker = new Trigger()
            {
                MaxCalls = MaxCalls.INFINITE
            };

            //Tell the single-listener to execute this
            Listener.Execute(textChecker);

            textChecker.AddAction(textBeingSaid.SetToTextBeingSaid());
            if (exact)
            {
                textChecker.ContinueIf(textBeingSaid == command);
            }
            else
            {
                textChecker.ContinueIf(textBeingSaid.Contains(command));
            }
            textChecker.Execute(onExecuted);

            return onExecuted;
        }
    }
}
