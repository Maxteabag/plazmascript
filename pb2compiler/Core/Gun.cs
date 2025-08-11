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

        /// <summary>
        /// Force this gun to spawn specific number of projectiles per shot
        /// </summary>
        /// <param name="projectileCount">Number of projectiles per shot</param>
        public TriggerAction SetProjectilesPerShot(int projectileCount)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = projectileCount.ToString(),
                TriggerId = 62
            };
        }

        /// <summary>
        /// Change the accuracy of this gun to specific degrees
        /// </summary>
        /// <param name="degrees">Accuracy in degrees</param>
        public TriggerAction SetAccuracy(double degrees)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = degrees.ToString(),
                TriggerId = 63
            };
        }

        /// <summary>
        /// Convert this gun's projectiles into bullets
        /// </summary>
        public TriggerAction ConvertProjectilesToBullets()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 65
            };
        }

        /// <summary>
        /// Call trigger when this gun was fully reloaded while being held by some character
        /// </summary>
        /// <param name="triggerId">Trigger ID to call</param>
        public TriggerAction CallTriggerOnFullReload(int triggerId)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = triggerId.ToString(),
                TriggerId = 324
            };
        }

        /// <summary>
        /// Change cursor/crosshair of this gun
        /// </summary>
        /// <param name="cursorValue">Cursor value</param>
        public TriggerAction ChangeCursor(string cursorValue)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = cursorValue,
                TriggerId = 355
            };
        }

        /// <summary>
        /// Change this gun's upgrade level
        /// </summary>
        /// <param name="upgradeLevel">Upgrade level string or variable</param>
        public TriggerAction SetUpgradeLevel(string upgradeLevel)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = upgradeLevel,
                TriggerId = 377
            };
        }

        /// <summary>
        /// Change this gun's upgrade level using a variable
        /// </summary>
        /// <param name="upgradeLevelVariable">Variable containing upgrade level</param>
        public TriggerAction SetUpgradeLevel(Variable upgradeLevelVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = upgradeLevelVariable.Name,
                TriggerId = 377
            };
        }

        /// <summary>
        /// Change this gun's color
        /// </summary>
        /// <param name="color">Color value</param>
        public TriggerAction ChangeColor(string color)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = color,
                TriggerId = 378
            };
        }

        /// <summary>
        /// Change this gun's bullet life multiplier
        /// </summary>
        /// <param name="multiplierVariable">Variable containing bullet life multiplier</param>
        public TriggerAction SetBulletLifeMultiplier(Variable multiplierVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = multiplierVariable.Name,
                TriggerId = 444
            };
        }

        /// <summary>
        /// Set this gun's rotation
        /// </summary>
        /// <param name="rotationVariable">Variable containing rotation value</param>
        public TriggerAction SetRotation(Variable rotationVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = rotationVariable.Name,
                TriggerId = 469
            };
        }

        /// <summary>
        /// Set this gun's X scale
        /// </summary>
        /// <param name="scaleVariable">Variable containing X scale value</param>
        public TriggerAction SetXScale(Variable scaleVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = scaleVariable.Name,
                TriggerId = 470
            };
        }

        /// <summary>
        /// Set this gun's Y scale
        /// </summary>
        /// <param name="scaleVariable">Variable containing Y scale value</param>
        public TriggerAction SetYScale(Variable scaleVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = scaleVariable.Name,
                TriggerId = 473
            };
        }

        /// <summary>
        /// Change this gun's bullet speed multiplier
        /// </summary>
        /// <param name="multiplierVariable">Variable containing bullet speed multiplier</param>
        public TriggerAction SetBulletSpeedMultiplier(Variable multiplierVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = multiplierVariable.Name,
                TriggerId = 486
            };
        }

        /// <summary>
        /// Clone this gun at center of a region
        /// </summary>
        /// <param name="region">Region to spawn the cloned gun</param>
        public TriggerAction CloneAtRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 494
            };
        }

        /// <summary>
        /// Set gun color matrix to array (4 rows, 5 columns, first 4 columns multiplicative, last column additive)
        /// </summary>
        /// <param name="matrixArray">Array variable containing color matrix</param>
        public TriggerAction SetColorMatrix(Variable matrixArray)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = matrixArray.Name,
                TriggerId = 403
            };
        }

        /// <summary>
        /// Convert this gun's projectiles into rails
        /// </summary>
        public TriggerAction ConvertProjectilesToRails()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 66
            };
        }

        /// <summary>
        /// Convert this gun's projectiles into grenades
        /// </summary>
        public TriggerAction ConvertProjectilesToGrenades()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 67
            };
        }

        /// <summary>
        /// Convert this gun's projectiles into energy
        /// </summary>
        public TriggerAction ConvertProjectilesToEnergy()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 68
            };
        }

        /// <summary>
        /// Convert this gun's projectiles into rockets
        /// </summary>
        public TriggerAction ConvertProjectilesToRockets()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 69
            };
        }

        /// <summary>
        /// Set this gun's slot to a specific value
        /// </summary>
        /// <param name="slot">The slot number</param>
        public TriggerAction SetSlot(int slot)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = slot.ToString(),
                TriggerId = 78
            };
        }

        /// <summary>
        /// Call a trigger when this gun is fired
        /// </summary>
        /// <param name="trigger">The trigger to call when fired</param>
        public TriggerAction CallTriggerOnFire(Trigger trigger)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = trigger.Uid,
                TriggerId = 81
            };
        }

        /// <summary>
        /// Force this gun to spawn variable number of projectiles per shot
        /// </summary>
        /// <param name="projectileCountVariable">Variable containing number of projectiles per shot</param>
        public TriggerAction SetProjectilesPerShot(Variable projectileCountVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = projectileCountVariable.Name,
                TriggerId = 128
            };
        }

        /// <summary>
        /// Change the accuracy of this gun to variable degrees
        /// </summary>
        /// <param name="degreesVariable">Variable containing accuracy in degrees</param>
        public TriggerAction SetAccuracy(Variable degreesVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = degreesVariable.Name,
                TriggerId = 129
            };
        }

        /// <summary>
        /// Change this gun's projectile power to variable value
        /// </summary>
        /// <param name="powerVariable">Variable containing projectile power</param>
        public TriggerAction SetProjectilePower(Variable powerVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = powerVariable.Name,
                TriggerId = 130
            };
        }

        /// <summary>
        /// Change this gun's speed multiplier to a variable value
        /// </summary>
        /// <param name="speedVariable">Variable containing speed multiplier</param>
        public TriggerAction SetSpeedMultiplier(Variable speedVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = speedVariable.Name,
                TriggerId = 171
            };
        }

        /// <summary>
        /// Change this gun's recoil multiplier to a variable value
        /// </summary>
        /// <param name="recoilVariable">Variable containing recoil multiplier</param>
        public TriggerAction SetRecoilMultiplier(Variable recoilVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = recoilVariable.Name,
                TriggerId = 173
            };
        }

        /// <summary>
        /// Change this gun's projectile model to model with specified index
        /// </summary>
        /// <param name="modelIndex">The projectile model index</param>
        public TriggerAction SetProjectileModel(int modelIndex)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = modelIndex.ToString(),
                TriggerId = 175
            };
        }

        /// <summary>
        /// Change this gun's projectile model to model with index from variable
        /// </summary>
        /// <param name="modelIndexVariable">Variable containing projectile model index</param>
        public TriggerAction SetProjectileModel(Variable modelIndexVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = modelIndexVariable.Name,
                TriggerId = 176
            };
        }

        /// <summary>
        /// Change this gun's target knockback multiplier to specified value
        /// </summary>
        /// <param name="multiplier">Target knockback multiplier</param>
        public TriggerAction SetTargetKnockbackMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = multiplier.ToString(),
                TriggerId = 218
            };
        }

        /// <summary>
        /// Change this gun's target knockback multiplier to value of a variable
        /// </summary>
        /// <param name="multiplierVariable">Variable containing target knockback multiplier</param>
        public TriggerAction SetTargetKnockbackMultiplier(Variable multiplierVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = multiplierVariable.Name,
                TriggerId = 219
            };
        }

        /// <summary>
        /// Change this gun's max spread accuracy (in radians)
        /// </summary>
        /// <param name="maxSpread">Max spread accuracy in radians</param>
        public TriggerAction SetMaxSpreadAccuracy(double maxSpread)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = maxSpread.ToString(),
                TriggerId = 237
            };
        }

        /// <summary>
        /// Change this gun's added spread accuracy per shot (in radians)
        /// </summary>
        /// <param name="addedSpread">Added spread accuracy per shot in radians</param>
        public TriggerAction SetAddedSpreadAccuracy(double addedSpread)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = addedSpread.ToString(),
                TriggerId = 238
            };
        }

        /// <summary>
        /// Change this gun's subtracted spread accuracy over time (in radians)
        /// </summary>
        /// <param name="subtractedSpread">Subtracted spread accuracy over time in radians</param>
        public TriggerAction SetSubtractedSpreadAccuracy(double subtractedSpread)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = subtractedSpread.ToString(),
                TriggerId = 239
            };
        }
    }
}
