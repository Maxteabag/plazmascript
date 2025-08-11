using PlazmaScript.Core;
using System;

namespace PlazmaScript.Examples
{
    public class CompleteMapExample
    {
        public CompleteMapExample()
        {
            // Set map environment properties
            PB2Map.Gravity = 0.4;  // Lower gravity

            // Create players and enemies with proper PB2 attributes
            var mainPlayer = new Player("#player*1", -430, -510);
            mainPlayer.Health = 130;
            mainPlayer.MaxHealth = 130;
            mainPlayer.Side = 1; // Blue team

            var ally1 = new Enemy("#actor*1", -450, -240, 1); // Blue team ally
            var enemy1 = new Enemy("#actor*2", -510, -220, -1); // Red team enemy
            var ally2 = new Enemy("#actor*4", -370, -290, 1, 1); // Blue team with bot action
            var ally3 = new Enemy("#actor*5", -140, -310, 1, 3); // Blue team with different bot action

            // Create map objects
            var barrel = new Barrel("#barrel*1", -380, -230, BarrelModel.Orange);
            var water1 = new Water("#water*1", -280, -180, 40, 110, 0); // Safe water
            var water2 = new Water("#water*2", -250, -220, 130, 40, 0, false); // No friction water
            var acidWater = new Water("#water*4", -180, -130, 30, 50, 30); // Damaging water

            // Create solid geometry
            var platform = new Box(-540, -470, 290, 60);
            var wall = new Box(-640, -330, 30, 150);

            // Create interactive elements
            var door = new Door("#door*1", -550, -200, 210, 190);
            var decoration = new Decor("#decor*1", -290, -310, DecorModel.Stone);

            // Create regions
            var spawnArea = new Region("#region*1", -760, -430, 80, 140);

            // Engine marks for map configuration
            var casualMode = EngineMarks.EnableCasualMode();
            casualMode.X = -700;
            casualMode.Y = -120;

            var gameScale = EngineMarks.GameScale(90);
            gameScale.X = -720;
            gameScale.Y = -220;

            var changeSky = EngineMarks.ChangeSky();
            changeSky.X = -720;
            changeSky.Y = -170;

            var heGrenades = EngineMarks.HEGrenadesCount(15);
            heGrenades.X = -770;
            heGrenades.Y = -180;

            var enableSnow = EngineMarks.EnableSnow();
            enableSnow.X = -650;
            enableSnow.Y = 20;

            var waterColor = EngineMarks.WaterColor("#FFFFFF");
            waterColor.X = -590;
            waterColor.Y = 20;

            var customWaterColor = EngineMarks.WaterColor("#FF00FF");
            customWaterColor.X = -650;
            customWaterColor.Y = 50;

            var acidColor = EngineMarks.AcidColor("#FF00FF");
            acidColor.X = 200;
            acidColor.Y = -240;

            // Set up game logic with triggers
            var gameSetup = new Trigger("game_setup");
            gameSetup.AddAction(mainPlayer.SetHealth(130));
            gameSetup.AddAction(ally1.SetHealth(130));
            gameSetup.AddAction(enemy1.SetHealth(130));

            Console.WriteLine("🗺️  Complete map created with PB2-compatible elements!");
            Console.WriteLine($"👤 Main player: {mainPlayer.Uid}");
            Console.WriteLine($"🤖 Allies: {ally1.Uid}, {ally2.Uid}, {ally3.Uid}");
            Console.WriteLine($"💀 Enemies: {enemy1.Uid}");
            Console.WriteLine($"🏗️  Map objects: {PB2Map.MapObjects.Count}");
            Console.WriteLine($"⚙️  Includes engine marks, water, barrels, and interactive elements");
        }
    }
}