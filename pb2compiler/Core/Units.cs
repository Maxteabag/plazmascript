using System;
using System.Collections.Generic;
using System.Text;

namespace PlazmaScript.Core
{
    class Units
    {
        public static int SecondsToGameTicks(double seconds)
        {
            return (int)seconds * 30;
        }
    }

    public class MaxCalls
    {
        public static int INFINITE = -1;
    }

    public class Colors
    {
        public static string WarningColor = "#FF0000";
        public static string ImportantColor = "#FFFF00";
        public static string SuccessColor = "#00FF00";
        public static string NeutralColor = "#00FF00";
    }
}
