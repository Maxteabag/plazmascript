using PlazmaScript.Core;
using System;

namespace PlazmaScript.Examples
{
    public class CreateMapExample
    {
        public CreateMapExample()
        {
            // Create initialization trigger for map setup
            var initTrigger = new Trigger("#init_setup");
            initTrigger.AddAction(PB2Map.SetGravity(0.4)); // Lower gravity than default (0.5)

            // Create game objects - INTUITIVE!
            var player = new Character("player1", 100, 200);
            var enemy = new Character("enemy1", 500, 200);
            var vehicle = new Vehicle("walker1", 300, 180, VehicleModel.Walker, VehicleSide.Blue);
            var gun = new Gun(GunModel.InvisibleGun);

            // Create regions
            var spawnArea = new Region("spawn", 50, 150, 200, 100);
            var combatZone = new Region("combat", 400, 150, 300, 150);
            var safeZone = new Region("safe", 800, 100, 150, 200);

            // Set up game triggers using intuitive methods
            var setupTrigger = new Trigger("#game_setup");
            
            setupTrigger.AddAction(player.SetHitPoints(75));       // Player starts with 75% health
            setupTrigger.AddAction(enemy.SetHitPoints(50));        // Enemy starts weakened
            setupTrigger.AddAction(vehicle.SetHitPoints(100));     // Vehicle at full health
            
            setupTrigger.AddAction(player.EnterVehicle(vehicle));  // Put player in vehicle
            setupTrigger.AddAction(enemy.MoveToRegion(combatZone)); // Send enemy to combat zone
            setupTrigger.AddAction(gun.MoveToRegion(safeZone));     // Place gun in safe zone

            // Set up region interactions
            var regionTrigger = new Trigger("#region_effects");
            regionTrigger.AddAction(spawnArea.QuickMoveToRegion(combatZone)); // Move spawn to combat
            regionTrigger.AddAction(combatZone.MakeDamage(25));           // Combat zone deals damage
            regionTrigger.AddAction(safeZone.KillEnemiesOf(player));      // Safe zone kills enemies
            regionTrigger.AddAction(combatZone.HarmStability(10));        // Combat zone harms stability

            Console.WriteLine("🎮 Intuitive map created!");
            Console.WriteLine($"📍 Gravity: 0.4 (lower than default)");
            Console.WriteLine($"👤 Player at ({player.X}, {player.Y}) with 75% HP");
            Console.WriteLine($"🤖 Enemy at ({enemy.X}, {enemy.Y}) with 50% HP");
            Console.WriteLine($"🤖 Walker at ({vehicle.X}, {vehicle.Y}) with {vehicle.HitPointsPercentage}% HP");
            Console.WriteLine($"📦 Total map objects: {PB2Map.MapObjects.Count}");
            Console.WriteLine("\n✨ No trigger IDs needed - just intuitive object methods!");
        }
    }
}