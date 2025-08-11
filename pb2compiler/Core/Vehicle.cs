using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static PlazmaScript.Program;

namespace PlazmaScript.Core
{
    public enum VehicleModel
    {
        Jeep,
        Walker,
        Capsule,
        Crate,
        Drone,
        Rope,
        Corvette
    }

    public enum VehicleSide
    {
        Any = -1,
        Neutral = 0,
        Blue = 1,
        Red = 2
    }

    public class Vehicle : LinkedObject
    {
        public VehicleSide Side { get; set; } = VehicleSide.Blue;
        public VehicleModel Model { get; set; } = VehicleModel.Jeep;
        public int TargetX { get; set; } = 0;
        public int TargetY { get; set; } = 0;
        public int HitPointsPercentage { get; set; } = 100;

        public Vehicle(string uid, int x, int y, VehicleModel model = VehicleModel.Jeep, VehicleSide side = VehicleSide.Blue)
        {
            // Automatically add # prefix if not present
            if (!uid.StartsWith("#"))
            {
                uid = "#" + uid;
            }
            
            Uid = uid;
            X = x;
            Y = y;
            Model = model;
            Side = side;
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Set the vehicle's hit points to a percentage (0-100)
        /// </summary>
        /// <param name="percentage">Hit points percentage</param>
        public TriggerAction SetHitPoints(int percentage)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = percentage.ToString(),
                TriggerId = 3
            };
        }


        public override XElement CreateXmlElement()
        {
            var vehicleElement = new XElement("vehicle");
            
            // Map model enum to XML string values
            var modelMap = new Dictionary<VehicleModel, string>
            {
                { VehicleModel.Jeep, "veh_jeep" },
                { VehicleModel.Walker, "veh_walker" },
                { VehicleModel.Capsule, "veh_capsule" },
                { VehicleModel.Crate, "veh_crate" },
                { VehicleModel.Drone, "veh_drone" },
                { VehicleModel.Rope, "veh_rope" },
                { VehicleModel.Corvette, "veh_corvette" }
            };

            vehicleElement.SetAttributeValue("uid", Uid);
            vehicleElement.SetAttributeValue("side", ((int)Side).ToString());
            vehicleElement.SetAttributeValue("model", modelMap[Model]);
            vehicleElement.SetAttributeValue("x", X.ToString());
            vehicleElement.SetAttributeValue("y", Y.ToString());
            vehicleElement.SetAttributeValue("tox", TargetX.ToString());
            vehicleElement.SetAttributeValue("toy", TargetY.ToString());
            vehicleElement.SetAttributeValue("hpp", HitPointsPercentage.ToString());
            
            return vehicleElement;
        }
    }
}