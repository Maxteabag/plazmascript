using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlazmaScript.Examples
{

    public class MMoGuns
    {

        public List<MMoGunData> Guns { get; set; } = new List<MMoGunData>();

        public MMoGuns()
        {
            var gunResponse = new Variable("guns_response");
            var currentSlot = new Variable("current_slot");

            AddGunToList("Defibrillator", 6);
            AddGunToList("C-01R", 2);
            AddGunToList("C-01S", 3);
            AddGunToList("CS-LitBro", 5);
            AddGunToList("Heater", 2);
            AddGunToList("RPG", 5);
            AddGunToList("AV-135", 2);
            AddGunToList("Needle", 4);
            AddGunToList("ASR", 7);
            AddGunToList("FK-S", 3);
            AddGunToList("CS-Hitmark", 4);
            AddGunToList("Star defender rifle", 2);
            AddGunToList("CP-AR", 2);
            AddGunToList("CS-OICW", 2);
            AddGunToList("CS-DAZ", 3);
            AddGunToList("CS-Bloom", 8);
            AddGunToList("C-01Y", 9);


            var mmoGuns = new MMOGun(Guns, gunResponse, currentSlot);
        }

        private void AddGunToList(string key, int slot)
        {
            var defib = new MMoGunData
            {
                Key = key,
                Slot = slot
            };

            Guns.Add(defib);
        }
    }

    public class MMoGunData
    {
        public string Key { get; set; }
        public int Slot { get; set; }
        public int Speed { get; internal set; }
        public int Power { get; internal set; }
        public int Recoil { get; internal set; }

        public string GetGunId()
        {



            switch (Key)
            {
                case "Defibrillator":
                    return "gun_defibrillator";
                case "C-01R":
                    return "gun_rifle";
                case "C-01S":
                    return "gun_shotgun_b";
                case "Cs-LitBro":
                    return "gun_rl";
                case "Heater":
                    return "lazyrain_alien_laser_rifle";
                case "RPG":
                    return "lostmydollar_rpg";
                case "AV-135":
                    return "lostmydollar_av135";
                case "Needle":
                    return "lostmydollar_needle";
                case "ASR":
                    return "darkstar_1_usniper";
                case "FK-S":
                    return "roxxar_rifle";
                case "CS-Hitmark":
                    return "gun_sniper";
                case "Star defender rifle":
                    return "gun_pixel_rifle";
                case "CP-AR":
                    return "darkstar_1_assault_rifle";
                case "CS-OICW":
                    return "gun_iocw";
                case "CS-DAZ":
                    return "gun_real_shotgun";
                case "CS-Bloom":
                    return "gun_plasmagun";
                case "C-01Y":
                    return "gun_raygun";

                default:
                    return "-1";

            }
        }
    }

    public class MMOGun
    {

        class GunSlotData
        {
            public Gun Gun { get; set; }
            public Variable HasGun { get; set; }
            public int Slot { get; set; }
        }
        public MMOGun(List<MMoGunData> gunDataList, Variable gunResponse, Variable currentSlot)
        {

            //META-GUN LOGIC
            /*
             * 
             //3) Sync all them variables when finished loading... (This is in level editor - just connect things once loaded)
             //3.5) Clear boolean ("hasSlot2") for instance (Thiscan also be just in level editor - TBH)
             * 
             */

            var spawnGunEntryPoint = new Trigger();
            spawnGunEntryPoint.X = 100;
            spawnGunEntryPoint.Y = 100;



            var allGunSlotData = new List<GunSlotData>();



            for (int i = 2; i < 10; i++)
            {
                var gun = new Gun(GunModel.InvisibleGun);
                var weHaveGunSlot = new Variable("hasSlot_" + i);
                allGunSlotData.Add(new GunSlotData
                {
                    Gun = gun,
                    HasGun = weHaveGunSlot,
                    Slot = i
                });
            }


            //PER PLAYER
            for (int playerSlot = 0; playerSlot < 8; playerSlot++)
            {
                var gunDeactivator = new Trigger();

                var gunActivator = new Trigger();



                var checkIfPlayerIsDead = new Trigger();
                var playerHp = new Variable();


                checkIfPlayerIsDead.AddAction(playerHp.SetToPlayerHp(GetPlayerIdBasedOnSlot(playerSlot)));
                checkIfPlayerIsDead.ContinueIf(playerHp < 1);
                checkIfPlayerIsDead.SetVariable("playerIsZero" + playerSlot, "true");
                checkIfPlayerIsDead.Execute(gunDeactivator);

                //Continually check if player is dead...
                var timer = new Timer()
                {
                    LaunchedOnStart = true,
                    Delay = 30,
                    MaxCalls = MaxCalls.INFINITE,
                    Target = checkIfPlayerIsDead
                };


                var ticker = new Timer()
                {
                    LaunchedOnStart = false,
                    MaxCalls = MaxCalls.INFINITE,
                    Target = gunActivator,
                    Delay = 10
                };

                var checkIfPlayerIsAlive = new Trigger();
                checkIfPlayerIsDead.AddAction(playerHp.SetToPlayerHp(GetPlayerIdBasedOnSlot(playerSlot)));
                checkIfPlayerIsDead.ContinueIf(playerHp > 0);
                checkIfPlayerIsDead.AddAction(ticker.SetRemainingCalls(1));
                checkIfPlayerIsDead.AddAction(ticker.Activate());

                //Continually check if player is alive...
                var aliveChecker = new Timer()
                {
                    LaunchedOnStart = false,
                    Delay = 10,
                    MaxCalls = MaxCalls.INFINITE,
                    Target = checkIfPlayerIsAlive
                };


                foreach (var gunSlotData in allGunSlotData)
                {
                    gunDeactivator.AddAction(gunSlotData.Gun.AllowForVehicles());
                    gunDeactivator.AddAction(gunSlotData.Gun.MoveToRegion("#BEGONE"));

                    gunActivator.AddAction(gunSlotData.Gun.AllowForCharacters());
                    gunActivator.ContinueIf(currentSlot == playerSlot);

                    var isZeroVariable = new Variable("playerIsZero" + playerSlot);
                    gunActivator.ContinueIf(isZeroVariable == "true"); //Has the player been killed before?
                    //Executing trigger that already exists on map
                    gunActivator.Execute("#UNIVERSAL_DEATH");
                    gunActivator.AddAction(isZeroVariable.SetValue("false"));
                    gunActivator.Execute("#trigger*259");
                }


            }

            var loadGunEntryPoint = new Trigger();


            //PER GUN DATA LOGIC
            foreach (var gunData in gunDataList)
            {

                //Local variable


                var gunTester = new Trigger();
                loadGunEntryPoint.Execute(gunTester);

                var gunSlotData = allGunSlotData.Where(x => x.Slot == gunData.Slot).FirstOrDefault();

                gunTester.ContinueIf(gunResponse.Contains(gunData.Key));

                for (int i = 0; i < 8; i++)
                {
                    var playerGunSlotWeaponModel = new Variable("player_" + i + "_slot" + gunData.Slot);


                    //Loading
                    var setPlayerGunSlotModelBasedOnSlot = new Trigger();
                    setPlayerGunSlotModelBasedOnSlot.ContinueIf(currentSlot == i);
                    setPlayerGunSlotModelBasedOnSlot.AddAction(gunSlotData.HasGun.SetValue("true"));
                    setPlayerGunSlotModelBasedOnSlot.SetVariable(playerGunSlotWeaponModel, gunData.GetGunId());
                    setPlayerGunSlotModelBasedOnSlot.AddAction(playerGunSlotWeaponModel.Sync());

                    gunTester.Execute(setPlayerGunSlotModelBasedOnSlot);
                    setPlayerGunSlotModelBasedOnSlot.Y += i * 30;



                    //Upgrading...
                    var gunModifications = new Trigger();
                    gunModifications.ContinueIf(playerGunSlotWeaponModel == gunData.GetGunId());
                    if (gunData.Speed != 0)
                    {
                        gunModifications.AddAction(gunSlotData.Gun.SetSpeedMultiplier(gunData.Speed));
                    }
                    if (gunData.Recoil != 0)
                    {
                        gunModifications.AddAction(gunSlotData.Gun.SetSpeedMultiplier(gunData.Speed));
                    }
                    if (gunData.Power != 0)
                    {
                        gunModifications.AddAction(gunSlotData.Gun.SetSpeedMultiplier(gunData.Speed));
                    }

                }

                //Moving guns is per gunData...
                spawnGunEntryPoint.AddAction(gunSlotData.HasGun.SkipNextActionIfNotEquals("true"));
                spawnGunEntryPoint.AddAction(gunSlotData.Gun.MoveToRegion("#GUNPOS"));

            }


        }

        public string GetPlayerIdBasedOnSlot(int slot)
        {
            switch (slot)
            {
                case 0:
                    return "#player";
                case 1:
                    return "#player*1";
                case 2:
                    return "#player*2";
                case 3:
                    return "#player*3";
                case 4:
                    return "#player*6";
                case 5:
                    return "#player*4";
                case 6:
                    return "#player*8";
                case 7:
                    return "#player*5";
                default:
                    return "-1";
            }
        }
    }
}
