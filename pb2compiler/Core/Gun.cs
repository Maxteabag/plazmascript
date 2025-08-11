using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public enum GunModel
    {
        AssaultRifleC01r,
        AssaultRifleC01rRed,
        PistolC01p,
        PistolC01pRed,
        PistolCSPro,
        VehicleRocketLauncherCorvette,
        GrenadeLauncherCSSpamThemBaby,
        RocketLauncherCSLitBro,
        LiteRailgunV01CSHShot,
        HeavyRailgunV04CSOneSOneK,
        ShotgunC01s,
        ShotgunC01sBlue,
        AlienPistol,
        AlienRifle,
        AlienShotgun,
        VehicleCannonHoundWalkerCS,
        Defibrillator,
        CSBNG,
        RayGunC01y,
        RayRifleTCoRR,
        VehicleMinigunDrone,
        VehicleGrenadeLauncherDrone,
        ShotgunCSDAZ,
        AssaultRifleCSRC,
        CombatRifleCSO,
        PlasmagunCSBloom,
        MinigunC02m,
        DroneGunCSVirus,
        SniperRifleCSYippeeKiYay,
        GrenadeC00n,
        TeleportGrenadeV03CSPortNade,
        PortableShieldV07CSQuarium,
        PortableShieldV07CSQuariumWeapon,
        GlockUnfinished,
        M4A1Unfinished,
        StarDefenderRifle,
        StarDefenderRocketLauncher,
        CPAssaultRifleDarkstar1,
        CSGaussRifleDarkstar1,
        LightMachineGunCSLMGDarkstar1,
        PHANX92FalconetDarkstar1,
        AlienSniperRifleDarkstar1,
        AssaultRifleAV135Lostmydollar,
        NeedleLostmydollar,
        QCcV50LittleBastardLostmydollar,
        RMK36Lostmydollar,
        RPGLostmydollar,
        AlienLaserRifleLazyRain,
        AlienHeaterRifleLazyRain,
        CSAutocannonLazyRainVehicle,
        CSAutocannonLazyRainHandheld,
        CrossfireCR45PhantomMoonhawk,
        CrossfireCR45PhantomDarkMoonhawk,
        CrossfireCR42GhostMoonhawk,
        EnergyRifleDitzy,
        FalkonianMarksmanRifleRoxxar,
        FalkonianPistolRoxxar,
        FalkonianShotgunRoxxar,
        FalkonianGrenadeLauncherRoxxar,
        CrossfireCR145VortexMoonhawk,
        FalkonianPSICutterLazyRain,
        AndroidSniperRifleMrJaksNes,
        OEDACR30RifleIncompetence,
        HeavySniperRifleRQ10Darkstar1,
        PBFTTPVehicleCannon,
        ShotgunNXS25Thetoppestkek,
        Archetype27XXIncompetence,
        MarksmanRifleCSRMPhsc,
        CrossfireCR34MarauderBrightMoonhawk,
        CrossfireCR34MarauderDarkMoonhawk,
        MedicPistolLazyRain,
        GrenadeLauncherCSGLHFIncompetence,
        OEDAEA109HLauncherIncompetence,
        FalkonianAntiGravityRocketLauncherYellowLazyRain,
        FalkonianAntiGravityRocketLauncherRedLazyRain,
        RocketLauncherCSBarrageDarkstar1,
        PlasmaShotgunPhsc,
        AndroidShotgunPhsc,
        AssaultRifleCSIKDitzy,
        AssaultRifleNXR17CDitzy,
        CrossfireCR54ViperPhsc,
        CrossfireCR54ViperV2Phsc,
        PHANX230CobraDarkstar1,
        EosToxicRailgunDarkstar1,
        AlienRailShotgunDarkstar1,
        GrenadeLauncherC00tDarkstar1,
        GrenadeLauncherC00tRedDarkstar1,
        EosRocketLauncherDarkstar1,
        PHANX150BisonDarkstar1,
        EosAutoShotgunDarkstar1,
        ReakhoshshaFocusBeamDitzy,
        RevolverMK1Boom5,
        ScavengerShotgunThetoppestkek,
        AlienAcidGrenadeLauncherLazyRain,
        AlienPlasmaPistolWhiteLazyRain,
        AlienPlasmaPistolYellowLazyRain,
        AndroidRailgunRoxxar,
        InvisibleGun,
        SharkDoesNothing
    }

    public class Gun : LinkedObject
    {
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

        /// <summary>
        /// Get the string identifier for a gun model
        /// </summary>
        /// <param name="model">Gun model</param>
        /// <returns>String identifier used in the game</returns>
        public static string GetGunModelString(GunModel model)
        {
            var gunModelDictionary = new Dictionary<GunModel, string> {
                { GunModel.AssaultRifleC01r, "gun_rifle" },
                { GunModel.AssaultRifleC01rRed, "gun_rifle_b" },
                { GunModel.PistolC01p, "gun_pistol" },
                { GunModel.PistolC01pRed, "gun_pistol_b" },
                { GunModel.PistolCSPro, "gun_pistol2" },
                { GunModel.VehicleRocketLauncherCorvette, "gun_vehgun" },
                { GunModel.GrenadeLauncherCSSpamThemBaby, "gun_gl" },
                { GunModel.RocketLauncherCSLitBro, "gun_rl" },
                { GunModel.LiteRailgunV01CSHShot, "gun_railgun" },
                { GunModel.HeavyRailgunV04CSOneSOneK, "gun_railgun2" },
                { GunModel.ShotgunC01s, "gun_shotgun" },
                { GunModel.ShotgunC01sBlue, "gun_shotgun_b" },
                { GunModel.AlienPistol, "gun_apistol" },
                { GunModel.AlienRifle, "gun_arifle" },
                { GunModel.AlienShotgun, "gun_arifle2" },
                { GunModel.VehicleCannonHoundWalkerCS, "gun_vehcannon" },
                { GunModel.Defibrillator, "gun_defibrillator" },
                { GunModel.CSBNG, "gun_bfg" },
                { GunModel.RayGunC01y, "gun_raygun" },
                { GunModel.RayRifleTCoRR, "gun_rayrifle" },
                { GunModel.VehicleMinigunDrone, "gun_vehminigun" },
                { GunModel.VehicleGrenadeLauncherDrone, "gun_vehminigl" },
                { GunModel.ShotgunCSDAZ, "gun_real_shotgun" },
                { GunModel.AssaultRifleCSRC, "gun_real_rifle" },
                { GunModel.CombatRifleCSO, "gun_oicw" },
                { GunModel.PlasmagunCSBloom, "gun_plasmagun" },
                { GunModel.MinigunC02m, "gun_minigun" },
                { GunModel.DroneGunCSVirus, "gun_vgun" },
                { GunModel.SniperRifleCSYippeeKiYay, "gun_sniper" },
                { GunModel.GrenadeC00n, "item_grenade" },
                { GunModel.TeleportGrenadeV03CSPortNade, "item_port" },
                { GunModel.PortableShieldV07CSQuarium, "item_shield" },
                { GunModel.PortableShieldV07CSQuariumWeapon, "gun_sp_sh" },
                { GunModel.GlockUnfinished, "gun_glock" },
                { GunModel.M4A1Unfinished, "gun_m4a1" },
                { GunModel.StarDefenderRifle, "gun_pixel_rifle" },
                { GunModel.StarDefenderRocketLauncher, "gun_pixel_rl" },
                { GunModel.CPAssaultRifleDarkstar1, "darkstar_1_assault_rifle" },
                { GunModel.CSGaussRifleDarkstar1, "darkstar_1_gauss_rifle" },
                { GunModel.LightMachineGunCSLMGDarkstar1, "darkstar_1_minigun" },
                { GunModel.PHANX92FalconetDarkstar1, "darkstar_1_phanx_rifle" },
                { GunModel.AlienSniperRifleDarkstar1, "darkstar_1_usniper" },
                { GunModel.AssaultRifleAV135Lostmydollar, "lostmydollar_av135" },
                { GunModel.NeedleLostmydollar, "lostmydollar_needle" },
                { GunModel.QCcV50LittleBastardLostmydollar, "lostmydollar_qccv50" },
                { GunModel.RMK36Lostmydollar, "lostmydollar_rmk36" },
                { GunModel.RPGLostmydollar, "lostmydollar_rpg" },
                { GunModel.AlienLaserRifleLazyRain, "lazyrain_alien_laser_rifle" },
                { GunModel.AlienHeaterRifleLazyRain, "lazyrain_alien_laser_rifle2" },
                { GunModel.CSAutocannonLazyRainVehicle, "lazyrain_cannon" },
                { GunModel.CSAutocannonLazyRainHandheld, "lazyrain_cannon2" },
                { GunModel.CrossfireCR45PhantomMoonhawk, "moonhawk_phantom" },
                { GunModel.CrossfireCR45PhantomDarkMoonhawk, "moonhawk_phantom2" },
                { GunModel.CrossfireCR42GhostMoonhawk, "moonhawk_smg" },
                { GunModel.EnergyRifleDitzy, "ditzy_energy_rifle" },
                { GunModel.FalkonianMarksmanRifleRoxxar, "roxxar_marksman_rifle" },
                { GunModel.FalkonianPistolRoxxar, "roxxar_pistol" },
                { GunModel.FalkonianShotgunRoxxar, "roxxar_rifle" },
                { GunModel.FalkonianGrenadeLauncherRoxxar, "roxxar_shotgun" },
                { GunModel.CrossfireCR145VortexMoonhawk, "moonhawk_crossfire" },
                { GunModel.FalkonianPSICutterLazyRain, "lazyrain_psi_cutter" },
                { GunModel.AndroidSniperRifleMrJaksNes, "mrjaksnes_android_sniper" },
                { GunModel.OEDACR30RifleIncompetence, "incompetence_cr30" },
                { GunModel.HeavySniperRifleRQ10Darkstar1, "darkstar_1_cs_ragequit" },
                { GunModel.PBFTTPVehicleCannon, "gun_fttp_vehgun" },
                { GunModel.ShotgunNXS25Thetoppestkek, "thetoppestkek_shotgun_nxs25" },
                { GunModel.Archetype27XXIncompetence, "incompetence_archetype_27xx" },
                { GunModel.MarksmanRifleCSRMPhsc, "phsc_aug" },
                { GunModel.CrossfireCR34MarauderBrightMoonhawk, "moonhawk_railgun" },
                { GunModel.CrossfireCR34MarauderDarkMoonhawk, "moonhawk_railgun2" },
                { GunModel.MedicPistolLazyRain, "lazyrain_heal_pistol" },
                { GunModel.GrenadeLauncherCSGLHFIncompetence, "incompetence_glhf" },
                { GunModel.OEDAEA109HLauncherIncompetence, "incompetence_glhf2" },
                { GunModel.FalkonianAntiGravityRocketLauncherYellowLazyRain, "lazyrain_gravy_rl" },
                { GunModel.FalkonianAntiGravityRocketLauncherRedLazyRain, "lazyrain_gravy_rl2" },
                { GunModel.RocketLauncherCSBarrageDarkstar1, "darkstar_1_owo_rl" },
                { GunModel.PlasmaShotgunPhsc, "phsc_plasma_shotgun" },
                { GunModel.AndroidShotgunPhsc, "phsc_android_shotgun" },
                { GunModel.AssaultRifleCSIKDitzy, "ditzy_cs_ik" },
                { GunModel.AssaultRifleNXR17CDitzy, "ditzy_cs_ik2" },
                { GunModel.CrossfireCR54ViperPhsc, "phsc_ph01" },
                { GunModel.CrossfireCR54ViperV2Phsc, "phsc_ph01b" },
                { GunModel.PHANX230CobraDarkstar1, "darkstar_1_railgun" },
                { GunModel.EosToxicRailgunDarkstar1, "darkstar_1_railgun2" },
                { GunModel.AlienRailShotgunDarkstar1, "darkstar_1_alien_rail_sg" },
                { GunModel.GrenadeLauncherC00tDarkstar1, "darkstar_1_nade_c9" },
                { GunModel.GrenadeLauncherC00tRedDarkstar1, "darkstar_1_nade_c9b" },
                { GunModel.EosRocketLauncherDarkstar1, "darkstar_1_rl" },
                { GunModel.PHANX150BisonDarkstar1, "darkstar_1_bison" },
                { GunModel.EosAutoShotgunDarkstar1, "darkstar_1_auto_sg" },
                { GunModel.ReakhoshshaFocusBeamDitzy, "ditzy_focus_beam" },
                { GunModel.RevolverMK1Boom5, "boom5_revolver" },
                { GunModel.ScavengerShotgunThetoppestkek, "thetoppestkek_scavenger_sg" },
                { GunModel.AlienAcidGrenadeLauncherLazyRain, "lazyrain_acid_gl" },
                { GunModel.AlienPlasmaPistolWhiteLazyRain, "lazyrain_plasma_smg" },
                { GunModel.AlienPlasmaPistolYellowLazyRain, "lazyrain_plasma_smg2" },
                { GunModel.AndroidRailgunRoxxar, "roxxar_android_railgun" },
                { GunModel.InvisibleGun, "gun_invisgun" },
                { GunModel.SharkDoesNothing, "gun_sharkgun" }
            };

            return gunModelDictionary.TryGetValue(model, out string value) ? value : "gun_rifle";
        }

        public override XElement CreateXmlElement()
        {
            var element = new XElement("gun");

            //TODO: More teams?
            var gunTeamDictionary = new Dictionary<GunTeam, string> {
                { GunTeam.Any, "-1" },
            };

            var gunModel = GetGunModelString(Model);
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

        /// <summary>
        /// Set this gun's projectile scale to value
        /// </summary>
        /// <param name="scale">Projectile scale value</param>
        public TriggerAction SetProjectileScale(double scale)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = scale.ToString(),
                TriggerId = 301
            };
        }

        /// <summary>
        /// Set this gun's projectile scale to value of variable
        /// </summary>
        /// <param name="scaleVariable">Variable containing projectile scale</param>
        public TriggerAction SetProjectileScale(Variable scaleVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = scaleVariable.Name,
                TriggerId = 302
            };
        }

        /// <summary>
        /// Set this gun's arm 1 hold offset (0..1)
        /// </summary>
        /// <param name="offset">Arm 1 hold offset (0..1)</param>
        public TriggerAction SetArm1HoldOffset(double offset)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = offset.ToString(),
                TriggerId = 303
            };
        }

        /// <summary>
        /// Set this gun's arm 2 hold offset (0..1)
        /// </summary>
        /// <param name="offset">Arm 2 hold offset (0..1)</param>
        public TriggerAction SetArm2HoldOffset(double offset)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = offset.ToString(),
                TriggerId = 304
            };
        }

        /// <summary>
        /// Set this gun's holstered attachment (0 = on leg, 1 = on back)
        /// </summary>
        /// <param name="attachment">Attachment type (0 = on leg, 1 = on back)</param>
        public TriggerAction SetHolsteredAttachment(int attachment)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = attachment.ToString(),
                TriggerId = 305
            };
        }

        /// <summary>
        /// Set this gun's length to value
        /// </summary>
        /// <param name="length">Gun length value</param>
        public TriggerAction SetLength(double length)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = length.ToString(),
                TriggerId = 306
            };
        }

        /// <summary>
        /// Assign sound as firing sound for this weapon
        /// </summary>
        /// <param name="soundName">Name of the sound to assign</param>
        public TriggerAction SetFiringSound(string soundName)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = soundName,
                TriggerId = 260
            };
        }

        /// <summary>
        /// Override existing Gun with a new gun with model
        /// </summary>
        /// <param name="newModel">New gun model name</param>
        public TriggerAction OverrideWithModel(string newModel)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = newModel,
                TriggerId = 287
            };
        }
    }
}
