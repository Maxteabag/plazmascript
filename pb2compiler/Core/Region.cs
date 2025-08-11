using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public enum ActivationTrigger
    {
        NoActivation = 0,
        UseKeyWithButton = 1,
        CharacterNotInVehicle = 2,
        CharacterInVehicle = 3,
        Character = 4,
        ByMovable = 5,
        Player = 6,
        ContainingAllSingleplayerHeroes = 7,
        UseKeyWithoutButton = 8,
        UseKeyRedTeamWithButton = 9,
        UseKeyBlueTeamWithButton = 10,
        UseKeyRedTeamWithoutButton = 11,
        UseKeyBlueTeamWithoutButton = 12,
        RedTeamPlayer = 13,
        BlueTeamPlayer = 14,
        UseKeyWithoutButtonWithoutSound = 15
    }

    public class Region : SizedObject
    {
        public ActivationTrigger Activation { get; set; } = ActivationTrigger.NoActivation;

        public Region(string uid, int x, int y, int width, int height, ActivationTrigger activation = ActivationTrigger.NoActivation)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Activation = activation;
            
            Uid = uid;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            PB2Map.MapObjects.Add(this);
        }

        public override XElement CreateXmlElement()
        {
            var xElement = new XElement("region");

            xElement.SetAttributeValue("uid", Uid);
            xElement.SetAttributeValue("x", X.ToString());
            xElement.SetAttributeValue("y", Y.ToString());
            xElement.SetAttributeValue("w", Width.ToString());
            xElement.SetAttributeValue("h", Height.ToString());
            
            if (Activation != ActivationTrigger.NoActivation)
            {
                xElement.SetAttributeValue("use_on", ((int)Activation).ToString());
            }

            return xElement;
        }

        /// <summary>
        /// Set X position of left-top corner point
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetXLeftTopCornerPoint(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = variable.Name,
                TriggerId = 120
            };
        }

        /// <summary>
        /// Set Y position of left-top corner point
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetYLeftTopCornerPoint(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = variable.Name,
                TriggerId = 121
            };
        }

        /// <summary>
        /// Quickly move this region to the position of another region
        /// </summary>
        /// <param name="targetRegion">The target region to move to</param>
        public TriggerAction QuickMoveToRegion(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 2
            };
        }

        /// <summary>
        /// Move this region to the center of another region
        /// </summary>
        /// <param name="targetRegion">The target region</param>
        public TriggerAction MoveToCenterOf(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 18
            };
        }

        /// <summary>
        /// Make damage in this region with specified power
        /// </summary>
        /// <param name="damage">The damage power in hit points</param>
        public TriggerAction MakeDamage(int damage)
        {
            return new TriggerAction
            {
                ParameterA = damage.ToString(),
                ParameterB = Uid,
                TriggerId = 6
            };
        }

        /// <summary>
        /// Destroy all vehicles in this region
        /// </summary>
        public TriggerAction DestroyAllVehicles()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 12
            };
        }

        /// <summary>
        /// Kill all characters in this region that are not allied to a specific character
        /// </summary>
        /// <param name="allyCharacter">Characters allied to this will be spared</param>
        public TriggerAction KillEnemiesOf(Character allyCharacter)
        {
            return new TriggerAction
            {
                ParameterA = allyCharacter.Uid,
                ParameterB = Uid,
                TriggerId = 11
            };
        }

        /// <summary>
        /// Harm the stability of all characters in this region
        /// </summary>
        /// <param name="power">The power of the stability harm</param>
        public TriggerAction HarmStability(int power)
        {
            return new TriggerAction
            {
                ParameterA = power.ToString(),
                ParameterB = Uid,
                TriggerId = 10
            };
        }

        /// <summary>
        /// Make an explosion with specified power at this region
        /// </summary>
        /// <param name="power">The explosion power</param>
        public TriggerAction MakeExplosion(int power)
        {
            return new TriggerAction
            {
                ParameterA = power.ToString(),
                ParameterB = Uid,
                TriggerId = 24
            };
        }

        /// <summary>
        /// Make an explosion with power from a variable at this region
        /// </summary>
        /// <param name="powerVariable">The variable containing explosion power</param>
        public TriggerAction MakeExplosion(Variable powerVariable)
        {
            return new TriggerAction
            {
                ParameterA = powerVariable.Name,
                ParameterB = Uid,
                TriggerId = 126
            };
        }

        /// <summary>
        /// Teleport all players from this region to another region
        /// </summary>
        /// <param name="targetRegion">The destination region</param>
        public TriggerAction TeleportAllPlayersTo(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 30
            };
        }

        /// <summary>
        /// Teleport all players from this region to another region and invert speed by X axis
        /// </summary>
        /// <param name="targetRegion">The destination region</param>
        public TriggerAction TeleportAllPlayersToWithSpeedInvert(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 31
            };
        }

        /// <summary>
        /// Flip X speed for all players in this region
        /// </summary>
        public TriggerAction FlipXSpeedForAllPlayers()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = Uid,
                TriggerId = 56
            };
        }

        /// <summary>
        /// Flip Y speed for all players in this region
        /// </summary>
        public TriggerAction FlipYSpeedForAllPlayers()
        {
            return new TriggerAction
            {
                ParameterA = "-1",
                ParameterB = Uid,
                TriggerId = 57
            };
        }

        /// <summary>
        /// Teleport player-initiator from this region to another region
        /// </summary>
        /// <param name="targetRegion">The destination region</param>
        public TriggerAction TeleportPlayerInitiatorTo(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 70
            };
        }

        /// <summary>
        /// Move this region to cursor position of player-initiator
        /// </summary>
        public TriggerAction MoveToPlayerInitiatorCursor()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 87
            };
        }

        /// <summary>
        /// Move this region to a gun
        /// </summary>
        /// <param name="gun">The gun to move to</param>
        public TriggerAction MoveToGun(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = gun.Uid,
                TriggerId = 323
            };
        }

        /// <summary>
        /// Move this region to lower body of a player
        /// </summary>
        /// <param name="player">The player to move to</param>
        public TriggerAction MoveToPlayerLowerBody(Player player)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = player.Uid,
                TriggerId = 353
            };
        }

        /// <summary>
        /// Move this region to the game camera
        /// </summary>
        public TriggerAction MoveToGameCamera()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 396
            };
        }

        /// <summary>
        /// Move this region relative to current position along X axis
        /// </summary>
        /// <param name="offsetVariable">Variable containing X offset</param>
        public TriggerAction MoveRelativeX(Variable offsetVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = offsetVariable.Name,
                TriggerId = 480
            };
        }

        /// <summary>
        /// Move this region relative to current position along Y axis
        /// </summary>
        /// <param name="offsetVariable">Variable containing Y offset</param>
        public TriggerAction MoveRelativeY(Variable offsetVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = offsetVariable.Name,
                TriggerId = 481
            };
        }

        /// <summary>
        /// Destroy all projectiles in this region
        /// </summary>
        public TriggerAction DestroyAllProjectiles()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 487
            };
        }

        /// <summary>
        /// Move projectiles in this region to another region
        /// </summary>
        /// <param name="targetRegion">Target region for projectiles</param>
        public TriggerAction MoveProjectilesTo(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 488
            };
        }

        /// <summary>
        /// Multiply speed of all projectiles in this region
        /// </summary>
        /// <param name="multiplier">Speed multiplier value</param>
        public TriggerAction MultiplyProjectileSpeed(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = multiplier.ToString(),
                TriggerId = 491
            };
        }

        /// <summary>
        /// Continue execution only if this region contains projectiles
        /// </summary>
        public TriggerAction ContinueIfContainsProjectiles()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 492
            };
        }

        /// <summary>
        /// Continue execution only if this region doesn't contain projectiles
        /// </summary>
        public TriggerAction ContinueIfDoesNotContainProjectiles()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 493
            };
        }

        /// <summary>
        /// Initiate this region using a character as initiator
        /// </summary>
        /// <param name="character">Character to use as initiator</param>
        public TriggerAction InitiateWithCharacter(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = character.Uid,
                TriggerId = 440
            };
        }

        /// <summary>
        /// Initiate this region using a character slot as initiator
        /// </summary>
        /// <param name="characterSlotVariable">Variable containing character slot</param>
        public TriggerAction InitiateWithCharacterSlot(Variable characterSlotVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = characterSlotVariable.Name,
                TriggerId = 499
            };
        }

        /// <summary>
        /// Kill all characters in this region which are not allied to specified character slot
        /// </summary>
        /// <param name="allySlotVariable">Variable containing ally character slot</param>
        public TriggerAction KillAllEnemiesOfCharacterSlot(Variable allySlotVariable)
        {
            return new TriggerAction
            {
                ParameterA = allySlotVariable.Name,
                ParameterB = Uid,
                TriggerId = 512
            };
        }

        /// <summary>
        /// Continue execution only if tracing from center of this region to center of another region doesn't intersect a character
        /// </summary>
        /// <param name="targetRegion">Target region for tracing</param>
        public TriggerAction ContinueIfTracingDoesNotIntersectCharacter(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 406
            };
        }

        /// <summary>
        /// Continue execution only if tracing from center of this region to center of another region intersects a character
        /// </summary>
        /// <param name="targetRegion">Target region for tracing</param>
        public TriggerAction ContinueIfTracingIntersectsCharacter(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 407
            };
        }

        /// <summary>
        /// Multiply speed of players in this region by a specific value
        /// </summary>
        /// <param name="multiplier">The speed multiplier</param>
        public TriggerAction MultiplyPlayerSpeed(double multiplier)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = multiplier.ToString(),
                TriggerId = 72
            };
        }

        /// <summary>
        /// Move this region to player-initiator
        /// </summary>
        public TriggerAction MoveToPlayerInitiator()
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = "-1",
                TriggerId = 79
            };
        }

        /// <summary>
        /// Move this region to a specific player
        /// </summary>
        /// <param name="player">The target player</param>
        public TriggerAction MoveToPlayer(Player player)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = player.Uid,
                TriggerId = 80
            };
        }

        /// <summary>
        /// Move this region relative to current position along X axis
        /// </summary>
        /// <param name="deltaX">Relative X movement</param>
        public TriggerAction MoveRelativeX(int deltaX)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = deltaX.ToString(),
                TriggerId = 83
            };
        }

        /// <summary>
        /// Move this region relative to current position along Y axis
        /// </summary>
        /// <param name="deltaY">Relative Y movement</param>
        public TriggerAction MoveRelativeY(int deltaY)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = deltaY.ToString(),
                TriggerId = 84
            };
        }

        /// <summary>
        /// Continue execution of this trigger only if tracing from center of this region to center of target region is possible
        /// </summary>
        /// <param name="targetRegion">The target region to trace to</param>
        public TriggerAction ContinueIfTracingPossible(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 95
            };
        }

        /// <summary>
        /// Continue execution of this trigger only if tracing from center of this region to center of target region is impossible
        /// </summary>
        /// <param name="targetRegion">The target region to trace to</param>
        public TriggerAction ContinueIfTracingImpossible(Region targetRegion)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = targetRegion.Uid,
                TriggerId = 96
            };
        }

        /// <summary>
        /// Move this region to a moveable object
        /// </summary>
        /// <param name="moveable">The moveable object to move to</param>
        public TriggerAction MoveToMoveable(Moveable moveable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = moveable.Uid,
                TriggerId = 98
            };
        }

        /// <summary>
        /// Move this region to cursor of player
        /// </summary>
        /// <param name="player">Player to get cursor position from</param>
        public TriggerAction MoveToCursorOfPlayer(Player player)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = player.Uid,
                TriggerId = 259
            };
        }

        /// <summary>
        /// Play sound at this Region (volume and stereo effect won't be updated once sound starts)
        /// </summary>
        /// <param name="soundName">Name of the sound to play</param>
        public TriggerAction PlaySound(string soundName)
        {
            return new TriggerAction
            {
                ParameterA = soundName,
                ParameterB = Uid,
                TriggerId = 284
            };
        }

    }
}
