using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public enum AIBehavior
    {
        Default = 0,
        FollowThePlayer = 1,
        LookAround = 2,
        Investigate = 3,
        DoNothing = 4
    }

    public enum CharacterTeam
    {
        Alpha = 0,
        Beta = 1,
        Gamma = 2,
        Delta = 3,
        Zeta = 4,
        Lambda = 5,
        Sigma = 6,
        Omega = 7,
        CounterTerrorists = 8,
        Terrorists = 9,
        UsurpationForces = 10,
        CitizenSecurity = 11,
        RedTeam = 12,
        BlueTeam = 13,
        GreenTeam = 14,
        WhiteTeam = 15,
        BlackTeam = 16,
        SpecialA = -1,
        SpecialB = -2,
        SpecialC = -3,
        SpecialD = -4,
        SpecialE = -5,
        SpecialF = -6
    }

    public class Character : LinkedObject
    {
        public Character(string uid, int x, int y)
        {
            Uid = uid;
            X = x;
            Y = y;
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Set the character's hit points to a percentage (0-100)
        /// </summary>
        /// <param name="percentage">Hit points percentage</param>
        public TriggerAction SetHitPointsPercentage(int percentage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = percentage.ToString(),
                TriggerId = 4
            };
        }

        /// <summary>
        /// Move this character to a region (if alive)
        /// </summary>
        /// <param name="region">The target region</param>
        public TriggerAction MoveToRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 14
            };
        }

        /// <summary>
        /// Put this character into a vehicle
        /// </summary>
        /// <param name="vehicle">The vehicle to enter</param>
        public TriggerAction EnterVehicle(Vehicle vehicle)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = vehicle.Uid,
                TriggerId = 13
            };
        }

        /// <summary>
        /// Set current hit points of this character to a specific value
        /// </summary>
        /// <param name="hitPoints">Hit points value</param>
        public TriggerAction SetHitPoints(int hitPoints)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = hitPoints.ToString(),
                TriggerId = 23
            };
        }

        /// <summary>
        /// Clone this character and spawn it in the centre of a region
        /// </summary>
        /// <param name="region">The region to spawn the clone in</param>
        public TriggerAction CloneAndSpawn(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 28
            };
        }

        /// <summary>
        /// Force all enemies of this character who are located in a region to hunt for this character
        /// </summary>
        /// <param name="region">The region containing enemies</param>
        public TriggerAction ForceEnemiesInRegionHunt(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 29
            };
        }

        /// <summary>
        /// Set AI Behavior parameter of this computer-controlled character
        /// </summary>
        /// <param name="behavior">The AI behavior enum value</param>
        public TriggerAction SetAIBehavior(AIBehavior behavior)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = ((int)behavior).ToString(),
                TriggerId = 32
            };
        }

        /// <summary>
        /// Set AI Behavior parameter of this computer-controlled character
        /// </summary>
        /// <param name="behavior">The AI behavior value (0-4)</param>
        public TriggerAction SetAIBehavior(int behavior)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = behavior.ToString(),
                TriggerId = 32
            };
        }

        /// <summary>
        /// Change the team of this character
        /// </summary>
        /// <param name="team">The new team enum value</param>
        public TriggerAction ChangeTeam(CharacterTeam team)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = ((int)team).ToString(),
                TriggerId = 33
            };
        }

        /// <summary>
        /// Change the team of this character
        /// </summary>
        /// <param name="team">The new team value (-6 to 16)</param>
        public TriggerAction ChangeTeam(int team)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = team.ToString(),
                TriggerId = 33
            };
        }

        /// <summary>
        /// Multiply maximal and current hit points of this character by percentage
        /// </summary>
        /// <param name="percentage">Percentage multiplier</param>
        public TriggerAction MultiplyHitPoints(int percentage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = percentage.ToString(),
                TriggerId = 48
            };
        }

        /// <summary>
        /// Change the nickname of this character
        /// </summary>
        /// <param name="nickname">The new nickname</param>
        public TriggerAction ChangeNickname(string nickname)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = nickname,
                TriggerId = 52
            };
        }

        /// <summary>
        /// Clone this character and spawn it in a random place in a region
        /// </summary>
        /// <param name="region">The region to spawn the clone in</param>
        public TriggerAction CloneAndSpawnRandom(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 53
            };
        }

        /// <summary>
        /// Change the skin of this character
        /// </summary>
        /// <param name="skin">The new skin value</param>
        public TriggerAction ChangeSkin(string skin)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = skin,
                TriggerId = 58
            };
        }

        /// <summary>
        /// Set current and max hit points of this character to a specific value
        /// </summary>
        /// <param name="hitPoints">The hit points value</param>
        public TriggerAction SetMaxAndCurrentHitPoints(int hitPoints)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = hitPoints.ToString(),
                TriggerId = 59
            };
        }

        /// <summary>
        /// Force this character to drop all weapons
        /// </summary>
        public TriggerAction DropAllWeapons()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 60
            };
        }

        /// <summary>
        /// Multiply this character's speed by a specific value
        /// </summary>
        /// <param name="multiplier">The speed multiplier</param>
        public TriggerAction MultiplySpeed(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = multiplier.ToString(),
                TriggerId = 61
            };
        }

        /// <summary>
        /// Change this character's mobility factor
        /// </summary>
        /// <param name="mobilityFactor">The mobility factor value</param>
        public TriggerAction SetMobilityFactor(double mobilityFactor)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = mobilityFactor.ToString(),
                TriggerId = 88
            };
        }

        /// <summary>
        /// Change this character's armor type
        /// </summary>
        /// <param name="armorType">Armor type (0, 1 or 2)</param>
        public TriggerAction ChangeArmorType(int armorType)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = armorType.ToString(),
                TriggerId = 89
            };
        }

        /// <summary>
        /// Change the blood color of this character to a HEX color
        /// </summary>
        /// <param name="hexColor">HEX color value (e.g., "#FF0000")</param>
        public TriggerAction ChangeBloodColor(string hexColor)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = hexColor,
                TriggerId = 90
            };
        }

        /// <summary>
        /// Set horizontal movement on idle for this character
        /// </summary>
        /// <param name="movement">Movement value (0, -1 or 1)</param>
        public TriggerAction SetIdleHorizontalMovement(int movement)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = movement.ToString(),
                TriggerId = 91
            };
        }

        /// <summary>
        /// Set vertical movement on idle for this character
        /// </summary>
        /// <param name="movement">Movement value (0, -1 or 1)</param>
        public TriggerAction SetIdleVerticalMovement(int movement)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = movement.ToString(),
                TriggerId = 92
            };
        }

        /// <summary>
        /// Set shoot action on idle for this character
        /// </summary>
        /// <param name="shoot">Shoot value (0 or 1)</param>
        public TriggerAction SetIdleShootAction(int shoot)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = shoot.ToString(),
                TriggerId = 93
            };
        }

        /// <summary>
        /// Force this character to look at a random point in a region
        /// </summary>
        /// <param name="region">The region to look at</param>
        public TriggerAction LookAtRandomPointInRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 94
            };
        }

        /// <summary>
        /// Force this character to hunt another character
        /// </summary>
        /// <param name="target">The character to hunt</param>
        public TriggerAction HuntCharacter(Character target)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = target.Uid,
                TriggerId = 97
            };
        }

        /// <summary>
        /// Change head model of this character to specified model
        /// </summary>
        /// <param name="model">The head model identifier</param>
        public TriggerAction ChangeHeadModel(string model)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = model,
                TriggerId = 164
            };
        }

        /// <summary>
        /// Change body model of this character to specified model
        /// </summary>
        /// <param name="model">The body model identifier</param>
        public TriggerAction ChangeBodyModel(string model)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = model,
                TriggerId = 165
            };
        }

        /// <summary>
        /// Change arms model of this character to specified model
        /// </summary>
        /// <param name="model">The arms model identifier</param>
        public TriggerAction ChangeArmsModel(string model)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = model,
                TriggerId = 166
            };
        }

        /// <summary>
        /// Change legs model of this character to specified model
        /// </summary>
        /// <param name="model">The legs model identifier</param>
        public TriggerAction ChangeLegsModel(string model)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = model,
                TriggerId = 167
            };
        }

        /// <summary>
        /// Set character color pattern (4 small letters for each body section)
        /// </summary>
        /// <param name="colorPattern">Color pattern string (e.g., "rbyg", use '-' to disable color change for section)</param>
        public TriggerAction SetColorPattern(string colorPattern)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = colorPattern,
                TriggerId = 168
            };
        }

        /// <summary>
        /// Set this character's scale to specified value
        /// </summary>
        /// <param name="scale">Character scale value</param>
        public TriggerAction SetScale(double scale)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = scale.ToString(),
                TriggerId = 220
            };
        }

        /// <summary>
        /// Set this character's scale to value of a variable
        /// </summary>
        /// <param name="scaleVariable">Variable containing character scale</param>
        public TriggerAction SetScale(Variable scaleVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = scaleVariable.Name,
                TriggerId = 221
            };
        }

        /// <summary>
        /// Set this character's zoom to specified value
        /// </summary>
        /// <param name="zoom">Character zoom value</param>
        public TriggerAction SetZoom(double zoom)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = zoom.ToString(),
                TriggerId = 222
            };
        }

        /// <summary>
        /// Set this character's voice preset
        /// </summary>
        /// <param name="preset">Voice preset ID</param>
        public TriggerAction SetVoicePreset(int preset)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = preset.ToString(),
                TriggerId = 272
            };
        }

        /// <summary>
        /// Add ghost effect to this character
        /// </summary>
        public TriggerAction AddGhostEffect()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 273
            };
        }

        /// <summary>
        /// Remove ghost effect from this character
        /// </summary>
        public TriggerAction RemoveGhostEffect()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 274
            };
        }

        /// <summary>
        /// Make this character unhittable
        /// </summary>
        public TriggerAction MakeUnhittable()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 318
            };
        }

        /// <summary>
        /// Make this character hittable
        /// </summary>
        public TriggerAction MakeHittable()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 319
            };
        }

        /// <summary>
        /// Switch singleplayer control to this character
        /// </summary>
        /// <param name="playSound">Set to 1 if sound needs to be played</param>
        public TriggerAction SwitchSingleplayerControl(int playSound)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = playSound.ToString(),
                TriggerId = 320
            };
        }

        /// <summary>
        /// Disallow weapon drop for this character
        /// </summary>
        public TriggerAction DisallowWeaponDrop()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 321
            };
        }

        /// <summary>
        /// Allow weapon drop for this character
        /// </summary>
        public TriggerAction AllowWeaponDrop()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 322
            };
        }

        /// <summary>
        /// Set this character's active weapon to a specific gun
        /// </summary>
        /// <param name="gun">The gun to set as active weapon</param>
        public TriggerAction SetActiveWeapon(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = gun.Uid,
                TriggerId = 312
            };
        }

        /// <summary>
        /// Make this character drop weapon at current slot
        /// </summary>
        public TriggerAction DropWeaponAtCurrentSlot()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 313
            };
        }

        /// <summary>
        /// Enable or disable nametag visibility of this character
        /// </summary>
        /// <param name="visible">1 to enable, 0 to disable</param>
        public TriggerAction SetNametagVisibility(int visible)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = visible.ToString(),
                TriggerId = 346
            };
        }

        /// <summary>
        /// Set this character's stability to a specific value
        /// </summary>
        /// <param name="stability">Stability value</param>
        public TriggerAction SetStability(double stability)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = stability.ToString(),
                TriggerId = 374
            };
        }

        /// <summary>
        /// Set this character's stability to value of a variable
        /// </summary>
        /// <param name="stabilityVariable">Variable containing stability value</param>
        public TriggerAction SetStability(Variable stabilityVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = stabilityVariable.Name,
                TriggerId = 375
            };
        }

        /// <summary>
        /// Move this character to random place in a region
        /// </summary>
        /// <param name="region">Region to move to</param>
        public TriggerAction MoveToRandomPlaceInRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 371
            };
        }

        /// <summary>
        /// Make this character drop a specific gun
        /// </summary>
        /// <param name="gun">Gun to drop</param>
        public TriggerAction DropGun(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = gun.Uid,
                TriggerId = 411
            };
        }

        /// <summary>
        /// Set this character's health bar GUI opacity
        /// </summary>
        /// <param name="opacity">Opacity value</param>
        public TriggerAction SetHealthBarOpacity(double opacity)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = opacity.ToString(),
                TriggerId = 446
            };
        }

        /// <summary>
        /// Set this character's health bar GUI opacity using a variable
        /// </summary>
        /// <param name="opacityVariable">Variable containing opacity value</param>
        public TriggerAction SetHealthBarOpacity(Variable opacityVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = opacityVariable.Name,
                TriggerId = 447
            };
        }

        /// <summary>
        /// Change this character's sword life using a variable
        /// </summary>
        /// <param name="swordLifeVariable">Variable containing sword life value</param>
        public TriggerAction ChangeSwordLife(Variable swordLifeVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = swordLifeVariable.Name,
                TriggerId = 451
            };
        }

        /// <summary>
        /// Set disabling of psi swords for this character
        /// </summary>
        /// <param name="disabled">1 to disable, 0 to enable</param>
        public TriggerAction SetPsiSwordsDisabled(int disabled)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = disabled.ToString(),
                TriggerId = 458
            };
        }

        /// <summary>
        /// Set this character's current and max hit points using a variable
        /// </summary>
        /// <param name="hitPointsVariable">Variable containing hit points value</param>
        public TriggerAction SetCurrentAndMaxHitPoints(Variable hitPointsVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = hitPointsVariable.Name,
                TriggerId = 464
            };
        }

        /// <summary>
        /// Show text bubble above this character
        /// </summary>
        /// <param name="text">Text to show</param>
        public TriggerAction ShowTextBubble(string text)
        {
            return new TriggerAction
            {
                ParameterA = text,
                ParameterB = Uid,
                TriggerId = 482
            };
        }

        /// <summary>
        /// Set this character's active weapon slot
        /// </summary>
        /// <param name="slot">Weapon slot to activate</param>
        public TriggerAction SetActiveWeaponSlot(int slot)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = slot.ToString(),
                TriggerId = 485
            };
        }

        /// <summary>
        /// Set X speed of this character to value of a variable
        /// </summary>
        /// <param name="speedVariable">Variable containing X speed value</param>
        public TriggerAction SetXSpeed(Variable speedVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = speedVariable.Name,
                TriggerId = 429
            };
        }

        /// <summary>
        /// Set Y speed of this character to value of a variable
        /// </summary>
        /// <param name="speedVariable">Variable containing Y speed value</param>
        public TriggerAction SetYSpeed(Variable speedVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = speedVariable.Name,
                TriggerId = 430
            };
        }

        /// <summary>
        /// Set X speed of Character slot-value variable to value of variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="speedVariable">Variable containing X speed value</param>
        public static TriggerAction SetCharacterSlotXSpeed(Variable slotVariable, Variable speedVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = speedVariable.Name,
                TriggerId = 431
            };
        }

        /// <summary>
        /// Set Y speed of Character slot-value variable to value of variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="speedVariable">Variable containing Y speed value</param>
        public static TriggerAction SetCharacterSlotYSpeed(Variable slotVariable, Variable speedVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = speedVariable.Name,
                TriggerId = 432
            };
        }

        /// <summary>
        /// Set variable to 1 if this character is dying (variable becomes 0 in else case)
        /// </summary>
        /// <param name="resultVariable">Variable to store the result</param>
        public TriggerAction CheckIfDying(Variable resultVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = Uid,
                TriggerId = 314
            };
        }

        /// <summary>
        /// Set variable to 1 if Character-initiator is dying (variable becomes 0 in else case)
        /// </summary>
        /// <param name="resultVariable">Variable to store the result</param>
        public static TriggerAction CheckIfInitiatorDying(Variable resultVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = "-1",
                TriggerId = 315
            };
        }

        /// <summary>
        /// Set variable to 1 if Character-killer is dying (variable becomes 0 in else case)
        /// </summary>
        /// <param name="resultVariable">Variable to store the result</param>
        public static TriggerAction CheckIfKillerDying(Variable resultVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = "-1",
                TriggerId = 316
            };
        }

        /// <summary>
        /// Set variable to 1 if Character slot-value variable is dying
        /// </summary>
        /// <param name="resultVariable">Variable to store the result</param>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction CheckIfCharacterSlotDying(Variable resultVariable, Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = slotVariable.Name,
                TriggerId = 544
            };
        }

        /// <summary>
        /// Change Character slot-value variable nickname to variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="nicknameVariable">Variable containing new nickname</param>
        public static TriggerAction SetCharacterSlotNickname(Variable slotVariable, Variable nicknameVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = nicknameVariable.Name,
                TriggerId = 518
            };
        }

        /// <summary>
        /// Change Character nickname to variable value
        /// </summary>
        /// <param name="nicknameVariable">Variable containing new nickname</param>
        public TriggerAction SetNickname(Variable nicknameVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = nicknameVariable.Name,
                TriggerId = 455
            };
        }


        /// <summary>
        /// Change Character zoom multiplier
        /// </summary>
        /// <param name="zoomVariable">Variable containing zoom multiplier</param>
        public TriggerAction SetZoomMultiplier(Variable zoomVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = zoomVariable.Name,
                TriggerId = 368
            };
        }

        /// <summary>
        /// Set Character slot-value variable Health bar GUI opacity to value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="opacity">Opacity value</param>
        public static TriggerAction SetCharacterSlotHealthBarOpacity(Variable slotVariable, int opacity)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = opacity.ToString(),
                TriggerId = 448
            };
        }

        /// <summary>
        /// Set Character slot-value variable Health bar GUI opacity to variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="opacityVariable">Variable containing opacity value</param>
        public static TriggerAction SetCharacterSlotHealthBarOpacity(Variable slotVariable, Variable opacityVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = opacityVariable.Name,
                TriggerId = 449
            };
        }

        /// <summary>
        /// Change Character slot-value variable sword life to variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="swordLifeVariable">Variable containing sword life value</param>
        public static TriggerAction SetCharacterSlotSwordLife(Variable slotVariable, Variable swordLifeVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = swordLifeVariable.Name,
                TriggerId = 452
            };
        }

        /// <summary>
        /// Set disabling of Character slot-value variable psi swords to parameter
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="disable">1 to disable, 0 to enable</param>
        public static TriggerAction SetCharacterSlotPsiSwordsDisabled(Variable slotVariable, int disable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = disable.ToString(),
                TriggerId = 459
            };
        }

        /// <summary>
        /// Set Character slot-value variable current and max hit points to variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="hitPointsVariable">Variable containing hit points value</param>
        public static TriggerAction SetCharacterSlotHitPoints(Variable slotVariable, Variable hitPointsVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = hitPointsVariable.Name,
                TriggerId = 465
            };
        }

        /// <summary>
        /// Set Character slot-value variable current and max hit points to value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="hitPoints">Hit points value</param>
        public static TriggerAction SetCharacterSlotHitPoints(Variable slotVariable, int hitPoints)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = hitPoints.ToString(),
                TriggerId = 498
            };
        }

        /// <summary>
        /// Save shoot intention of Character slot-value variable to variable
        /// </summary>
        /// <param name="resultVariable">Variable to store shoot intention</param>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction SaveCharacterSlotShootIntention(Variable resultVariable, Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = slotVariable.Name,
                TriggerId = 495
            };
        }

        /// <summary>
        /// Save horizontal movement intention of Character slot-value variable to variable
        /// </summary>
        /// <param name="resultVariable">Variable to store horizontal movement intention</param>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction SaveCharacterSlotHorizontalMovement(Variable resultVariable, Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = slotVariable.Name,
                TriggerId = 496
            };
        }

        /// <summary>
        /// Save vertical movement intention of Character slot-value variable to variable
        /// </summary>
        /// <param name="resultVariable">Variable to store vertical movement intention</param>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction SaveCharacterSlotVerticalMovement(Variable resultVariable, Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = slotVariable.Name,
                TriggerId = 497
            };
        }

        /// <summary>
        /// Disallow weapon drop for Character slot-value variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction DisallowCharacterSlotWeaponDrop(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 547
            };
        }

        /// <summary>
        /// Allow weapon drop for Character slot-value variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction AllowCharacterSlotWeaponDrop(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 548
            };
        }

        /// <summary>
        /// Set disabling of Character slot-value variable psi swords to parameter
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="disable">1 to disable, 0 to enable</param>
        public static TriggerAction SetCharacterSlotPsiSwordsDisabled(Variable slotVariable, string disable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = disable,
                TriggerId = 549
            };
        }

        /// <summary>
        /// Set Character slot-value variable active weapon to slot
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="weaponSlot">Weapon slot number</param>
        public static TriggerAction SetCharacterSlotActiveWeaponSlot(Variable slotVariable, int weaponSlot)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = weaponSlot.ToString(),
                TriggerId = 551
            };
        }

        /// <summary>
        /// Set variable to active weapon of Character slot-value variable
        /// </summary>
        /// <param name="resultVariable">Variable to store active weapon</param>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction GetCharacterSlotActiveWeapon(Variable resultVariable, Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = slotVariable.Name,
                TriggerId = 552
            };
        }

        /// <summary>
        /// Make Character slot-value variable drop Gun
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="gun">Gun to drop</param>
        public static TriggerAction MakeCharacterSlotDropGun(Variable slotVariable, Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = gun.Uid,
                TriggerId = 553
            };
        }

        /// <summary>
        /// Change Character slot-value variable sword life to variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="swordLifeVariable">Variable containing sword life value</param>
        public static TriggerAction ChangeCharacterSlotSwordLife(Variable slotVariable, Variable swordLifeVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = swordLifeVariable.Name,
                TriggerId = 554
            };
        }

        /// <summary>
        /// Move Character slot-value variable to random place in Region
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Target region</param>
        public static TriggerAction MoveCharacterSlotToRandomPlace(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 556
            };
        }

        /// <summary>
        /// Teleport Character slot-value variable to Region and invert speed by X axis
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Target region</param>
        public static TriggerAction TeleportCharacterSlotWithSpeedInvert(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 557
            };
        }

        /// <summary>
        /// Teleport Character slot-value variable to Region
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Target region</param>
        public static TriggerAction TeleportCharacterSlot(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 558
            };
        }

        /// <summary>
        /// Silently teleport Character slot-value variable to Region
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Target region</param>
        public static TriggerAction SilentlyTeleportCharacterSlot(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 559
            };
        }

        /// <summary>
        /// Apply damage-over-time effect to player-initiator with power and duration
        /// </summary>
        /// <param name="power">Damage power</param>
        /// <param name="duration">Duration (30 duration = 1 second)</param>
        public static TriggerAction ApplyDamageOverTimeToInitiator(int power, int duration)
        {
            return new TriggerAction
            {
                ParameterA = power.ToString(),
                ParameterB = duration.ToString(),
                TriggerId = 281
            };
        }

        /// <summary>
        /// Remove all effects from player-initiator
        /// </summary>
        public static TriggerAction RemoveAllEffectsFromInitiator()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 282
            };
        }

        /// <summary>
        /// Spawn damage particles of this Character at the center of Region
        /// </summary>
        /// <param name="region">Region to spawn particles at</param>
        public TriggerAction SpawnDamageParticles(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 283
            };
        }

        /// <summary>
        /// Change this Character nametag text to variable
        /// </summary>
        /// <param name="nametagVariable">Variable containing nametag text</param>
        public TriggerAction SetNametagText(Variable nametagVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = nametagVariable.Name,
                TriggerId = 456
            };
        }

        /// <summary>
        /// Set Character color pattern to string-value of variable (4 small letters for each limb)
        /// </summary>
        /// <param name="colorPatternVariable">Variable containing color pattern</param>
        public TriggerAction SetColorPattern(Variable colorPatternVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = colorPatternVariable.Name,
                TriggerId = 290
            };
        }

        public override XElement CreateXmlElement()
        {
            var characterElement = new XElement("character");
            characterElement.SetAttributeValue("uid", Uid);
            characterElement.SetAttributeValue("x", X.ToString());
            characterElement.SetAttributeValue("y", Y.ToString());
            return characterElement;
        }
    }
}