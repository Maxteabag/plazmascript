using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlazmaScript.Components
{
    public class ShowTextAtBeginning
    {
        public ShowTextAtBeginning(string text, string color = "#FFFFFF", int delay = 0)
        {
            Init(text, color, delay);
        }


        private void Init(string text, string color, int delay)
        {
            var trigger = new Trigger();

            var timer = new Timer
            {
                Delay = delay,
                LaunchedOnStart = true,
                MaxCalls = 1,
                Target = trigger
            };

            trigger.ShowText(text, color);
        }
    }
}
