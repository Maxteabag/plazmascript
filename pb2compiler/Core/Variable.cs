using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlazmaScript.Core
{

   
    public class Variable
    {
        public string Name { get; set; }
        public string Value { get; set; }



        public Variable(string name)
        {
            this.Name = name;
        }
        public Variable()
        {
            this.Name = RandomGenerator.RandomString(10);
        }
        public Variable(int name)
        {
            this.Name = name.ToString();
        }

        public TriggerAction SetValue(int value)
        {
            return SetValue(value.ToString());
        }
        public TriggerAction SetValue(string value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value,
                TriggerId = 100
            };
        }
        public TriggerAction SetValue(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 125
            };
        }

        public TriggerAction SetToTextBeingSaid()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 160
            };
        }

        /// <summary>
        /// Synchronize the variable with all other players overriding value
        /// </summary>
        /// <returns></returns>
        public TriggerAction Sync()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 223
            };
        }

        /// <summary>
        /// Synchronize variable through keeping defined value (requires Var Sync engine mark)
        /// </summary>
        public TriggerAction SyncKeepDefined()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 224
            };
        }

        /// <summary>
        /// Synchronize variable through keeping maximum value (requires Var Sync engine mark)
        /// </summary>
        public TriggerAction SyncKeepMaximum()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 225
            };
        }

        /// <summary>
        /// Synchronize variable through keeping minimum value (requires Var Sync engine mark)
        /// </summary>
        public TriggerAction SyncKeepMinimum()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 226
            };
        }

        /// <summary>
        /// Synchronize variable through keeping longest String value (requires Var Sync engine mark)
        /// </summary>
        public TriggerAction SyncKeepLongestString()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 227
            };
        }

        /// <summary>
        /// Set variable value to projectile power (trigger should receive damage from Movable)
        /// </summary>
        public TriggerAction SetToProjectilePower()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 235
            };
        }

        /// <summary>
        /// Subtract projectile power from variable value (trigger should receive damage from Movable)
        /// </summary>
        public TriggerAction SubtractProjectilePower()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 236
            };
        }

        /// <summary>
        /// Save horizontal movement intention of a character to this variable
        /// </summary>
        /// <param name="character">Character whose horizontal movement intention to save</param>
        public TriggerAction SaveCharacterHorizontalMovement(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 247
            };
        }

        /// <summary>
        /// Save vertical movement intention of a character to this variable
        /// </summary>
        /// <param name="character">Character whose vertical movement intention to save</param>
        public TriggerAction SaveCharacterVerticalMovement(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 248
            };
        }

        /// <summary>
        /// Save shoot intention of a character to this variable
        /// </summary>
        /// <param name="character">Character whose shoot intention to save</param>
        public TriggerAction SaveCharacterShootIntention(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 249
            };
        }

        /// <summary>
        /// Save energy value to this variable (gameplay)
        /// </summary>
        public TriggerAction SaveEnergyValue()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 263
            };
        }

        /// <summary>
        /// Load energy value from this variable (gameplay)
        /// </summary>
        public TriggerAction LoadEnergyValue()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 264
            };
        }

        /// <summary>
        /// Set max energy value to value of this variable (gameplay)
        /// </summary>
        public TriggerAction SetMaxEnergyValue()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 265
            };
        }

        /// <summary>
        /// Save current AI difficulty to this variable (easy = 1, normal = 2, hard = 3)
        /// </summary>
        public TriggerAction SaveCurrentAIDifficulty()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 266
            };
        }

        public List<TriggerAction> Contains(string value)
        {
            var actions = new List<TriggerAction>();

            var testVariable = new Variable();

            actions.Add(testVariable.SetValue(this));
            actions.Add(testVariable.SetToBooleanIfContains(value));
            actions.Add(testVariable == 1); //Continue if....

            return actions;
        }

        /// <summary>
        /// Set value to 1 if contains <paramref name="value"/> and set 0 in else case
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetToBooleanIfContains(string value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value,
                TriggerId = 149
            };
        }

        /// <summary>
        /// Set value to 1 if contains <paramref name="value"/> and set 0 in else case
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetToBooleanIfContains(Variable value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.Name,
                TriggerId = 150
            };
        }

        public TriggerAction SetValueIfNotDefined(int value)
        {
            return SetValueIfNotDefined(value.ToString());
        }
        public TriggerAction SetValueIfNotDefined(string value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value,
                TriggerId = 101
            };
        }

        public TriggerAction Add(int value)
        {
            return Add(value.ToString());
        }
        public TriggerAction Add(string value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value,
                TriggerId = 102
            };
        }
        public TriggerAction Multiply(int value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.ToString(),
                TriggerId = 103
            };
        }

        public TriggerAction Add(Variable b)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = b.Name.ToString(),
                TriggerId = 104
            };
        }
        public TriggerAction Multiply(Variable b)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = b.Name.ToString(),
                TriggerId = 105
            };
        }

        /// <summary>
        /// Set value of variable 'A' to random number with floating point in range 0...[value]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetRandom(int value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.ToString(),
                TriggerId = 106
            };
        }
        /// <summary>
        /// Set value of variable 'A' to random number with floating point in range 0...[value]-1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetRandomMinusOne(int value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.ToString(),
                TriggerId = 107
            };
        }

        public TriggerAction Round()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 108
            };
        }

        public TriggerAction Floor()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 109
            };
        }

        /// <summary>
        /// Set value of variable to value of region X position left corner
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetToRegionXLeftCorner(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = region.Uid,
                TriggerId = 118
            };
        }

        internal TriggerAction SkipNextActionIfNotEquals(string v)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = v,
                TriggerId = 123
            };
        }

        internal TriggerAction SetToPlayerHp(string v)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = v,
                TriggerId = 122
            };
        }

        /// <summary>
        /// Set value of variable to value of region Y position left corner
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TriggerAction SetToRegionYLeftCorner(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = region.Uid,
                TriggerId = 119
            };
        }

        /// <summary>
        /// Set variable value to remainder after division by value (only positive numbers)
        /// </summary>
        /// <param name="value">The divisor value</param>
        public TriggerAction Modulo(int value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.ToString(),
                TriggerId = 124
            };
        }

        /// <summary>
        /// Set variable value to remainder after division by another variable (only positive numbers)
        /// </summary>
        /// <param name="variable">The divisor variable</param>
        public TriggerAction Modulo(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 127
            };
        }

        /// <summary>
        /// Divide this variable by a value
        /// </summary>
        /// <param name="value">The divisor value</param>
        public TriggerAction Divide(int value)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = value.ToString(),
                TriggerId = 131
            };
        }

        /// <summary>
        /// Divide this variable by another variable
        /// </summary>
        /// <param name="variable">The divisor variable</param>
        public TriggerAction Divide(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 132
            };
        }

        /// <summary>
        /// Set value to result of power function (this variable ^ another variable)
        /// </summary>
        /// <param name="power">The power variable</param>
        public TriggerAction Power(Variable power)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = power.Name,
                TriggerId = 133
            };
        }

        /// <summary>
        /// Set value to result of power function (this variable ^ value)
        /// </summary>
        /// <param name="power">The power value</param>
        public TriggerAction Power(int power)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = power.ToString(),
                TriggerId = 134
            };
        }

        /// <summary>
        /// Set value to result of sin function with another variable (in radians) as parameter
        /// </summary>
        /// <param name="variable">The input variable in radians</param>
        public TriggerAction SetToSin(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 135
            };
        }

        /// <summary>
        /// Set value to result of cos function with another variable (in radians) as parameter
        /// </summary>
        /// <param name="variable">The input variable in radians</param>
        public TriggerAction SetToCos(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 136
            };
        }

        /// <summary>
        /// Set value to slot of current player
        /// </summary>
        public TriggerAction SetToCurrentPlayerSlot()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 137
            };
        }

        /// <summary>
        /// Set value to 1 if game is in multiplayer mode and to 0 in else case
        /// </summary>
        public TriggerAction SetToIsMultiplayer()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 138
            };
        }

        /// <summary>
        /// Set value to 1 if my player is spectating this match as spectator and to 0 in else case
        /// </summary>
        public TriggerAction SetToIsSpectating()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 139
            };
        }

        /// <summary>
        /// Set value to 1 if LOW PHYSICS setting is enabled and to 0 in else case
        /// </summary>
        public TriggerAction SetToLowPhysicsEnabled()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 140
            };
        }

        /// <summary>
        /// Set value to number of alive players in a region
        /// </summary>
        /// <param name="region">The region to count players in</param>
        public TriggerAction SetToAlivePlayersInRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = region.Uid,
                TriggerId = 145
            };
        }

        /// <summary>
        /// Set string-value to login name of player-initiator
        /// </summary>
        public TriggerAction SetToPlayerInitiatorLoginName()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 146
            };
        }

        /// <summary>
        /// Set string-value to displayed name of player-initiator
        /// </summary>
        public TriggerAction SetToPlayerInitiatorDisplayName()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 147
            };
        }

        /// <summary>
        /// Set string-value to multiplayer match name
        /// </summary>
        public TriggerAction SetToMultiplayerMatchName()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 148
            };
        }

        /// <summary>
        /// Set value to length of string-value of another variable
        /// </summary>
        /// <param name="variable">The variable whose string length to get</param>
        public TriggerAction SetToStringLength(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 151
            };
        }

        /// <summary>
        /// Add string-value of another variable at the end of this variable's string-value
        /// </summary>
        /// <param name="variable">The variable to append</param>
        public TriggerAction AppendString(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 152
            };
        }

        /// <summary>
        /// Set value to 1-A (boolean invert for binary values)
        /// </summary>
        public TriggerAction BooleanInvert()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 153
            };
        }

        /// <summary>
        /// Set value to -A (numerical negate)
        /// </summary>
        public TriggerAction Negate()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 154
            };
        }

        /// <summary>
        /// Set value to current frame time
        /// </summary>
        public TriggerAction SetToCurrentFrameTime()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 155
            };
        }

        /// <summary>
        /// Set string-value to login name of player who says text
        /// </summary>
        public TriggerAction SetToChatPlayerLoginName()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 157
            };
        }

        /// <summary>
        /// Set string-value to displayed name of player who says text
        /// </summary>
        public TriggerAction SetToChatPlayerDisplayName()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 158
            };
        }

        /// <summary>
        /// Set value to slot index of player who says text
        /// </summary>
        public TriggerAction SetToChatPlayerSlot()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 159
            };
        }

        /// <summary>
        /// Save value of a regular variable to this session variable
        /// </summary>
        /// <param name="regularVariable">The regular variable to save</param>
        public TriggerAction SaveFromRegularVariable(Variable regularVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = regularVariable.Name,
                TriggerId = 162
            };
        }

        /// <summary>
        /// Load value for a regular variable from this session variable
        /// </summary>
        /// <param name="regularVariable">The regular variable to load into</param>
        public TriggerAction LoadToRegularVariable(Variable regularVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = regularVariable.Name,
                TriggerId = 163
            };
        }

        /// <summary>
        /// Set value to id of type of current multiplayer mode
        /// </summary>
        public TriggerAction SetToMultiplayerModeType()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 177
            };
        }

        /// <summary>
        /// Save inventory info of a character to this variable
        /// </summary>
        /// <param name="character">The character whose inventory to save</param>
        public TriggerAction SaveCharacterInventory(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 178
            };
        }

        /// <summary>
        /// Spawn all weapons stored in this variable at position of a character
        /// </summary>
        /// <param name="character">The character at whose position to spawn weapons</param>
        public TriggerAction SpawnWeaponsAtCharacter(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 179
            };
        }

        /// <summary>
        /// Set value to player-initiator slot
        /// </summary>
        public TriggerAction SetToPlayerInitiatorSlot()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 180
            };
        }

        /// <summary>
        /// Set value to player-killer slot
        /// </summary>
        public TriggerAction SetToPlayerKillerSlot()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 181
            };
        }

        /// <summary>
        /// Set value to login name of player-killer
        /// </summary>
        public TriggerAction SetToPlayerKillerLoginName()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 182
            };
        }

        /// <summary>
        /// Set value to displayed name of player-killer
        /// </summary>
        public TriggerAction SetToPlayerKillerDisplayName()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 183
            };
        }

        /// <summary>
        /// Set value to login name of player with specific slot
        /// </summary>
        /// <param name="slot">Player slot number</param>
        public TriggerAction SetToPlayerLoginName(int slot)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slot.ToString(),
                TriggerId = 184
            };
        }

        /// <summary>
        /// Set value to displayed name of player with specific slot
        /// </summary>
        /// <param name="slot">Player slot number</param>
        public TriggerAction SetToPlayerDisplayName(int slot)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slot.ToString(),
                TriggerId = 185
            };
        }

        /// <summary>
        /// Set value to team ID of player with specific slot
        /// </summary>
        /// <param name="slot">Player slot number</param>
        public TriggerAction SetToPlayerTeamId(int slot)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slot.ToString(),
                TriggerId = 186
            };
        }

        /// <summary>
        /// Set value to login name of player with slot from variable
        /// </summary>
        /// <param name="slotVariable">Variable containing player slot number</param>
        public TriggerAction SetToPlayerLoginName(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slotVariable.Name,
                TriggerId = 187
            };
        }

        /// <summary>
        /// Set value to displayed name of player with slot from variable
        /// </summary>
        /// <param name="slotVariable">Variable containing player slot number</param>
        public TriggerAction SetToPlayerDisplayName(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slotVariable.Name,
                TriggerId = 188
            };
        }

        /// <summary>
        /// Set value to team ID of player with slot from variable
        /// </summary>
        /// <param name="slotVariable">Variable containing player slot number</param>
        public TriggerAction SetToPlayerTeamId(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slotVariable.Name,
                TriggerId = 189
            };
        }

        /// <summary>
        /// Set value to result of asin function with another variable as parameter
        /// </summary>
        /// <param name="variable">The input variable</param>
        public TriggerAction SetToASin(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 204
            };
        }

        /// <summary>
        /// Set value to result of acos function with another variable as parameter
        /// </summary>
        /// <param name="variable">The input variable</param>
        public TriggerAction SetToACos(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 205
            };
        }

        /// <summary>
        /// Set value to result of atan2 function with this variable and another variable as parameters
        /// </summary>
        /// <param name="variable">The second parameter variable</param>
        public TriggerAction SetToATan2(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = variable.Name,
                TriggerId = 206
            };
        }

        /// <summary>
        /// Replace variables with their values in string-value of another variable and save result to this variable
        /// </summary>
        /// <param name="sourceVariable">Variable containing string with variables to replace</param>
        public TriggerAction ReplaceVariablesInString(Variable sourceVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = sourceVariable.Name,
                TriggerId = 325
            };
        }

        /// <summary>
        /// Replace variables with their values in string-value and save result to this variable
        /// </summary>
        /// <param name="sourceString">String with variables to replace</param>
        public TriggerAction ReplaceVariablesInString(string sourceString)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = sourceString,
                TriggerId = 326
            };
        }

        /// <summary>
        /// Set this variable to random number in range 0..X where X is value of another variable
        /// </summary>
        /// <param name="rangeVariable">Variable containing the upper bound</param>
        public TriggerAction SetRandomInRange(Variable rangeVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = rangeVariable.Name,
                TriggerId = 327
            };
        }

        /// <summary>
        /// Set this variable to random integer in range 0..X-1 where X is value of another variable
        /// </summary>
        /// <param name="rangeVariable">Variable containing the upper bound</param>
        public TriggerAction SetRandomIntegerInRange(Variable rangeVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = rangeVariable.Name,
                TriggerId = 328
            };
        }

        /// <summary>
        /// Set this variable string-value to 'Gameplay modifications' field from match starting screen
        /// </summary>
        public TriggerAction SetToGameplayModifications()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 331
            };
        }

        /// <summary>
        /// Set this variable to 1 if specified gun is not in owner's active slot, 0 otherwise
        /// </summary>
        /// <param name="gun">Gun to check</param>
        public TriggerAction SetToGunNotInActiveSlot(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 332
            };
        }

        /// <summary>
        /// Set this variable to 1 if specified gun has owner, 0 otherwise
        /// </summary>
        /// <param name="gun">Gun to check</param>
        public TriggerAction SetToGunHasOwner(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 333
            };
        }

        /// <summary>
        /// Set this variable to number of frames passed since last attack of a gun
        /// </summary>
        /// <param name="gun">Gun to check</param>
        public TriggerAction SetToGunFramesSinceLastAttack(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 334
            };
        }

        /// <summary>
        /// Set this variable to 1 if specified gun is ready to fire, 0 otherwise
        /// </summary>
        /// <param name="gun">Gun to check</param>
        public TriggerAction SetToGunReadyToFire(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 335
            };
        }

        /// <summary>
        /// Set this variable to X direction of a gun
        /// </summary>
        /// <param name="gun">Gun to get X direction from</param>
        public TriggerAction SetToGunXDirection(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 336
            };
        }

        /// <summary>
        /// Set this variable to X direction of a character
        /// </summary>
        /// <param name="character">Character to get X direction from</param>
        public TriggerAction SetToCharacterXDirection(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 337
            };
        }

        /// <summary>
        /// Set value of variable named in this variable to value of another variable
        /// </summary>
        /// <param name="valueVariable">Variable containing the value to set</param>
        public TriggerAction SetValueOfVariableNamed(Variable valueVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = valueVariable.Name,
                TriggerId = 342
            };
        }

        /// <summary>
        /// Set this variable to degrees rotation of a decoration
        /// </summary>
        /// <param name="decoration">Decoration to get rotation from</param>
        public TriggerAction SetToDecorationRotation(Decoration decoration)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = decoration.Uid,
                TriggerId = 344
            };
        }

        /// <summary>
        /// Set this variable to time in milliseconds since start of game
        /// </summary>
        public TriggerAction SetToGameTimeMilliseconds()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 348
            };
        }

        /// <summary>
        /// Split this variable by a string value
        /// </summary>
        /// <param name="separator">String to split by</param>
        public TriggerAction SplitByString(string separator)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = separator,
                TriggerId = 349
            };
        }

        /// <summary>
        /// Split this variable by value of another variable
        /// </summary>
        /// <param name="separatorVariable">Variable containing separator</param>
        public TriggerAction SplitByVariable(Variable separatorVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = separatorVariable.Name,
                TriggerId = 399
            };
        }

        /// <summary>
        /// Get element at specified index from this array variable and store into this variable
        /// </summary>
        /// <param name="index">Index to get</param>
        public TriggerAction GetArrayElement(int index)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = index.ToString(),
                TriggerId = 350
            };
        }

        /// <summary>
        /// Add element to this array variable
        /// </summary>
        /// <param name="element">Element value to add</param>
        public TriggerAction AddArrayElement(string element)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = element,
                TriggerId = 352
            };
        }

        /// <summary>
        /// Add element from another variable to this array variable
        /// </summary>
        /// <param name="elementVariable">Variable containing element to add</param>
        public TriggerAction AddArrayElement(Variable elementVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = elementVariable.Name,
                TriggerId = 352
            };
        }

        /// <summary>
        /// Create array at this variable
        /// </summary>
        public TriggerAction CreateArray()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 354
            };
        }

        /// <summary>
        /// Skip next trigger action if this variable equals another variable
        /// </summary>
        /// <param name="otherVariable">Variable to compare with</param>
        public TriggerAction SkipNextIfEquals(Variable otherVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = otherVariable.Name,
                TriggerId = 361
            };
        }

        /// <summary>
        /// Switch execution to trigger ID stored in this variable
        /// </summary>
        public TriggerAction SwitchToTriggerInVariable()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 362
            };
        }

        /// <summary>
        /// Skip next trigger action if this variable is greater than another variable
        /// </summary>
        /// <param name="otherVariable">Variable to compare with</param>
        public TriggerAction SkipNextIfGreaterThan(Variable otherVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = otherVariable.Name,
                TriggerId = 364
            };
        }

        /// <summary>
        /// Skip next trigger action if this variable is less than another variable
        /// </summary>
        /// <param name="otherVariable">Variable to compare with</param>
        public TriggerAction SkipNextIfLessThan(Variable otherVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = otherVariable.Name,
                TriggerId = 365
            };
        }

        /// <summary>
        /// Set this variable to zoom of game camera
        /// </summary>
        public TriggerAction SetToGameCameraZoom()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 369
            };
        }

        /// <summary>
        /// Remove beginning characters from another variable
        /// </summary>
        /// <param name="characterCount">Number of characters to remove (can be negative to remove from end)</param>
        /// <param name="targetVariable">Variable to remove characters from</param>
        public TriggerAction RemoveBeginningCharacters(int characterCount, Variable targetVariable)
        {
            return new TriggerAction
            {
                ParameterA = characterCount.ToString(),
                ParameterB = targetVariable.Name,
                TriggerId = 372
            };
        }

        /// <summary>
        /// Set this variable to degrees between regions (separated by commas)
        /// </summary>
        /// <param name="regionsString">String with region UIDs separated by commas</param>
        public TriggerAction SetToDegreesBetweeenRegions(string regionsString)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = regionsString,
                TriggerId = 373
            };
        }

        /// <summary>
        /// Set this variable to stability of a character
        /// </summary>
        /// <param name="character">Character to get stability from</param>
        public TriggerAction SetToCharacterStability(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 376
            };
        }

        /// <summary>
        /// Set this variable to time in milliseconds since January 1 1970
        /// </summary>
        public TriggerAction SetToUnixTimestamp()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 393
            };
        }

        /// <summary>
        /// Set this variable to time between January 1 1970 and specified date in milliseconds
        /// </summary>
        /// <param name="dateVariable">Variable containing date (year, month, day)</param>
        public TriggerAction SetToTimeBetweenUnixAndDate(Variable dateVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = dateVariable.Name,
                TriggerId = 394
            };
        }

        /// <summary>
        /// Set this variable to 1 if mouse is held down, 0 otherwise
        /// </summary>
        public TriggerAction SetToMouseHeldDown()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 397
            };
        }

        /// <summary>
        /// Set this variable to distance between 2 regions (separated by commas)
        /// </summary>
        /// <param name="regionsString">String with region UIDs separated by commas</param>
        public TriggerAction SetToDistanceBetweenRegions(string regionsString)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = regionsString,
                TriggerId = 398
            };
        }

        /// <summary>
        /// Join this array variable by value of another variable
        /// </summary>
        /// <param name="separatorVariable">Variable containing separator</param>
        public TriggerAction JoinArrayByVariable(Variable separatorVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = separatorVariable.Name,
                TriggerId = 405
            };
        }

        /// <summary>
        /// Set this variable to active gun model of a character
        /// </summary>
        /// <param name="character">Character to get active gun model from</param>
        public TriggerAction SetToActiveGunModel(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 410
            };
        }

        /// <summary>
        /// Change character skin of slot-value in this variable to value of another variable
        /// </summary>
        /// <param name="skinVariable">Variable containing skin value</param>
        public TriggerAction ChangeCharacterSlotSkin(Variable skinVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = skinVariable.Name,
                TriggerId = 347
            };
        }

        /// <summary>
        /// Change head model of character slot-value in this variable to value of another variable
        /// </summary>
        /// <param name="modelVariable">Variable containing head model</param>
        public TriggerAction ChangeCharacterSlotHeadModel(Variable modelVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = modelVariable.Name,
                TriggerId = 356
            };
        }

        /// <summary>
        /// Change body model of character slot-value in this variable to value of another variable
        /// </summary>
        /// <param name="modelVariable">Variable containing body model</param>
        public TriggerAction ChangeCharacterSlotBodyModel(Variable modelVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = modelVariable.Name,
                TriggerId = 357
            };
        }

        /// <summary>
        /// Change arms model of character slot-value in this variable to value of another variable
        /// </summary>
        /// <param name="modelVariable">Variable containing arms model</param>
        public TriggerAction ChangeCharacterSlotArmsModel(Variable modelVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = modelVariable.Name,
                TriggerId = 358
            };
        }

        /// <summary>
        /// Set character slot-value in this variable color pattern to value of another variable
        /// </summary>
        /// <param name="colorPatternVariable">Variable containing color pattern (4 letters for body sections)</param>
        public TriggerAction SetCharacterSlotColorPattern(Variable colorPatternVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = colorPatternVariable.Name,
                TriggerId = 359
            };
        }

        /// <summary>
        /// Change legs model of character slot-value in this variable to value of another variable
        /// </summary>
        /// <param name="modelVariable">Variable containing legs model</param>
        public TriggerAction ChangeCharacterSlotLegsModel(Variable modelVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = modelVariable.Name,
                TriggerId = 360
            };
        }

        /// <summary>
        /// Set character slot-value in this variable zoom to value of another variable
        /// </summary>
        /// <param name="zoomVariable">Variable containing zoom value</param>
        public TriggerAction SetCharacterSlotZoom(Variable zoomVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = zoomVariable.Name,
                TriggerId = 370
            };
        }

        /// <summary>
        /// Set this variable to X speed of a character
        /// </summary>
        /// <param name="character">Character to get X speed from</param>
        public TriggerAction SetToCharacterXSpeed(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 425
            };
        }

        /// <summary>
        /// Set this variable to Y speed of a character
        /// </summary>
        /// <param name="character">Character to get Y speed from</param>
        public TriggerAction SetToCharacterYSpeed(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 426
            };
        }

        /// <summary>
        /// Set this variable to X speed of character slot-value in another variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public TriggerAction SetToCharacterSlotXSpeed(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slotVariable.Name,
                TriggerId = 427
            };
        }

        /// <summary>
        /// Set this variable to Y speed of character slot-value in another variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public TriggerAction SetToCharacterSlotYSpeed(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slotVariable.Name,
                TriggerId = 428
            };
        }

        /// <summary>
        /// Set this variable to overall speed of a character
        /// </summary>
        /// <param name="character">Character to get speed from</param>
        public TriggerAction SetToCharacterSpeed(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 434
            };
        }

        /// <summary>
        /// Set this variable to overall speed of character slot-value in another variable
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot</param>
        public TriggerAction SetToCharacterSlotSpeed(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slotVariable.Name,
                TriggerId = 435
            };
        }

        /// <summary>
        /// Set this variable to map ID of current game
        /// </summary>
        public TriggerAction SetToCurrentMapId()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 436
            };
        }

        /// <summary>
        /// Set this variable to value of chatting status (0 = off, 1 = chat, 2 = team chat)
        /// </summary>
        public TriggerAction SetToChattingStatus()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 463
            };
        }

        /// <summary>
        /// Set this variable to rotation of a gun
        /// </summary>
        /// <param name="gun">Gun to get rotation from</param>
        public TriggerAction SetToGunRotation(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 471
            };
        }

        /// <summary>
        /// Set this variable to X scale of a gun
        /// </summary>
        /// <param name="gun">Gun to get X scale from</param>
        public TriggerAction SetToGunXScale(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 472
            };
        }

        /// <summary>
        /// Set this variable to Y scale of a gun
        /// </summary>
        /// <param name="gun">Gun to get Y scale from</param>
        public TriggerAction SetToGunYScale(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 474
            };
        }

        /// <summary>
        /// Set this variable to active weapon of a character
        /// </summary>
        /// <param name="character">Character to get active weapon from</param>
        public TriggerAction SetToActiveWeapon(Character character)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = character.Uid,
                TriggerId = 484
            };
        }

        /// <summary>
        /// Set this variable to length of a gun
        /// </summary>
        /// <param name="gun">Gun to get length from</param>
        public TriggerAction SetToGunLength(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = gun.Uid,
                TriggerId = 509
            };
        }

        /// <summary>
        /// Set this variable to current framerate
        /// </summary>
        public TriggerAction SetToCurrentFramerate()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 510
            };
        }

        /// <summary>
        /// Set this variable to 1 if character slot-value in another variable is dying
        /// </summary>
        /// <param name="slotVariable">Variable containing character slot to check</param>
        public TriggerAction SetToCharacterSlotIsDying(Variable slotVariable)
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = slotVariable.Name,
                TriggerId = 544
            };
        }

        /// <summary>
        /// Get all active player slots and save result to this array variable
        /// </summary>
        public TriggerAction GetActivePlayerSlots()
        {
            return new TriggerAction
            {
                ParameterA = Name,
                ParameterB = "-1",
                TriggerId = 508
            };
        }



        public static TriggerAction operator +(Variable a, int value)
        {
            return a.Add(value);
        }
        public static TriggerAction operator +(Variable a, string value)
        {
            return a.Add(value);
        }
        public static TriggerAction operator +(Variable a, Variable b)
        {
            return a.Add(b);
        }


        public static TriggerAction operator *(Variable a, int value)
        {
            return a.Multiply(value);
        }
        public static TriggerAction operator *(Variable a, Variable b)
        {
            return a.Multiply(b);
        }

        public static TriggerAction operator ==(Variable a, int value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value.ToString(),
                TriggerId = 116
            };
        }

        public static TriggerAction operator !=(Variable a, int value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value.ToString(),
                TriggerId = 117
            };
        }

        public static TriggerAction operator ==(Variable a, string value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value,
                TriggerId = 116
            };
        }

        public static TriggerAction operator !=(Variable a, string value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value,
                TriggerId = 117
            };
        }

        public static TriggerAction operator <(Variable a, int value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value.ToString(),
                TriggerId = 115
            };
        }

        public static TriggerAction operator >(Variable a, int value)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = value.ToString(),
                TriggerId = 114
            };
        }

        public static TriggerAction operator ==(Variable a, Variable b)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = b.Name,
                TriggerId = 112
            };
        }

        public static TriggerAction operator !=(Variable a, Variable b)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = b.Name,
                TriggerId = 113
            };
        }

        public static TriggerAction operator <(Variable a, Variable b)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = b.Name,
                TriggerId = 111
            };
        }

        public static TriggerAction operator >(Variable a, Variable b)
        {
            return new TriggerAction
            {
                ParameterA = a.Name,
                ParameterB = b.Name,
                TriggerId = 110
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Variable other)
            {
                return Name == other.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }
    }
}
