using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlazmaScript.Components
{
    public class RequestComponent
    {
        public Trigger OnLoaded { get; set; }
        public Variable Response { get; set; } = new Variable();

        /// <summary>
        /// Call a URL, waits for response and returns the response
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Variable Call(string url)
        {

            var request = new Variable();

            var trigger = new Trigger(ExecuteAtStart: true);


            var checkIfResponse = new Trigger()
            {
                MaxCalls = MaxCalls.INFINITE
            };

            var repeater = new Timer()
            {
                LaunchedOnStart = false,
                Target = checkIfResponse,
                Delay = 10,
                MaxCalls = MaxCalls.INFINITE,
            };

            checkIfResponse.ContinueIf(Response != "loading...");
            checkIfResponse.AddAction(repeater.Deactivate());

            if (OnLoaded != null)
            {
                checkIfResponse.Execute(this.OnLoaded);
            }

            trigger.AddAction(request.SetValue(url));
            trigger.PostRequest(request, Response);
            trigger.AddAction(repeater.Activate());

            return Response;

        }
    }
}
