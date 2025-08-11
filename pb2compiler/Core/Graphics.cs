using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public class Graphics : MapObject
    {
        public string Name { get; set; }
        public int Layer { get; set; }

        public Graphics(string name, int layer)
        {
            Name = name;
            Layer = layer;
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Create graphic with this name at specified layer
        /// </summary>
        /// <param name="name">Graphic name</param>
        /// <param name="layer">Layer (1 is lowest, 3 is highest)</param>
        public static TriggerAction CreateGraphic(string name, int layer)
        {
            return new TriggerAction
            {
                ParameterA = name,
                ParameterB = layer.ToString(),
                TriggerId = 383
            };
        }

        /// <summary>
        /// Select graphic to draw on with this name
        /// </summary>
        public TriggerAction SelectGraphic()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 384
            };
        }

        /// <summary>
        /// Begin fill of this graphic using hex-colour
        /// </summary>
        /// <param name="hexColor">HEX color for fill</param>
        public TriggerAction BeginFill(string hexColor)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = hexColor,
                TriggerId = 385
            };
        }

        /// <summary>
        /// End fill of this graphic
        /// </summary>
        public TriggerAction EndFill()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 386
            };
        }

        /// <summary>
        /// Draw circle on current graphic at top-left of region with radius
        /// </summary>
        /// <param name="region">Region for circle position</param>
        /// <param name="radius">Circle radius</param>
        public static TriggerAction DrawCircle(Region region, double radius)
        {
            return new TriggerAction
            {
                ParameterA = region.Uid,
                ParameterB = radius.ToString(),
                TriggerId = 387
            };
        }

        /// <summary>
        /// Clear this graphic
        /// </summary>
        public TriggerAction Clear()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 388
            };
        }

        /// <summary>
        /// Set line style of current graphic to thickness and hex-colour
        /// </summary>
        /// <param name="thickness">Line thickness</param>
        /// <param name="hexColor">HEX color</param>
        public static TriggerAction SetLineStyle(double thickness, string hexColor)
        {
            return new TriggerAction
            {
                ParameterA = thickness.ToString(),
                ParameterB = hexColor,
                TriggerId = 389
            };
        }

        /// <summary>
        /// Set starting position of this graphic to region
        /// </summary>
        /// <param name="region">Region for starting position</param>
        public TriggerAction SetStartingPosition(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = region.Uid,
                TriggerId = 390
            };
        }

        /// <summary>
        /// Draw line from current position of this graphic to top-left of region
        /// </summary>
        /// <param name="region">Target region</param>
        public TriggerAction DrawLineTo(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = region.Uid,
                TriggerId = 391
            };
        }

        /// <summary>
        /// Set opacity of this graphic to variable (percent)
        /// </summary>
        /// <param name="opacityVariable">Variable containing opacity percentage</param>
        public TriggerAction SetOpacity(Variable opacityVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = opacityVariable.Name,
                TriggerId = 433
            };
        }

        /// <summary>
        /// Set line style of current graphic to thickness and hex-colour from variables
        /// </summary>
        /// <param name="thicknessVariable">Variable containing thickness</param>
        /// <param name="colorVariable">Variable containing hex-colour</param>
        public static TriggerAction SetLineStyle(Variable thicknessVariable, Variable colorVariable)
        {
            return new TriggerAction
            {
                ParameterA = thicknessVariable.Name,
                ParameterB = colorVariable.Name,
                TriggerId = 443
            };
        }

        /// <summary>
        /// Draw line on current graphic from top-left of one region to top-left of another region
        /// </summary>
        /// <param name="startRegion">Starting region</param>
        /// <param name="endRegion">Ending region</param>
        public static TriggerAction DrawLine(Region startRegion, Region endRegion)
        {
            return new TriggerAction
            {
                ParameterA = startRegion.Uid,
                ParameterB = endRegion.Uid,
                TriggerId = 382
            };
        }

        public override XElement CreateXmlElement()
        {
            var graphicsElement = new XElement("graphics");
            graphicsElement.SetAttributeValue("name", Name);
            graphicsElement.SetAttributeValue("layer", Layer.ToString());
            // TODO: Add more graphics-specific attributes based on XML structure requirements
            return graphicsElement;
        }
    }
}