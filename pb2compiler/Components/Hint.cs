using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlazmaScript.Components
{
    public class Hint
    {
        public Hint()
        {

        }

        public Trigger ShowForDuration(string text, int duration)
        {
            var trigger = new Trigger();
            var hideHintTrigger = new Trigger();
            var hideTimer = new Timer()
            {
                Delay = duration,
                LaunchedOnStart = false,
                MaxCalls = MaxCalls.INFINITE,
                Target = hideHintTrigger
            };


            trigger.ShowHint(text);
            trigger.AddAction(hideTimer.Activate());


            hideHintTrigger.HideHint();
            hideHintTrigger.AddAction(hideTimer.Deactivate());


            return trigger;
        }
    }
}
