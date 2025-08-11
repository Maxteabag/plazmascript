# PlazmaScript Trigger Implementation Workflow

## Overview
PlazmaScript is a trigger action system for PlazmaBurst 2 game engine refactoring from low-level ID-based to intuitive object-oriented API.

## Implementation Rules

### CRITICAL: Never Assume Functionality
**NEVER implement trigger actions without proper documentation:**
- ❌ Don't guess what trigger IDs should do based on patterns
- ❌ Don't invent functionality for missing IDs
- ✅ Only implement with official PB2 trigger documentation
- ✅ Only implement with user-provided specifications
- ✅ Leave placeholders for unknown IDs until documented

### CRITICAL: Follow OOP Principles
**@~/.claude/plazmascript-oop-patterns.md - Object-oriented implementation patterns and rules**
- ❌ Never use static methods for object actions
- ✅ Always use instance methods with `this.Uid`
- ✅ Follow pattern: `object.Method(parameters)` not `Class.Method(object, parameters)`

### Current Implementation Status (IDs 0-500)
- **Implemented**: 61 IDs (12.2%)
- **Need existing class extensions**: ~350 IDs (70%)  
- **Need new classes**: ~50 IDs (10%)
- **Undocumented/Reserved**: ~39 IDs (7.8%)

### Implementation Approach

#### 1. Parallel Analysis Method
```bash
# Use 10 parallel tasks for large trigger ID ranges
Task 1: IDs 0-50
Task 2: IDs 51-100
Task 3: IDs 101-150
# ... continue through Task 10: IDs 451-500
```

#### 2. Chronological Implementation
- Start with lowest missing IDs (7, 8, 16, 17, 22-24, etc.)
- Take 10 IDs at a time
- Create necessary class structures as needed

#### 3. Before Implementation Checklist
- [ ] Have official trigger documentation?
- [ ] User provided specific functionality?
- [ ] Parameters and behavior clearly defined?
- [ ] Target class identified (Player, Gun, Region, etc.)?

#### 4. Class Architecture Patterns

**Existing Classes Ready for Extensions:**
- `Player.cs` - Character health, movement, vehicle entry
- `Enemy.cs` - AI character actions  
- `Gun.cs` - Weapon mechanics (IDs 15, 64, 76-78, 123, 170, 172)
- `Region.cs` - Area-based actions (IDs 2, 6, 10-12, 18, 120-121)
- `Variable.cs` - Data manipulation (IDs 100-125, 149-150, 160, 223)
- `Timer.cs` - Timing/scheduling (IDs 25-26, 46)
- `Door.cs` - Movable objects (IDs 0-1)
- `Vehicle.cs` - Vehicle operations (ID 3)
- `PB2Map.cs` - Map-level operations (IDs 5, 9)
- `Trigger.cs` - Flow control (IDs 19-21, 42-43, 99, 116, 156, 169)

**New Classes Needed:**
- Array operations class (IDs 349, 350, 352, 354)
- Physics/Environmental systems (IDs 180-189, 241-245)
- Game Control/Session Management (IDs 307-311, 246-250)
- Advanced UI systems (camera, interface control)

#### 5. Implementation Pattern
```csharp
/// <summary>
/// [Description from PB2 documentation]
/// </summary>
/// <param name="param">[Parameter description]</param>
public TriggerAction MethodName(Type param)
{
    return new TriggerAction
    {
        ParameterA = param.ToString(), // or Uid
        ParameterB = "-1", // or second parameter
        TriggerId = [DOCUMENTED_ID]
    };
}
```

## Current Gap Analysis Results

**Already Implemented IDs:**
0, 1, 2, 3, 4, 5, 6, 9, 10, 11, 12, 13, 14, 15, 18, 19, 20, 21, 25, 26, 42, 43, 46, 64, 76, 77, 78, 99, 100-123, 125, 149, 150, 156, 160, 169, 170, 172, 223

**First Missing IDs to Implement (Chronologically):**
7, 8, 16, 17, 22, 23, 24, 27-41, 44, 45, 47-63, 65-75, 79-98...

## Prerequisites for Implementation

### Required Documentation
1. **Official PB2 Trigger Action Reference** - Complete list of all trigger IDs with:
   - Parameter definitions (A and B)
   - Expected behavior description
   - Target object types
   - Usage examples

2. **PlazmaScript Specification** - How triggers map to C# methods

3. **PB2 Game Engine Documentation** - Context for trigger functionality

### Tools and Workflow
- Use `TodoWrite` tool to track implementation progress
- Implement in batches of 10 IDs chronologically
- Test each batch with real PB2 map generation
- Verify XML output matches PB2 format exactly

## Best Practices
- Always add `# prefix` automatically in constructors
- Follow existing naming conventions (`SetHealth`, `MoveToRegion`)
- Add comprehensive XML documentation comments
- Use appropriate parameter types (string, int, double)
- Handle -1 as default for unused parameters
- Test with actual PB2 map upload to verify functionality