# PlazmaScript Object-Oriented Implementation Patterns

## Core OOP Principle
**Methods belong to object instances and use `this.Uid` for self-reference**

## Correct vs Incorrect Implementation Patterns

### ✅ CORRECT: Instance Methods
```csharp
// Method on the object that uses its own UID
public TriggerAction MoveToRegion(Region targetRegion)
{
    return new TriggerAction
    {
        ParameterA = Uid,           // THIS object's UID
        ParameterB = targetRegion.Uid,
        TriggerId = 15
    };
}
```

**Usage:** `myGun.MoveToRegion(someRegion)` - gun moves to region

### ❌ INCORRECT: Static Methods
```csharp
// BAD - Static method requiring object parameter
public static TriggerAction MoveToRegion(Gun gun, Region targetRegion)
{
    return new TriggerAction
    {
        ParameterA = gun.Uid,
        ParameterB = targetRegion.Uid,
        TriggerId = 15
    };
}
```

**Usage:** `Gun.MoveToRegion(myGun, someRegion)` - violates OOP encapsulation

## Implementation Guidelines

### 1. Parameter Mapping Rules
Based on trigger specification "Action description 'A' parameter 'B'":
- **ParameterA**: Usually the CURRENT object's UID (`this.Uid`)
- **ParameterB**: Usually the target/value parameter

### 2. Method Signatures
```csharp
// For object-to-object interactions
public TriggerAction MethodName(TargetObject target)

// For object with value parameter  
public TriggerAction MethodName(int/string value)

// For object with multiple parameters
public TriggerAction MethodName(TargetObject target, int value)
```

### 3. Common Method Patterns

#### Movement Actions
```csharp
// "Move Object 'A' to Region 'B'"
public TriggerAction MoveToRegion(Region region)
{
    return new TriggerAction
    {
        ParameterA = Uid,        // This object
        ParameterB = region.Uid, // Target region
        TriggerId = X
    };
}
```

#### Property Setting Actions  
```csharp
// "Set Property 'A' of Object to value 'B'"
public TriggerAction SetProperty(int value)
{
    return new TriggerAction
    {
        ParameterA = Uid,           // This object
        ParameterB = value.ToString(), // New value
        TriggerId = X
    };
}
```

#### Region-based Actions
```csharp
// "Do action with power 'A' at Region 'B'"
public TriggerAction DoAction(int power)
{
    return new TriggerAction
    {
        ParameterA = power.ToString(), // Action parameter
        ParameterB = Uid,              // This region
        TriggerId = X
    };
}
```

### 4. Class-Specific Patterns

**Player/Character/Enemy:**
- Health/movement/combat methods on the character instance
- `player.SetHealth(100)` not `Player.SetHealth(player, 100)`

**Region:**
- Area effects on the region instance  
- `region.MakeExplosion(50)` not `Region.MakeExplosion(region, 50)`

**Gun:**
- Weapon modifications on the gun instance
- `gun.SetDamage(75)` not `Gun.SetDamage(gun, 75)`

**Timer:**
- Timer controls on the timer instance
- `timer.SetFrequency(30)` not `Timer.SetFrequency(timer, 30)`

### 5. Exception Cases
Very rare cases where static methods might be appropriate:
- Map-level operations (`PB2Map.SetGravity()`)
- Factory methods for creating objects
- Utility methods that don't operate on specific instances

### 6. Implementation Checklist
- [ ] Is this an instance method on the correct object type?
- [ ] Does ParameterA use `Uid` (this object's UID)?
- [ ] Does ParameterB contain the target/value parameter?
- [ ] Does the method name follow existing naming conventions?
- [ ] Is the XML documentation accurate?
- [ ] Does the usage pattern make intuitive sense?

## Example from Recent Fix

### Before (WRONG):
```csharp
public static TriggerAction MakeExplosion(int power, Region region)
// Usage: Region.MakeExplosion(50, myRegion)
```

### After (CORRECT):
```csharp
public TriggerAction MakeExplosion(int power)
// Usage: myRegion.MakeExplosion(50)
```

This follows the OOP principle where the region object performs the action on itself, using its own `Uid` internally.