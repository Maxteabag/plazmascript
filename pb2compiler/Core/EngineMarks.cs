using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PlazmaScript.Core
{
    /// <summary>
    /// Engine marks (inf elements) for configuring map behavior and settings
    /// </summary>
    public static class EngineMarks
    {
        /// <summary>
        /// Change sky appearance
        /// </summary>
        public static InfMark ChangeSky()
        {
            return new InfMark("sky", "1");
        }

        /// <summary>
        /// Set shadowmap size
        /// </summary>
        public static InfMark ShadowmapSize()
        {
            return new InfMark("shadowmap_size", "0");
        }

        /// <summary>
        /// Enable casual mode
        /// </summary>
        public static InfMark EnableCasualMode()
        {
            return new InfMark("casual", "0");
        }

        /// <summary>
        /// Disable base noise
        /// </summary>
        public static InfMark DisableBaseNoise()
        {
            return new InfMark("nobase", "0");
        }

        /// <summary>
        /// Alternative gameplay mode
        /// </summary>
        public static InfMark AlternativeGameplay()
        {
            return new InfMark("game2", "0");
        }

        /// <summary>
        /// Enable strict casual mode
        /// </summary>
        public static InfMark StrictCasualMode()
        {
            return new InfMark("strict_casual", "0");
        }

        /// <summary>
        /// Disable AI auto revive
        /// </summary>
        public static InfMark DisableAutoRevive()
        {
            return new InfMark("no_auto_revive", "0");
        }

        /// <summary>
        /// Force ragdoll disappearance
        /// </summary>
        public static InfMark ForceRagdollDisappearance()
        {
            return new InfMark("meat", "0");
        }

        /// <summary>
        /// Spawn marine weapons
        /// </summary>
        public static InfMark SpawnMarineWeapons()
        {
            return new InfMark("hero1_guns", "0");
        }

        /// <summary>
        /// Spawn Proxy weapons
        /// </summary>
        public static InfMark SpawnProxyWeapons()
        {
            return new InfMark("hero2_guns", "0");
        }

        /// <summary>
        /// Spawn Proxy weapons without grenades
        /// </summary>
        public static InfMark SpawnProxyWeaponsNoNades()
        {
            return new InfMark("hero2_guns_nonades", "0");
        }

        /// <summary>
        /// Spawn Proxy weapons (only grenades)
        /// </summary>
        public static InfMark SpawnProxyWeaponsOnlyNades()
        {
            return new InfMark("hero2_guns_nades", "0");
        }

        /// <summary>
        /// Disable psi-swords
        /// </summary>
        public static InfMark DisablePsiSwords()
        {
            return new InfMark("nopsi", "0");
        }

        /// <summary>
        /// Change game scale percentage
        /// </summary>
        public static InfMark GameScale(int percentage)
        {
            return new InfMark("gamescale", percentage.ToString());
        }

        /// <summary>
        /// Set starting HE grenades count (multiplayer only)
        /// </summary>
        public static InfMark HEGrenadesCount(int count)
        {
            return new InfMark("he_nades_count", count.ToString());
        }

        /// <summary>
        /// Set starting Portal grenades count (multiplayer only)
        /// </summary>
        public static InfMark PortalGrenadesCount(int count)
        {
            return new InfMark("port_nades_count", count.ToString());
        }

        /// <summary>
        /// Set starting Shield grenades count (multiplayer only)
        /// </summary>
        public static InfMark ShieldGrenadesCount(int count)
        {
            return new InfMark("sh_nades_count", count.ToString());
        }

        /// <summary>
        /// Enable snow effects on map
        /// </summary>
        public static InfMark EnableSnow()
        {
            return new InfMark("snow", "0");
        }

        /// <summary>
        /// Set custom water color (hex color code)
        /// </summary>
        public static InfMark WaterColor(string hexColor)
        {
            return new InfMark("watercolor", hexColor);
        }

        /// <summary>
        /// Set custom acid color (hex color code)
        /// </summary>
        public static InfMark AcidColor(string hexColor)
        {
            return new InfMark("acidcolor", hexColor);
        }

        /// <summary>
        /// Set custom water title
        /// </summary>
        public static InfMark WaterTitle()
        {
            return new InfMark("watertitle", "0");
        }

        /// <summary>
        /// Set custom acid title
        /// </summary>
        public static InfMark AcidTitle()
        {
            return new InfMark("acidtitle", "0");
        }

        /// <summary>
        /// Enable level trigger error reporting
        /// </summary>
        public static InfMark LevelErrors()
        {
            return new InfMark("level_errors", "0");
        }

        /// <summary>
        /// Enable variable sync trigger actions
        /// </summary>
        public static InfMark VariableSync()
        {
            return new InfMark("var_sync", "0");
        }
    }

    /// <summary>
    /// Represents an individual engine mark (inf element)
    /// </summary>
    public class InfMark : MapObject
    {
        public string Mark { get; set; }
        public string ForTeam { get; set; }

        public InfMark(string mark, string forTeam)
        {
            Mark = mark;
            ForTeam = forTeam;
            X = 0;
            Y = 0;
            PB2Map.MapObjects.Add(this);
        }

        public InfMark(string mark, string forTeam, int x, int y)
        {
            Mark = mark;
            ForTeam = forTeam;
            X = x;
            Y = y;
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var infElement = new XElement("inf");
            infElement.SetAttributeValue("x", X.ToString());
            infElement.SetAttributeValue("y", Y.ToString());
            infElement.SetAttributeValue("mark", Mark);
            infElement.SetAttributeValue("forteam", ForTeam);
            return infElement;
        }
    }
}