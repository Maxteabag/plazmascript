using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public static class PB2Map
    {
        public static List<MapObject> MapObjects { get; set; } = new List<MapObject>();
        
        static PB2Map()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize or reset the map system
        /// </summary>
        public static void Initialize()
        {
            // Clear any existing objects (in case of multiple runs)
            MapObjects.Clear();
        }

        /// <summary>
        /// Create a trigger action to set map gravity
        /// </summary>
        /// <param name="gravity">Gravity value (default is 0.5)</param>
        public static TriggerAction SetGravity(double gravity)
        {
            return new TriggerAction
            {
                ParameterA = gravity.ToString(),
                ParameterB = "-1",
                TriggerId = 5
            };
        }

        /// <summary>
        /// Create a trigger action to end the mission with a specific reason
        /// </summary>
        /// <param name="reason">The reason for ending the mission</param>
        public static TriggerAction EndMission(string reason)
        {
            return new TriggerAction
            {
                ParameterA = reason,
                ParameterB = "-1",
                TriggerId = 9
            };
        }

        /// <summary>
        /// Set game speed to a specific frames per second value
        /// </summary>
        /// <param name="framesPerSecond">Frames per second (default is 30)</param>
        public static TriggerAction SetGameSpeed(int framesPerSecond)
        {
            return new TriggerAction
            {
                ParameterA = framesPerSecond.ToString(),
                ParameterB = "-1",
                TriggerId = 39
            };
        }

        /// <summary>
        /// Change Strict Casual Mode status
        /// </summary>
        /// <param name="enabled">Enable or disable strict casual mode</param>
        public static TriggerAction SetStrictCasualMode(bool enabled)
        {
            return new TriggerAction
            {
                ParameterA = enabled ? "1" : "0",
                ParameterB = "-1",
                TriggerId = 40
            };
        }

        /// <summary>
        /// Play sound from library
        /// </summary>
        /// <param name="soundName">The name of the sound to play</param>
        public static TriggerAction PlaySound(string soundName)
        {
            return new TriggerAction
            {
                ParameterA = soundName,
                ParameterB = "-1",
                TriggerId = 41
            };
        }

        /// <summary>
        /// Allow or disallow usage of defibrillators by allies
        /// </summary>
        /// <param name="allowed">True to allow, false to disallow</param>
        public static TriggerAction SetDefibrillatorUsage(bool allowed)
        {
            return new TriggerAction
            {
                ParameterA = allowed ? "1" : "0",
                ParameterB = "-1",
                TriggerId = 45
            };
        }

        /// <summary>
        /// Set disabling of psi swords
        /// </summary>
        /// <param name="disabled">True to disable, false to enable</param>
        public static TriggerAction SetPsiSwordsDisabled(bool disabled)
        {
            return new TriggerAction
            {
                ParameterA = disabled ? "1" : "0",
                ParameterB = "-1",
                TriggerId = 49
            };
        }

        /// <summary>
        /// Mission complete and switch to level with specific ID
        /// </summary>
        /// <param name="levelId">The level ID to switch to</param>
        public static TriggerAction CompleteMissionAndSwitchLevel(string levelId)
        {
            return new TriggerAction
            {
                ParameterA = levelId,
                ParameterB = "-1",
                TriggerId = 50
            };
        }

        /// <summary>
        /// Zoom game camera to specific percentage
        /// </summary>
        /// <param name="percentage">Zoom percentage</param>
        public static TriggerAction ZoomCamera(int percentage)
        {
            return new TriggerAction
            {
                ParameterA = percentage.ToString(),
                ParameterB = "-1",
                TriggerId = 51
            };
        }

        /// <summary>
        /// Change bullet speed to a specific value (default is 60)
        /// </summary>
        /// <param name="speed">Bullet speed value</param>
        public static TriggerAction SetBulletSpeed(double speed)
        {
            return new TriggerAction
            {
                ParameterA = speed.ToString(),
                ParameterB = "-1",
                TriggerId = 73
            };
        }

        /// <summary>
        /// Change bullet penetration factor to a specific value (default is 1)
        /// </summary>
        /// <param name="penetration">Bullet penetration factor</param>
        public static TriggerAction SetBulletPenetration(double penetration)
        {
            return new TriggerAction
            {
                ParameterA = penetration.ToString(),
                ParameterB = "-1",
                TriggerId = 74
            };
        }

        /// <summary>
        /// Change max bullet life value (default is 30)
        /// </summary>
        /// <param name="maxLife">Max bullet life value</param>
        public static TriggerAction SetMaxBulletLife(int maxLife)
        {
            return new TriggerAction
            {
                ParameterA = maxLife.ToString(),
                ParameterB = "-1",
                TriggerId = 75
            };
        }

        /// <summary>
        /// Clear all session variables
        /// </summary>
        public static TriggerAction ClearAllSessionVariables()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 161
            };
        }

        /// <summary>
        /// Set global AI difficulty (easy = 1, normal = 2, hard = 3)
        /// </summary>
        /// <param name="difficulty">AI difficulty level (1-3)</param>
        public static TriggerAction SetGlobalAIDifficulty(int difficulty)
        {
            return new TriggerAction
            {
                ParameterA = difficulty.ToString(),
                ParameterB = "-1",
                TriggerId = 174
            };
        }

        /// <summary>
        /// Enable multiplayer frag/death messages
        /// </summary>
        public static TriggerAction EnableFragDeathMessages()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 190
            };
        }

        /// <summary>
        /// Disable multiplayer frag/death messages
        /// </summary>
        public static TriggerAction DisableFragDeathMessages()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 191
            };
        }

        /// <summary>
        /// Change sky image
        /// </summary>
        /// <param name="imagePath">Path to sky image</param>
        public static TriggerAction ChangeSkyImage(string imagePath)
        {
            return new TriggerAction
            {
                ParameterA = imagePath,
                ParameterB = "-1",
                TriggerId = 192
            };
        }

        /// <summary>
        /// Change sky color HEX multiplier
        /// </summary>
        /// <param name="hexColor">HEX color multiplier</param>
        public static TriggerAction ChangeSkyColorHex(string hexColor)
        {
            return new TriggerAction
            {
                ParameterA = hexColor,
                ParameterB = "-1",
                TriggerId = 193
            };
        }

        /// <summary>
        /// Set respawn speed multiplier (defaults to 1, but 1.5 in ranked)
        /// </summary>
        /// <param name="multiplier">Respawn speed multiplier</param>
        public static TriggerAction SetRespawnSpeedMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 194
            };
        }

        /// <summary>
        /// Change sky color Red multiplier to value of a variable
        /// </summary>
        /// <param name="redVariable">Variable containing red multiplier</param>
        public static TriggerAction ChangeSkyColorRed(Variable redVariable)
        {
            return new TriggerAction
            {
                ParameterA = redVariable.Name,
                ParameterB = "-1",
                TriggerId = 195
            };
        }

        /// <summary>
        /// Change sky color Green multiplier to value of a variable
        /// </summary>
        /// <param name="greenVariable">Variable containing green multiplier</param>
        public static TriggerAction ChangeSkyColorGreen(Variable greenVariable)
        {
            return new TriggerAction
            {
                ParameterA = greenVariable.Name,
                ParameterB = "-1",
                TriggerId = 196
            };
        }

        /// <summary>
        /// Change sky color Blue multiplier to value of a variable
        /// </summary>
        /// <param name="blueVariable">Variable containing blue multiplier</param>
        public static TriggerAction ChangeSkyColorBlue(Variable blueVariable)
        {
            return new TriggerAction
            {
                ParameterA = blueVariable.Name,
                ParameterB = "-1",
                TriggerId = 197
            };
        }

        /// <summary>
        /// Enable anonymous mode (disable player overheads, chat messages not shown)
        /// </summary>
        public static TriggerAction EnableAnonymousMode()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 207
            };
        }

        /// <summary>
        /// Disable anonymous mode (enable player overheads, chat messages shown)
        /// </summary>
        public static TriggerAction DisableAnonymousMode()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 208
            };
        }

        /// <summary>
        /// Set regeneration speed multiplier to specified value (defaults to 1)
        /// </summary>
        /// <param name="multiplier">Regeneration speed multiplier</param>
        public static TriggerAction SetRegenerationSpeedMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 209
            };
        }

        /// <summary>
        /// Set regeneration speed multiplier to value of a variable
        /// </summary>
        /// <param name="multiplierVariable">Variable containing regeneration speed multiplier</param>
        public static TriggerAction SetRegenerationSpeedMultiplier(Variable multiplierVariable)
        {
            return new TriggerAction
            {
                ParameterA = multiplierVariable.Name,
                ParameterB = "-1",
                TriggerId = 210
            };
        }

        /// <summary>
        /// Set regeneration delay multiplier to specified value (defaults to 1, but 2 in ranked)
        /// </summary>
        /// <param name="multiplier">Regeneration delay multiplier</param>
        public static TriggerAction SetRegenerationDelayMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 211
            };
        }

        /// <summary>
        /// Set regeneration delay multiplier to value of a variable
        /// </summary>
        /// <param name="multiplierVariable">Variable containing regeneration delay multiplier</param>
        public static TriggerAction SetRegenerationDelayMultiplier(Variable multiplierVariable)
        {
            return new TriggerAction
            {
                ParameterA = multiplierVariable.Name,
                ParameterB = "-1",
                TriggerId = 212
            };
        }

        /// <summary>
        /// Set physical player impact damage multiplier (default is 1)
        /// </summary>
        /// <param name="multiplier">Impact damage multiplier</param>
        public static TriggerAction SetPhysicalImpactDamageMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 213
            };
        }

        /// <summary>
        /// Set physical player impact damage threshold (default 0.9 for approved maps, 1 otherwise)
        /// </summary>
        /// <param name="threshold">Impact damage threshold</param>
        public static TriggerAction SetPhysicalImpactDamageThreshold(double threshold)
        {
            return new TriggerAction
            {
                ParameterA = threshold.ToString(),
                ParameterB = "-1",
                TriggerId = 214
            };
        }

        /// <summary>
        /// Set self-boost force multiplier (default is 1)
        /// </summary>
        /// <param name="multiplier">Self-boost force multiplier</param>
        public static TriggerAction SetSelfBoostForceMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 215
            };
        }

        /// <summary>
        /// Set unstable self-boost force multiplier for HIGH physics setting (default 2.8 for approved maps)
        /// </summary>
        /// <param name="multiplier">Unstable self-boost force multiplier for high physics</param>
        public static TriggerAction SetUnstableSelfBoostForceHighPhysics(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 216
            };
        }

        /// <summary>
        /// Set unstable self-boost force multiplier for LOW physics setting (default is 1)
        /// </summary>
        /// <param name="multiplier">Unstable self-boost force multiplier for low physics</param>
        public static TriggerAction SetUnstableSelfBoostForceLowPhysics(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 217
            };
        }

        /// <summary>
        /// Play song
        /// </summary>
        /// <param name="songName">Name of the song to play</param>
        public static TriggerAction PlaySong(string songName)
        {
            return new TriggerAction
            {
                ParameterA = songName,
                ParameterB = "-1",
                TriggerId = 229
            };
        }

        /// <summary>
        /// Set text placeholder decoration text
        /// </summary>
        /// <param name="text">Decoration text</param>
        public static TriggerAction SetDecorationText(string text)
        {
            return new TriggerAction
            {
                ParameterA = text,
                ParameterB = "-1",
                TriggerId = 231
            };
        }

        /// <summary>
        /// Set decoration HEX color multiplier
        /// </summary>
        /// <param name="hexColor">HEX color multiplier</param>
        public static TriggerAction SetDecorationHexColor(string hexColor)
        {
            return new TriggerAction
            {
                ParameterA = hexColor,
                ParameterB = "-1",
                TriggerId = 232
            };
        }

        /// <summary>
        /// Set decoration scale to specified value
        /// </summary>
        /// <param name="scale">Decoration scale</param>
        public static TriggerAction SetDecorationScale(double scale)
        {
            return new TriggerAction
            {
                ParameterA = scale.ToString(),
                ParameterB = "-1",
                TriggerId = 233
            };
        }

        /// <summary>
        /// Set decoration scale to value of a variable
        /// </summary>
        /// <param name="scaleVariable">Variable containing decoration scale</param>
        public static TriggerAction SetDecorationScale(Variable scaleVariable)
        {
            return new TriggerAction
            {
                ParameterA = scaleVariable.Name,
                ParameterB = "-1",
                TriggerId = 234
            };
        }

        /// <summary>
        /// Set rocket projectiles' speed multiplier
        /// </summary>
        /// <param name="multiplier">Rocket speed multiplier</param>
        public static TriggerAction SetRocketSpeedMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 240
            };
        }

        /// <summary>
        /// Set grenade projectiles' speed multiplier
        /// </summary>
        /// <param name="multiplier">Grenade speed multiplier</param>
        public static TriggerAction SetGrenadeSpeedMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 241
            };
        }

        /// <summary>
        /// Set plasma projectiles' speed multiplier
        /// </summary>
        /// <param name="multiplier">Plasma speed multiplier</param>
        public static TriggerAction SetPlasmaSpeedMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 242
            };
        }

        /// <summary>
        /// Create Map Preview from a region (only owner can execute this)
        /// </summary>
        /// <param name="region">Region to create preview from</param>
        public static TriggerAction CreateMapPreview(Region region)
        {
            return new TriggerAction
            {
                ParameterA = region.Uid,
                ParameterB = "-1",
                TriggerId = 243
            };
        }

        /// <summary>
        /// Lock camera at region with intensity multiplier
        /// </summary>
        /// <param name="region">Region to lock camera to (800x400 for 100% zoom)</param>
        /// <param name="intensity">Intensity multiplier (0..1)</param>
        public static TriggerAction LockCamera(Region region, double intensity)
        {
            return new TriggerAction
            {
                ParameterA = region.Uid,
                ParameterB = intensity.ToString(),
                TriggerId = 245
            };
        }

        /// <summary>
        /// Unlock camera from any region
        /// </summary>
        public static TriggerAction UnlockCamera()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 246
            };
        }

        /// <summary>
        /// Enable kinetic module
        /// </summary>
        public static TriggerAction EnableKineticModule()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 250
            };
        }

        /// <summary>
        /// Disable kinetic module
        /// </summary>
        public static TriggerAction DisableKineticModule()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 251
            };
        }

        /// <summary>
        /// Rotate decoration to angle-value (in degrees)
        /// </summary>
        /// <param name="angle">Angle in degrees</param>
        public static TriggerAction RotateDecorationDegrees(double angle)
        {
            return new TriggerAction
            {
                ParameterA = angle.ToString(),
                ParameterB = "-1",
                TriggerId = 253
            };
        }

        /// <summary>
        /// Rotate decoration to angle-value from variable (in degrees)
        /// </summary>
        /// <param name="angleVariable">Variable containing angle in degrees</param>
        public static TriggerAction RotateDecorationDegrees(Variable angleVariable)
        {
            return new TriggerAction
            {
                ParameterA = angleVariable.Name,
                ParameterB = "-1",
                TriggerId = 252
            };
        }

        /// <summary>
        /// Rotate decoration to angle-value (in radians)
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        public static TriggerAction RotateDecorationRadians(double angle)
        {
            return new TriggerAction
            {
                ParameterA = angle.ToString(),
                ParameterB = "-1",
                TriggerId = 258
            };
        }

        /// <summary>
        /// Rotate decoration to angle-value from variable (in radians)
        /// </summary>
        /// <param name="angleVariable">Variable containing angle in radians</param>
        public static TriggerAction RotateDecorationRadians(Variable angleVariable)
        {
            return new TriggerAction
            {
                ParameterA = angleVariable.Name,
                ParameterB = "-1",
                TriggerId = 257
            };
        }

        /// <summary>
        /// Attempt healing of player-initiator. Stop execution if at max HP or dead.
        /// </summary>
        /// <param name="healAmount">Amount to heal</param>
        public static TriggerAction AttemptHealPlayerInitiator(int healAmount)
        {
            return new TriggerAction
            {
                ParameterA = healAmount.ToString(),
                ParameterB = "-1",
                TriggerId = 254
            };
        }

        /// <summary>
        /// Allow Time Warp
        /// </summary>
        public static TriggerAction AllowTimeWarp()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 261
            };
        }

        /// <summary>
        /// Disallow Time Warp
        /// </summary>
        public static TriggerAction DisallowTimeWarp()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 262
            };
        }

        /// <summary>
        /// Set decoration X scale to specified value
        /// </summary>
        /// <param name="scale">X scale value</param>
        public static TriggerAction SetDecorationXScale(double scale)
        {
            return new TriggerAction
            {
                ParameterA = scale.ToString(),
                ParameterB = "-1",
                TriggerId = 267
            };
        }

        /// <summary>
        /// Set decoration Y scale to specified value
        /// </summary>
        /// <param name="scale">Y scale value</param>
        public static TriggerAction SetDecorationYScale(double scale)
        {
            return new TriggerAction
            {
                ParameterA = scale.ToString(),
                ParameterB = "-1",
                TriggerId = 268
            };
        }

        /// <summary>
        /// Restart map (singleplayer)
        /// </summary>
        public static TriggerAction RestartMap()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 307
            };
        }

        /// <summary>
        /// Reset game termination logic
        /// </summary>
        public static TriggerAction ResetGameTerminationLogic()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 308
            };
        }

        /// <summary>
        /// Make all players leave map or multiplayer match
        /// </summary>
        public static TriggerAction MakeAllPlayersLeave()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 309
            };
        }

        /// <summary>
        /// Make player-initiator leave map or multiplayer match
        /// </summary>
        public static TriggerAction MakePlayerInitiatorLeave()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 310
            };
        }

        /// <summary>
        /// Make player-killer leave map or multiplayer match
        /// </summary>
        public static TriggerAction MakePlayerKillerLeave()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 311
            };
        }

        /// <summary>
        /// Set interface visibility multiplier and cursor visibility multiplier using variables
        /// </summary>
        /// <param name="interfaceVariable">Variable containing interface visibility multiplier</param>
        /// <param name="cursorVariable">Variable containing cursor visibility multiplier</param>
        public static TriggerAction SetInterfaceAndCursorVisibility(Variable interfaceVariable, Variable cursorVariable)
        {
            return new TriggerAction
            {
                ParameterA = interfaceVariable.Name,
                ParameterB = cursorVariable.Name,
                TriggerId = 329
            };
        }

        /// <summary>
        /// Set interface visibility multiplier and cursor visibility multiplier using values
        /// </summary>
        /// <param name="interfaceMultiplier">Interface visibility multiplier</param>
        /// <param name="cursorMultiplier">Cursor visibility multiplier</param>
        public static TriggerAction SetInterfaceAndCursorVisibility(double interfaceMultiplier, double cursorMultiplier)
        {
            return new TriggerAction
            {
                ParameterA = interfaceMultiplier.ToString(),
                ParameterB = cursorMultiplier.ToString(),
                TriggerId = 330
            };
        }

        /// <summary>
        /// Prevent alive players from seeing chat from dead players
        /// </summary>
        public static TriggerAction PreventAlivePlayersFromSeeingDeadChat()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 338
            };
        }

        /// <summary>
        /// Let alive players see chat from dead players
        /// </summary>
        public static TriggerAction LetAlivePlayersSeeDeadChat()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 339
            };
        }

        /// <summary>
        /// Disable leader board details (such as alive state, score, team)
        /// </summary>
        public static TriggerAction DisableLeaderBoardDetails()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 340
            };
        }

        /// <summary>
        /// Enable leader board details (such as alive state, score, team)
        /// </summary>
        public static TriggerAction EnableLeaderBoardDetails()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 341
            };
        }

        /// <summary>
        /// Switch execution to a specific trigger
        /// </summary>
        /// <param name="triggerId">Trigger ID to switch to</param>
        public static TriggerAction SwitchToTrigger(int triggerId)
        {
            return new TriggerAction
            {
                ParameterA = triggerId.ToString(),
                ParameterB = "-1",
                TriggerId = 363
            };
        }

        /// <summary>
        /// Set list of slots that can be randomly given to player during respawn
        /// </summary>
        /// <param name="slotsVariable">Variable containing slot list</param>
        public static TriggerAction SetRandomRespawnSlots(Variable slotsVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotsVariable.Name,
                ParameterB = "-1",
                TriggerId = 380
            };
        }

        /// <summary>
        /// Set max amount of weapons that can be given to player during respawn
        /// </summary>
        /// <param name="maxWeaponsVariable">Variable containing max weapons count</param>
        public static TriggerAction SetMaxRespawnWeapons(Variable maxWeaponsVariable)
        {
            return new TriggerAction
            {
                ParameterA = maxWeaponsVariable.Name,
                ParameterB = "-1",
                TriggerId = 381
            };
        }

        /// <summary>
        /// Enable kinetic module through walls
        /// </summary>
        /// <param name="enabled">1 to enable, 0 to disable</param>
        public static TriggerAction SetKineticModuleThroughWalls(int enabled)
        {
            return new TriggerAction
            {
                ParameterA = enabled.ToString(),
                ParameterB = "-1",
                TriggerId = 441
            };
        }

        /// <summary>
        /// Set range of bullet mirroring
        /// </summary>
        /// <param name="range">Mirroring range value (default is 30)</param>
        public static TriggerAction SetBulletMirroringRange(double range)
        {
            return new TriggerAction
            {
                ParameterA = range.ToString(),
                ParameterB = "-1",
                TriggerId = 450
            };
        }

        /// <summary>
        /// Set disabling of global player collision
        /// </summary>
        /// <param name="disabled">1 to disable, 0 to enable</param>
        public static TriggerAction SetGlobalPlayerCollisionDisabled(int disabled)
        {
            return new TriggerAction
            {
                ParameterA = disabled.ToString(),
                ParameterB = "-1",
                TriggerId = 453
            };
        }

        /// <summary>
        /// Set disabling of global limb breaking
        /// </summary>
        /// <param name="disabled">1 to disable, 0 to enable</param>
        public static TriggerAction SetGlobalLimbBreakingDisabled(int disabled)
        {
            return new TriggerAction
            {
                ParameterA = disabled.ToString(),
                ParameterB = "-1",
                TriggerId = 468
            };
        }

        /// <summary>
        /// Set disabling of global fall impact instability
        /// </summary>
        /// <param name="disabled">1 to disable, 0 to enable</param>
        public static TriggerAction SetGlobalFallImpactInstabilityDisabled(int disabled)
        {
            return new TriggerAction
            {
                ParameterA = disabled.ToString(),
                ParameterB = "-1",
                TriggerId = 477
            };
        }

        /// <summary>
        /// Change global fall impact instability height multiplier
        /// </summary>
        /// <param name="multiplier">Height multiplier value</param>
        public static TriggerAction SetFallImpactInstabilityHeightMultiplier(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = multiplier.ToString(),
                ParameterB = "-1",
                TriggerId = 479
            };
        }

        /// <summary>
        /// Set disabling of ambient sounds
        /// </summary>
        /// <param name="disabled">1 to disable, 0 to enable</param>
        public static TriggerAction SetAmbientSoundsDisabled(int disabled)
        {
            return new TriggerAction
            {
                ParameterA = disabled.ToString(),
                ParameterB = "-1",
                TriggerId = 483
            };
        }

        /// <summary>
        /// Set game speed using a variable (frames per second)
        /// </summary>
        /// <param name="fpsVariable">Variable containing frames per second (default 30, doesn't influence rendering)</param>
        public static TriggerAction SetGameSpeed(Variable fpsVariable)
        {
            return new TriggerAction
            {
                ParameterA = fpsVariable.Name,
                ParameterB = "-1",
                TriggerId = 500
            };
        }

        /// <summary>
        /// Move character of slot-value in variable to a region
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Region to move character to</param>
        public static TriggerAction MoveCharacterSlotToRegion(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 351
            };
        }

        /// <summary>
        /// Change team of character to variable value
        /// </summary>
        /// <param name="character">Character to change team</param>
        /// <param name="teamVariable">Variable containing team value</param>
        public static TriggerAction ChangeCharacterTeam(Character character, Variable teamVariable)
        {
            return new TriggerAction
            {
                ParameterA = character.Uid,
                ParameterB = teamVariable.Name,
                TriggerId = 505
            };
        }

        /// <summary>
        /// Change team of character slot-value to variable value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="teamVariable">Variable containing team value</param>
        public static TriggerAction ChangeCharacterSlotTeam(Variable slotVariable, Variable teamVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = teamVariable.Name,
                TriggerId = 506
            };
        }

        /// <summary>
        /// Change team of character slot-value to specific value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="teamValue">Team value</param>
        public static TriggerAction ChangeCharacterSlotTeam(Variable slotVariable, int teamValue)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = teamValue.ToString(),
                TriggerId = 507
            };
        }

        /// <summary>
        /// Change number of hit points of character slot-value to variable percents
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="percentVariable">Variable containing percentage value</param>
        public static TriggerAction ChangeCharacterSlotHitPointsPercent(Variable slotVariable, Variable percentVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = percentVariable.Name,
                TriggerId = 511
            };
        }

        /// <summary>
        /// Set current hit points of character slot-value to variable hit points
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="hitPointsVariable">Variable containing hit points value</param>
        public static TriggerAction SetCharacterSlotCurrentHitPoints(Variable slotVariable, Variable hitPointsVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = hitPointsVariable.Name,
                TriggerId = 513
            };
        }

        /// <summary>
        /// Clone character slot-value and spawn it in centre of region
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Region to spawn clone in</param>
        public static TriggerAction CloneCharacterSlot(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 514
            };
        }

        /// <summary>
        /// Clone character slot-value and spawn it in random place of region
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Region to spawn clone in</param>
        public static TriggerAction CloneCharacterSlotRandom(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 515
            };
        }

        /// <summary>
        /// Force all enemies of character slot-value in region to hunt for character slot-value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Region containing enemies</param>
        public static TriggerAction ForceEnemiesInRegionHuntCharacterSlot(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 516
            };
        }

        /// <summary>
        /// Set AI Behavior of computer-controlled character slot-value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="behavior">AI behavior value (0-4)</param>
        public static TriggerAction SetCharacterSlotAIBehavior(Variable slotVariable, int behavior)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = behavior.ToString(),
                TriggerId = 517
            };
        }

        /// <summary>
        /// Change character slot-value nickname to variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="nicknameVariable">Variable containing nickname</param>
        public static TriggerAction ChangeCharacterSlotNickname(Variable slotVariable, Variable nicknameVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = nicknameVariable.Name,
                TriggerId = 518
            };
        }

        /// <summary>
        /// Force character slot-value to drop all weapons
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction ForceCharacterSlotDropAllWeapons(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 519
            };
        }

        /// <summary>
        /// Multiply character slot-value speed by variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="multiplierVariable">Variable containing speed multiplier</param>
        public static TriggerAction MultiplyCharacterSlotSpeed(Variable slotVariable, Variable multiplierVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = multiplierVariable.Name,
                TriggerId = 520
            };
        }

        /// <summary>
        /// Change character slot-value mobility factor to variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="mobilityVariable">Variable containing mobility factor</param>
        public static TriggerAction ChangeCharacterSlotMobilityFactor(Variable slotVariable, Variable mobilityVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = mobilityVariable.Name,
                TriggerId = 521
            };
        }

        /// <summary>
        /// Change character slot-value armor type
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="armorType">Armor type value (0, 1 or 2)</param>
        public static TriggerAction ChangeCharacterSlotArmorType(Variable slotVariable, int armorType)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = armorType.ToString(),
                TriggerId = 522
            };
        }

        /// <summary>
        /// Change blood color of character slot-value to HEX color
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="hexColor">HEX color value</param>
        public static TriggerAction ChangeCharacterSlotBloodColor(Variable slotVariable, string hexColor)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = hexColor,
                TriggerId = 523
            };
        }

        /// <summary>
        /// Force character slot-value to look at random point in region
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Region to look at</param>
        public static TriggerAction ForceCharacterSlotLookAtRandomPoint(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 525
            };
        }

        /// <summary>
        /// Force character slot-value to hunt another character slot-value
        /// </summary>
        /// <param name="hunterSlotVariable">Variable containing hunter character slot</param>
        /// <param name="targetSlotVariable">Variable containing target character slot</param>
        public static TriggerAction ForceCharacterSlotHunt(Variable hunterSlotVariable, Variable targetSlotVariable)
        {
            return new TriggerAction
            {
                ParameterA = hunterSlotVariable.Name,
                ParameterB = targetSlotVariable.Name,
                TriggerId = 526
            };
        }

        /// <summary>
        /// Damage character slot-value head hitpoints by variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="damageVariable">Variable containing damage value</param>
        public static TriggerAction DamageCharacterSlotHead(Variable slotVariable, Variable damageVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = damageVariable.Name,
                TriggerId = 527
            };
        }

        /// <summary>
        /// Damage character slot-value arms hitpoints by variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="damageVariable">Variable containing damage value</param>
        public static TriggerAction DamageCharacterSlotArms(Variable slotVariable, Variable damageVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = damageVariable.Name,
                TriggerId = 528
            };
        }

        /// <summary>
        /// Damage character slot-value body hitpoints by variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="damageVariable">Variable containing damage value</param>
        public static TriggerAction DamageCharacterSlotBody(Variable slotVariable, Variable damageVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = damageVariable.Name,
                TriggerId = 529
            };
        }

        /// <summary>
        /// Damage character slot-value legs hitpoints by variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="damageVariable">Variable containing damage value</param>
        public static TriggerAction DamageCharacterSlotLegs(Variable slotVariable, Variable damageVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = damageVariable.Name,
                TriggerId = 530
            };
        }

        /// <summary>
        /// Save inventory info of character slot-value to variable
        /// </summary>
        /// <param name="inventoryVariable">Variable to save inventory info to</param>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction SaveCharacterSlotInventory(Variable inventoryVariable, Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = inventoryVariable.Name,
                ParameterB = slotVariable.Name,
                TriggerId = 531
            };
        }

        /// <summary>
        /// Spawn all weapons stored in variable at position of character slot-value
        /// </summary>
        /// <param name="weaponsVariable">Variable containing weapons</param>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction SpawnWeaponsAtCharacterSlot(Variable weaponsVariable, Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = weaponsVariable.Name,
                ParameterB = slotVariable.Name,
                TriggerId = 532
            };
        }

        /// <summary>
        /// Set character slot-value scale to variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="scaleVariable">Variable containing scale value</param>
        public static TriggerAction SetCharacterSlotScale(Variable slotVariable, Variable scaleVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = scaleVariable.Name,
                TriggerId = 533
            };
        }

        /// <summary>
        /// Heal character slot-value by variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="healVariable">Variable containing heal amount</param>
        public static TriggerAction HealCharacterSlot(Variable slotVariable, Variable healVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = healVariable.Name,
                TriggerId = 534
            };
        }

        /// <summary>
        /// Set intensity of entity pushing force for character slot-value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="intensityVariable">Variable containing intensity value (default 0)</param>
        public static TriggerAction SetCharacterSlotPushingForceIntensity(Variable slotVariable, Variable intensityVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = intensityVariable.Name,
                TriggerId = 535
            };
        }

        /// <summary>
        /// Set radius of entity pushing force for character slot-value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="radiusVariable">Variable containing radius value</param>
        public static TriggerAction SetCharacterSlotPushingForceRadius(Variable slotVariable, Variable radiusVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = radiusVariable.Name,
                TriggerId = 536
            };
        }

        /// <summary>
        /// Set character slot-value voice preset
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="preset">Voice preset value</param>
        public static TriggerAction SetCharacterSlotVoicePreset(Variable slotVariable, int preset)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = preset.ToString(),
                TriggerId = 537
            };
        }

        /// <summary>
        /// Apply damage-over-time effect to character slot-value with power and duration
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="powerAndDuration">Power and duration separated by commas</param>
        public static TriggerAction ApplyDamageOverTimeToCharacterSlot(Variable slotVariable, string powerAndDuration)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = powerAndDuration,
                TriggerId = 538
            };
        }

        /// <summary>
        /// Remove all effects from character slot-value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction RemoveAllEffectsFromCharacterSlot(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 539
            };
        }

        /// <summary>
        /// Spawn damage particles of character slot-value at center of region
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="region">Region to spawn particles at</param>
        public static TriggerAction SpawnDamageParticlesAtRegion(Variable slotVariable, Region region)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = region.Uid,
                TriggerId = 540
            };
        }

        /// <summary>
        /// Set jump multiplier for character slot-value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="multiplierVariable">Variable containing jump multiplier</param>
        public static TriggerAction SetCharacterSlotJumpMultiplier(Variable slotVariable, Variable multiplierVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = multiplierVariable.Name,
                TriggerId = 541
            };
        }

        /// <summary>
        /// Set character slot-value active weapon to gun
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        /// <param name="gun">Gun to set as active weapon</param>
        public static TriggerAction SetCharacterSlotActiveWeapon(Variable slotVariable, Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = gun.Uid,
                TriggerId = 542
            };
        }

        /// <summary>
        /// Make character slot-value drop weapon at current slot
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction MakeCharacterSlotDropWeapon(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 543
            };
        }

        /// <summary>
        /// Make character slot-value unhittable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction MakeCharacterSlotUnhittable(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 545
            };
        }

        /// <summary>
        /// Make character slot-value hittable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction MakeCharacterSlotHittable(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 546
            };
        }

        /// <summary>
        /// Add ghost effect to character slot-value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction AddGhostEffectToCharacterSlot(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 400
            };
        }

        /// <summary>
        /// Remove ghost effect from character slot-value
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction RemoveGhostEffectFromCharacterSlot(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 401
            };
        }

        /// <summary>
        /// Move character slot-value to start position
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public static TriggerAction MoveCharacterSlotToStartPosition(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = slotVariable.Name,
                ParameterB = "-1",
                TriggerId = 402
            };
        }

        /// <summary>
        /// Set character slot-value properties to properties of another character slot-value
        /// </summary>
        /// <param name="targetSlotVariable">Variable containing target character slot</param>
        /// <param name="sourceSlotVariable">Variable containing source character slot</param>
        public static TriggerAction SetCharacterSlotProperties(Variable targetSlotVariable, Variable sourceSlotVariable)
        {
            return new TriggerAction
            {
                ParameterA = targetSlotVariable.Name,
                ParameterB = sourceSlotVariable.Name,
                TriggerId = 404
            };
        }

        /// <summary>
        /// Continue trigger actions execution only if loading of custom images has been finished
        /// </summary>
        public static TriggerAction ContinueIfCustomImagesLoaded()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 275
            };
        }

        /// <summary>
        /// Continue trigger actions execution only if all custom images have been successfully loaded
        /// </summary>
        public static TriggerAction ContinueIfAllCustomImagesLoaded()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 276
            };
        }

        /// <summary>
        /// Save current number of loaded custom images to variable
        /// </summary>
        /// <param name="resultVariable">Variable to store loaded custom images count</param>
        public static TriggerAction GetLoadedCustomImagesCount(Variable resultVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = "-1",
                TriggerId = 277
            };
        }

        /// <summary>
        /// Save number of expected custom images on current level to variable
        /// </summary>
        /// <param name="resultVariable">Variable to store expected custom images count</param>
        public static TriggerAction GetExpectedCustomImagesCount(Variable resultVariable)
        {
            return new TriggerAction
            {
                ParameterA = resultVariable.Name,
                ParameterB = "-1",
                TriggerId = 278
            };
        }

        /// <summary>
        /// Reward player with experience points for level completion (singleplayer)
        /// </summary>
        public static TriggerAction RewardPlayerExperience()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 285
            };
        }

        /// <summary>
        /// Reward player-initiator with experience points for level completion (multiplayer)
        /// </summary>
        public static TriggerAction RewardInitiatorExperience()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 286
            };
        }

        /// <summary>
        /// Bind Trigger execution to key press event
        /// </summary>
        /// <param name="trigger">Trigger to bind</param>
        /// <param name="keyName">Name of the key</param>
        public static TriggerAction BindTriggerToKeyPress(Trigger trigger, string keyName)
        {
            return new TriggerAction
            {
                ParameterA = trigger.Uid,
                ParameterB = keyName,
                TriggerId = 288
            };
        }

        /// <summary>
        /// Bind Trigger execution to key release event
        /// </summary>
        /// <param name="trigger">Trigger to bind</param>
        /// <param name="keyName">Name of the key</param>
        public static TriggerAction BindTriggerToKeyRelease(Trigger trigger, string keyName)
        {
            return new TriggerAction
            {
                ParameterA = trigger.Uid,
                ParameterB = keyName,
                TriggerId = 289
            };
        }

        /// <summary>
        /// Disable automatic disabling of offscreen entities
        /// </summary>
        public static TriggerAction DisableOffscreenEntityDisabling()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 291
            };
        }

        /// <summary>
        /// Enable automatic disabling of offscreen entities
        /// </summary>
        public static TriggerAction EnableOffscreenEntityDisabling()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = "-1",
                TriggerId = 292
            };
        }


    }
}
