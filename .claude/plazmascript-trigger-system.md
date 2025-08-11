# PlazmaScript Trigger System Architecture

## Current System Overview
PlazmaScript uses a trigger-based action system where game logic is implemented through numbered trigger actions defined in `trigger_actions.json`. Entity methods return `TriggerAction` objects that can be added to triggers.

## Core Pattern
All entity action methods follow this pattern:
```csharp
public TriggerAction MethodName(parameters)
{
    return new TriggerAction
    {
        ParameterA = firstParam,
        ParameterB = secondParam,
        TriggerId = X
    };
}
```

## Trigger Action Mapping

### Environment Actions (PB2Map class)
- **5**: `Gravity` property - Change map gravity (default 0.5) - *Uses init trigger*
- **9**: `EndMission(reason)` - Returns TriggerAction to end mission

### Character Actions (Character class)  
- **4**: `SetHitPoints(percentage)` - Returns TriggerAction to set character health percentage
- **13**: `EnterVehicle(vehicle)` - Returns TriggerAction to put character in vehicle
- **14**: `MoveToRegion(region)` - Returns TriggerAction to move character to region

### Vehicle Actions (Vehicle class)
- **3**: `SetHitPoints(percentage)` - Returns TriggerAction to set vehicle health percentage

### Region Actions (Region class)
- **2**: `QuickMoveToRegion(target)` - Returns TriggerAction to move region to another region position
- **6**: `MakeDamage(damage)` - Returns TriggerAction to deal damage in this region
- **10**: `HarmStability(power)` - Returns TriggerAction to harm character stability in region
- **11**: `KillEnemiesOf(ally)` - Returns TriggerAction to kill non-allied characters in region
- **12**: `DestroyAllVehicles()` - Returns TriggerAction to destroy all vehicles in region
- **18**: `MoveToCenterOf(target)` - Returns TriggerAction to move to center of target region

### Door/Movable Actions (Door class)
- **0**: `MoveTo(region)` - Returns TriggerAction to force movable to region
- **1**: `SetSpeed(speed)` - Returns TriggerAction to change movable speed

### Gun Actions (Gun class)
- **15**: `MoveToRegion(region)` - Returns TriggerAction to move gun to region

## Design Principles Applied

### 1. Return TriggerAction Pattern
All entity methods return `TriggerAction` objects rather than executing immediately. This allows the caller to decide when and where to use the action.

```csharp
// Good - returns TriggerAction
public TriggerAction SetHitPoints(int percentage)
{
    return new TriggerAction { ParameterA = Uid, ParameterB = percentage.ToString(), TriggerId = 4 };
}

// Bad - executes immediately
public void SetHitPoints(int percentage)
{
    var trigger = new Trigger();
    trigger.AddAction(new TriggerAction { ... });
}
```

### 2. Single Responsibility
Each trigger ID has exactly one implementation in exactly one class based on logical ownership.

### 3. Domain-Driven Placement
- **Map-level**: Environment properties like gravity
- **Entity-level**: Actions that affect the specific entity
- **Spatial-level**: Area effects that belong to regions

## Usage Examples

### Environment Setup
```csharp
PB2Map.Gravity = 0.4;  // Property setter uses init trigger
```

### Creating Actions and Adding to Triggers
```csharp
var player = new Character("player", 100, 200);
var vehicle = new Vehicle("tank", 300, 180);
var setupTrigger = new Trigger("setup");

// Get TriggerActions from entity methods
var setHealthAction = player.SetHitPoints(75);
var enterVehicleAction = player.EnterVehicle(vehicle);

// Add actions to trigger
setupTrigger.AddAction(setHealthAction);
setupTrigger.AddAction(enterVehicleAction);

// Or chain directly
setupTrigger.AddAction(vehicle.SetHitPoints(100));
```

### Region Effects
```csharp
var combatZone = new Region("combat", 400, 150, 300, 150);
var combatTrigger = new Trigger("combat_effects");

combatTrigger.AddAction(combatZone.MakeDamage(25));
combatTrigger.AddAction(combatZone.KillEnemiesOf(player));
combatTrigger.AddAction(combatZone.DestroyAllVehicles());
```

### Movable Objects
```csharp
var door = new Door("gate", 100, 100, 50, 100);
var movementTrigger = new Trigger("door_movement");

movementTrigger.AddAction(door.MoveTo(targetRegion));
movementTrigger.AddAction(door.SetSpeed(2.0));
```

## Key Benefits

1. **Flexible**: TriggerActions can be reused across different triggers
2. **Composable**: Multiple actions can be combined in any trigger
3. **Testable**: Actions can be created and inspected without execution
4. **Intuitive**: No need to remember trigger IDs
5. **Type Safe**: Compile-time checking of parameters  
6. **Self-Documenting**: Method names clearly indicate purpose