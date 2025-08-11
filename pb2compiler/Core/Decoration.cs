using System.Xml.Linq;

namespace PlazmaScript.Core
{
    public enum DecorationType
    {
        Stone,
        SmallStone,
        BrokenShip,
        FloorGravitator,
        OnWallGravitatorRight,
        OnWallGravitatorLeft,
        FloorTeleport,
        CeilTeleport,
        DisabledFloorTeleport,
        DisabledCeilTeleport,
        LeftKillingRay,
        RightKillingRay,
        CeilKillingRay,
        FloorKillingRay,
        Nothing,
        DisabledFloorGravitator,
        IncomingOnceAnimatedShip,
        WideTeleportDisabled,
        WideTeleportEnabled,
        PixelDoor,
        PixelDoorClosed,
        PixelTeleport,
        WallLampRightOff,
        WallLampRightOn,
        WallLampLeftOff,
        WallLampLeftOn,
        WallLampUpOff,
        WallLampUpOn,
        WallLampDownOff,
        WallLampDownOn,
        BackLampVerticalOff,
        BackLampVerticalOn,
        BackLampHorizontalOff,
        BackLampHorizontalOn,
        RedColumn,
        GreenColumn,
        BlueColumn,
        MinedBarrel,
        Machine,
        MachineDestroyed,
        TextPlaceholderOverhead,
        TextPlaceholderScore,
        TextPlaceholderChat,
        WallCameraLeft,
        WallCameraRight,
        FlagBlue,
        FlagRed,
        FlagDark,
        FlagEmpty,
        HealingKit,
        HologramStandEnabledBlue,
        HologramStandEnabledRed,
        HologramStandDisabled,
        HologramOfEarth,
        HologramOfC9Logo,
        OrangeBarrelDecoration,
        BlueBarrelDecoration,
        RedBarrelDecoration,
        FTTPVehicleRight,
        FTTPVehicleLeft,
        FTTPVehicleWheel,
        FTTPDrone,
        XXFRapierIdleRight,
        XXFRapierActiveRight,
        XXFRapierIdleLeft,
        XXFRapierActiveLeft,
        FalkokShipIdlePilotlessRight,
        FalkokShipIdlePilotedRight,
        FalkokShipActivePilotedRight,
        FalkokShipIdlePilotlessLeft,
        FalkokShipIdlePilotedLeft,
        FalkokShipActivePilotedLeft,
        Crate,
        WeaponCrate,
        PortableFissionChamber,
        PortableFissionChamberDebris,
        CeilingCamera,
        StorageLocker,
        StorageLockerDamaged,
        StorageLockerOpen,
        TreeSmall,
        TreeMedium,
        Pot,
        TreeInPotSmall,
        TreeInPotMedium
    }

    public class Decoration : LinkedObject
    {
        public DecorationType Type { get; set; }

        public Decoration(string uid, int x, int y, DecorationType type = DecorationType.Stone)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Uid = uid;
            X = x;
            Y = y;
            Type = type;
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Get the string identifier for a decoration type
        /// </summary>
        /// <param name="type">Decoration type</param>
        /// <returns>String identifier used in the game</returns>
        public static string GetDecorationString(DecorationType type)
        {
            return type switch
            {
                DecorationType.Stone => "stone",
                DecorationType.SmallStone => "stone2",
                DecorationType.BrokenShip => "ship",
                DecorationType.FloorGravitator => "antigravity",
                DecorationType.OnWallGravitatorRight => "antigravity_right",
                DecorationType.OnWallGravitatorLeft => "antigravity_left",
                DecorationType.FloorTeleport => "teleport",
                DecorationType.CeilTeleport => "teleport2",
                DecorationType.DisabledFloorTeleport => "teleport_x",
                DecorationType.DisabledCeilTeleport => "teleport2_x",
                DecorationType.LeftKillingRay => "ray_left",
                DecorationType.RightKillingRay => "ray_right",
                DecorationType.CeilKillingRay => "ray_ceil",
                DecorationType.FloorKillingRay => "ray_floor",
                DecorationType.Nothing => "null",
                DecorationType.DisabledFloorGravitator => "antigravity0",
                DecorationType.IncomingOnceAnimatedShip => "ship_noir",
                DecorationType.WideTeleportDisabled => "final_place",
                DecorationType.WideTeleportEnabled => "final_place2",
                DecorationType.PixelDoor => "pixel_door",
                DecorationType.PixelDoorClosed => "pixel_door2",
                DecorationType.PixelTeleport => "pixel_teleport",
                DecorationType.WallLampRightOff => "wall_lamp_right",
                DecorationType.WallLampRightOn => "wall_lamp_right_on",
                DecorationType.WallLampLeftOff => "wall_lamp_left",
                DecorationType.WallLampLeftOn => "wall_lamp_left_on",
                DecorationType.WallLampUpOff => "wall_lamp_up",
                DecorationType.WallLampUpOn => "wall_lamp_up_on",
                DecorationType.WallLampDownOff => "wall_lamp_down",
                DecorationType.WallLampDownOn => "wall_lamp_down_on",
                DecorationType.BackLampVerticalOff => "back_lamp_vertical",
                DecorationType.BackLampVerticalOn => "back_lamp_vertical_on",
                DecorationType.BackLampHorizontalOff => "back_lamp_horizontal",
                DecorationType.BackLampHorizontalOn => "back_lamp_horizontal_on",
                DecorationType.RedColumn => "column_red",
                DecorationType.GreenColumn => "column_green",
                DecorationType.BlueColumn => "column_blue",
                DecorationType.MinedBarrel => "mined_barrel",
                DecorationType.Machine => "darkstar_device",
                DecorationType.MachineDestroyed => "darkstar_device_destroyed",
                DecorationType.TextPlaceholderOverhead => "text",
                DecorationType.TextPlaceholderScore => "text2",
                DecorationType.TextPlaceholderChat => "text3",
                DecorationType.WallCameraLeft => "darkstar_camera_left",
                DecorationType.WallCameraRight => "darkstar_camera_right",
                DecorationType.FlagBlue => "ditzy_flag_blue",
                DecorationType.FlagRed => "ditzy_flag_red",
                DecorationType.FlagDark => "ditzy_flag_dark",
                DecorationType.FlagEmpty => "ditzy_flag_empty",
                DecorationType.HealingKit => "darkstar_healing_kit",
                DecorationType.HologramStandEnabledBlue => "darkstar_holo_on",
                DecorationType.HologramStandEnabledRed => "darkstar_holo_on_red",
                DecorationType.HologramStandDisabled => "darkstar_holo_off",
                DecorationType.HologramOfEarth => "darkstar_holo_earth",
                DecorationType.HologramOfC9Logo => "darkstar_holo_c9",
                DecorationType.OrangeBarrelDecoration => "static_barrel1",
                DecorationType.BlueBarrelDecoration => "static_barrel2",
                DecorationType.RedBarrelDecoration => "static_barrel3",
                DecorationType.FTTPVehicleRight => "fttp_vehicle",
                DecorationType.FTTPVehicleLeft => "fttp_vehicle2",
                DecorationType.FTTPVehicleWheel => "fttp_wheel",
                DecorationType.FTTPDrone => "fttp_drone",
                DecorationType.XXFRapierIdleRight => "doomwrath_rapier_idle",
                DecorationType.XXFRapierActiveRight => "doomwrath_rapier_active",
                DecorationType.XXFRapierIdleLeft => "doomwrath_rapier_idle2",
                DecorationType.XXFRapierActiveLeft => "doomwrath_rapier_active2",
                DecorationType.FalkokShipIdlePilotlessRight => "falkok_ship1",
                DecorationType.FalkokShipIdlePilotedRight => "falkok_ship2",
                DecorationType.FalkokShipActivePilotedRight => "falkok_ship3",
                DecorationType.FalkokShipIdlePilotlessLeft => "falkok_ship4",
                DecorationType.FalkokShipIdlePilotedLeft => "falkok_ship5",
                DecorationType.FalkokShipActivePilotedLeft => "falkok_ship6",
                DecorationType.Crate => "darkstar_crate",
                DecorationType.WeaponCrate => "darkstar_weapon_crate",
                DecorationType.PortableFissionChamber => "darkstar_portable_fission",
                DecorationType.PortableFissionChamberDebris => "darkstar_portable_fission_brk",
                DecorationType.CeilingCamera => "darkstar_ceiling_camera",
                DecorationType.StorageLocker => "doomzerker_locker",
                DecorationType.StorageLockerDamaged => "doomzerker_locker2",
                DecorationType.StorageLockerOpen => "doomzerker_locker3",
                DecorationType.TreeSmall => "darkstar_tree1",
                DecorationType.TreeMedium => "darkstar_tree2",
                DecorationType.Pot => "darkstar_pot",
                DecorationType.TreeInPotSmall => "darkstar_pot_tree1",
                DecorationType.TreeInPotMedium => "darkstar_pot_tree2",
                _ => "stone"
            };
        }

        /// <summary>
        /// Attach this decoration to current player's camera
        /// </summary>
        /// <param name="cameraPosition">Camera position part (left, center, etc.)</param>
        public TriggerAction AttachToPlayerCamera(string cameraPosition)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = cameraPosition,
                TriggerId = 343
            };
        }

        /// <summary>
        /// Change top-left position of this decoration to top-left position of a region
        /// </summary>
        /// <param name="region">Region to move to</param>
        public TriggerAction MoveToRegion(Region region)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = region.Uid,
                TriggerId = 345
            };
        }

        /// <summary>
        /// Set this decoration's X scale using a variable
        /// </summary>
        /// <param name="scaleVariable">Variable containing X scale value</param>
        public TriggerAction SetXScale(Variable scaleVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = scaleVariable.Name,
                TriggerId = 466
            };
        }

        /// <summary>
        /// Set this decoration's Y scale using a variable
        /// </summary>
        /// <param name="scaleVariable">Variable containing Y scale value</param>
        public TriggerAction SetYScale(Variable scaleVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = scaleVariable.Name,
                TriggerId = 467
            };
        }

        /// <summary>
        /// Change this decoration's blend mode
        /// </summary>
        /// <param name="blendMode">Blend mode value</param>
        public TriggerAction ChangeBlendMode(string blendMode)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = blendMode,
                TriggerId = 478
            };
        }

        /// <summary>
        /// Set decoration color matrix to array (4x5 items)
        /// </summary>
        /// <param name="matrixArray">Array variable containing color matrix</param>
        public TriggerAction SetColorMatrix(Variable matrixArray)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = matrixArray.Name,
                TriggerId = 408
            };
        }

        /// <summary>
        /// Move, rotate and flip this decoration to position of a vehicle
        /// </summary>
        /// <param name="vehicle">Vehicle to align with</param>
        public TriggerAction AlignWithVehicle(Vehicle vehicle)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = vehicle.Uid,
                TriggerId = 437
            };
        }

        /// <summary>
        /// Move, rotate and flip this decoration to a barrel
        /// </summary>
        /// <param name="barrel">Barrel to align with</param>
        public TriggerAction AlignWithBarrel(Barrel barrel)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = barrel.Uid,
                TriggerId = 462
            };
        }

        /// <summary>
        /// Mask this Decoration with another Decoration (Flash Player only)
        /// </summary>
        /// <param name="maskDecoration">Decoration to use as mask</param>
        public TriggerAction MaskWithDecoration(Decoration maskDecoration)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = maskDecoration.Uid,
                TriggerId = 293
            };
        }

        /// <summary>
        /// Set this decoration visibility multiplier to value (0...1)
        /// </summary>
        /// <param name="visibility">Visibility multiplier (0...1)</param>
        public TriggerAction SetVisibilityMultiplier(double visibility)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = visibility.ToString(),
                TriggerId = 298
            };
        }

        /// <summary>
        /// Set this decoration visibility multiplier to value of variable (0...1)
        /// </summary>
        /// <param name="visibilityVariable">Variable containing visibility multiplier</param>
        public TriggerAction SetVisibilityMultiplier(Variable visibilityVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = visibilityVariable.Name,
                TriggerId = 299
            };
        }

        /// <summary>
        /// Move, rotate and flip this Decoration to position of Gun
        /// </summary>
        /// <param name="gun">Gun to align with</param>
        public TriggerAction AlignWithGun(Gun gun)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = gun.Uid,
                TriggerId = 300
            };
        }

        public override XElement CreateXmlElement()
        {
            var decorationElement = new XElement("decoration");
            decorationElement.SetAttributeValue("uid", Uid);
            decorationElement.SetAttributeValue("model", GetDecorationString(Type));
            decorationElement.SetAttributeValue("x", X.ToString());
            decorationElement.SetAttributeValue("y", Y.ToString());
            return decorationElement;
        }
    }
}