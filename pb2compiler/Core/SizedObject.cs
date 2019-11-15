using System;
using System.Collections.Generic;
using System.Text;

namespace PlazmaScript.Core
{
    public abstract class SizedObject : LinkedObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

}
