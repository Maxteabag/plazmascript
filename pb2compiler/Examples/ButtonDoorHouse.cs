using PlazmaScript.Core;
using System;

namespace PlazmaScript.Examples
{
    public class ButtonDoorHouseMap
    {
        public static void CreateMap()
        {
            // Initialize the map
            PB2Map.Initialize();

            // ===================
            // TERRAIN & STRUCTURE 
            // ===================
            
            // Ground floor platform
            var groundFloor = new Box(-300, 150, 600, 100, WallMaterial.Concrete);
            
            // Simple house structure
            var leftWall = new Box(100, -100, 50, 250, WallMaterial.BrownConcrete);
            var rightWall = new Box(250, -100, 50, 250, WallMaterial.BrownConcrete);
            var backWall = new Box(150, -100, 100, 50, WallMaterial.BrownConcrete);
            var roof = new Box(100, -150, 200, 50, WallMaterial.DarkPlate);

            // ===================
            // DOOR SYSTEM
            // ===================
            
            // Movable door (blocks entrance)
            var door = new Moveable("#door", 150, 0, 50, 150);
            
            // Door target position (moves up when activated)
            var doorOpenRegion = new Region("#door_open", 150, -200, 50, 50);
            
            // ===================
            // BUTTON & TRIGGER SYSTEM
            // ===================
            
            // Door trigger
            var doorTrigger = new Trigger("#door_trigger");
            doorTrigger.X = 0;
            doorTrigger.Y = 0;
            doorTrigger.MaxCalls = 1;  // Single use
            doorTrigger.Actions.Add(door.MoveTo(doorOpenRegion));
            
            // Button region
            var buttonRegion = new Region("#button", 0, 100, 50, 30, ActivationTrigger.UseKeyWithButton, "#door_trigger");

            // ===================
            // PLAYER SPAWN
            // ===================
            
            // Player spawn point
            var player = new Player("#player", -150, 50);

            Console.WriteLine("Simple Button Door House map created!");
            Console.WriteLine("Features:");
            Console.WriteLine("- Press E on the button to open the door");
            Console.WriteLine("- Door moves up when button is pressed"); 
            Console.WriteLine($"- Total objects: {PB2Map.MapObjects.Count}");
        }
    }
}