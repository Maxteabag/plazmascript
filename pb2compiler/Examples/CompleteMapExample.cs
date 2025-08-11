using PlazmaScript.Core;
using System;

namespace PlazmaScript.Examples
{
    public class CompleteMapExample
    {
        public CompleteMapExample()
        {
            // Create player
            var mainPlayer = new Player("player*1", 100, 200);

            // Create setup trigger that runs at map start
            var mapSetup = new Trigger("map_setup", true); // ExecuteAtStart = true
            
            // Set gravity using proper trigger action
            mapSetup.AddAction(PB2Map.SetGravity(0.5));

            // Build a simple house out of wall objects (Box elements)
            // House foundation/floor
            var houseFloor = new Box(0, 300, 400, 20);
            
            // House walls
            var leftWall = new Box(0, 200, 20, 100);    // Left wall
            var rightWall = new Box(380, 200, 20, 100); // Right wall
            var backWall = new Box(20, 200, 360, 20);   // Back wall
            
            // House roof
            var roof = new Box(0, 180, 400, 20);
            
            // Door opening (gap in front wall)
            var frontWallLeft = new Box(20, 280, 140, 20);  // Left part of front wall
            var frontWallRight = new Box(240, 280, 140, 20); // Right part of front wall
            // Gap between x=160 and x=240 serves as door opening
            
            // Ground platform for player to walk on
            var ground = new Box(-100, 350, 600, 50);

            Console.WriteLine("🏠 Simple house built with wall objects!");
            Console.WriteLine($"👤 Player: {mainPlayer.Uid}");
            Console.WriteLine($"🧱 House made of {PB2Map.MapObjects.Count - 3} wall segments"); // -3 for player, init trigger, and timer
            Console.WriteLine($"📦 Total map objects: {PB2Map.MapObjects.Count}");
        }
    }
}