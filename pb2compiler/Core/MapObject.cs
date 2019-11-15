using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public abstract class MapObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract XElement CreateXmlElement();

    }
}
