# OOP Game Engine Refactoring Guide

## Overview
When refactoring low-level game engine APIs to object-oriented interfaces, focus on making the API intuitive for users rather than creating sophisticated architecture.

## Core Principles

### 1. Domain-Driven Method Placement
- **Environment Properties**: Global settings belong on the main class (e.g., `GameMap.Gravity`)
- **Entity Actions**: Actions belong on the entity itself (e.g., `player.SetHitPoints(75)`)
- **Spatial Actions**: Region/area actions belong on the spatial object (e.g., `region.MakeDamage(25)`)

### 2. Natural Language API Design
- Use intuitive method names: `SetHitPoints()` not `ModifyHealthPercentage()`
- Use properties for simple settings: `Map.Gravity = 0.4` not `Map.SetGravity(0.4)`
- Group related actions logically by object responsibility

### 3. Hide Implementation Details
- Users shouldn't know about trigger IDs, internal action objects, or XML schemas
- Create simple methods that internally handle complexity
- Maintain backward compatibility when possible

## Refactoring Process

### Step 1: Analyze Existing Actions
1. List all low-level actions from documentation/config files
2. Group actions by logical domain (environment, entities, spatial, etc.)
3. Identify which objects should "own" each action

### Step 2: Design Intuitive API
1. Convert actions to natural method names
2. Place methods on appropriate objects based on responsibility
3. Use properties for simple getters/setters
4. Ensure no duplication of trigger IDs across objects

### Step 3: Implementation Strategy
```csharp
// Bad: Exposing implementation details
trigger.AddAction(new TriggerAction { TriggerId = 5, ParameterA = "0.4" });

// Good: Hide complexity behind intuitive interface
PB2Map.Gravity = 0.4;
```

### Step 4: Validate Design
1. Each trigger ID should have exactly ONE logical home
2. Method names should read naturally
3. Related functionality should be grouped on same object
4. No implementation details should leak through

## Common Mistakes to Avoid

### ❌ Over-Engineering
Don't create complex XML parsers, code generators, or registry systems unless specifically requested. Users want simple, intuitive methods.

### ❌ Wrong Object Ownership
```csharp
// Bad: Map doing region-specific actions
Map.DamageInRegion(region, damage);

// Good: Region handling its own actions  
region.MakeDamage(damage);
```

### ❌ Duplicating Trigger Actions
Each trigger ID should map to exactly one method in exactly one class. Don't duplicate the same trigger across multiple entity types.

### ❌ Unintuitive Method Names
```csharp
// Bad: Technical/confusing names
entity.ModifyHealthValueToPercentage(75);

// Good: Natural language
entity.SetHitPoints(75);
```

## Success Indicators

### ✅ Natural Usage Patterns
Users should be able to write code that reads like natural language:
```csharp
// Environment setup
Map.Gravity = 0.4;

// Entity management  
player.SetHitPoints(75);
enemy.MoveToRegion(combatZone);

// Area effects
combatZone.MakeDamage(25);
safeZone.KillEnemiesOf(player);
```

### ✅ Logical Grouping
- Environment properties on Map/Game class
- Entity actions on respective entity classes
- Spatial actions on Region/Area classes
- No cross-cutting concerns or misplaced responsibilities

### ✅ Implementation Hiding
Users never need to know:
- Trigger IDs or internal action codes
- XML schemas or configuration formats  
- Internal object creation patterns
- Low-level API details

## Testing the Refactor

Create example usage that demonstrates:
1. Environment configuration (gravity, physics, etc.)
2. Entity manipulation (health, movement, etc.)
3. Spatial effects (area damage, region actions)
4. Game flow control (mission end, triggers)

The API should feel intuitive to both human developers and AI assistants without requiring knowledge of the underlying implementation.