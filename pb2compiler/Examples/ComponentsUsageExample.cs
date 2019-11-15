using PlazmaScript.Components;
using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlazmaScript.Examples
{
    public class ComponentsUsageExample
    {
        /// <summary>
        /// Example of using components
        /// </summary>
        public ComponentsUsageExample()
        {
            var chatListenerComponent = new ChatListener();

            var welcomeText = new ShowTextAtBeginning("Welcome. Type -cmd for commands");

            var commandTrigger = chatListenerComponent.TriggerOnCommand("-cmd");
            commandTrigger.ShowText("The following commands are:");
            commandTrigger.ShowText("-help");

            var commandHelp = chatListenerComponent.TriggerOnCommand("-help");
            var helpShower = new Hint().ShowForDuration("There are no help here! Muhahahaha", Units.SecondsToGameTicks(3));
            commandHelp.Execute(helpShower);

        }
    }
}
