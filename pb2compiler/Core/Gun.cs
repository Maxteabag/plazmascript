using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public class Gun : LinkedObject
    {
        public enum GunModel
        {
            InvisibleGun
        }
        public enum GunTeam
        {
            Any
        }

        public GunModel Model { get; set; }
        public GunTeam Team { get; set; } = GunTeam.Any;
        public int UpgradeLevel { get; set; } = 0;

        public Gun(GunModel model)
        {
            this.Model = model;
            Uid = RandomGenerator.RandomString(10);
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var element = new XElement("gun");

            //TODO: More guns?
            var gunModelDictionary = new Dictionary<GunModel, string> {
                { GunModel.InvisibleGun, "gun_invisgun" },
            };

            //TODO: More teams?
            var gunTeamDictionary = new Dictionary<GunTeam, string> {
                { GunTeam.Any, "-1" },
            };

            var gunModel = gunModelDictionary[Model];
            var gunTeam = gunTeamDictionary[Team];

            element.SetAttributeValue("uid", Uid);
            element.SetAttributeValue("x", X.ToString());
            element.SetAttributeValue("y", Y.ToString());
            element.SetAttributeValue("command", gunTeam);
            element.SetAttributeValue("model", gunModel);
            element.SetAttributeValue("upg", UpgradeLevel.ToString());

            return element;

        }

        public TriggerAction MoveToRegion(string region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region,
                TriggerId = 123
            };
        }

        /// <summary>
        /// Move this gun to a region
        /// </summary>
        /// <param name="region">The target region</param>
        public TriggerAction MoveToRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 15
            };
        }

        internal TriggerAction AllowForVehicles()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 77
            };
        }
        internal TriggerAction AllowForCharacters()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 76
            };
        }

        internal TriggerAction SetSpeedMultiplier(int speed)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = speed.ToString(),
                TriggerId = 170
            };
        }

        internal TriggerAction SetProjectilePower(int value)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = value.ToString(),
                TriggerId = 64
            };
        }
        internal TriggerAction SetRecoilMultiplier(int value)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = value.ToString(),
                TriggerId = 172
            };
        }

        internal TriggerAction SetSlot(int value)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = value.ToString(),
                TriggerId = 78
            };
        }
    }
}
