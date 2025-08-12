# PlazmaScript Trigger Logic Patterns

Critical patterns and gotchas for PlazmaBurst 2 trigger system implementation.

## ContinueIf Logic - CRITICAL UNDERSTANDING

### What ContinueIf Actually Does
`ContinueIf` is a **conditional exit point**, NOT a conditional block wrapper.

```csharp
// WRONG APPROACH - Only first card (index 0) will ever work
trigger.ContinueIf(currentCard == 0);
trigger.AddAction(displayText.SetValue("00"));
trigger.ContinueIf(currentCard == 1);  // NEVER REACHED if first condition failed
trigger.AddAction(displayText.SetValue("01"));
```

**Problem**: If `currentCard != 0`, the trigger exits completely at the first `ContinueIf`. The second condition is never evaluated.

### Correct Patterns

#### Pattern 1: Individual Triggers with Single ContinueIf
```csharp
// Create separate trigger for each condition
var trigger0 = new Trigger("#card_0");
trigger0.ContinueIf(currentCard == 0);  // Exit if not card 0
trigger0.AddAction(displayText.SetValue("00"));

var trigger1 = new Trigger("#card_1");  
trigger1.ContinueIf(currentCard == 1);  // Exit if not card 1
trigger1.AddAction(displayText.SetValue("01"));

// Router executes ALL triggers - each checks if it should act
routerTrigger.Execute(trigger0);
routerTrigger.Execute(trigger1);
```

#### Pattern 2: Single ContinueIf at Beginning
```csharp
// Only use ONE ContinueIf per trigger, at the very beginning
var specificTrigger = new Trigger("#for_card_5");
specificTrigger.ContinueIf(currentCard == 5);  // Exit early if not card 5
specificTrigger.AddAction(displayText.SetValue("05"));
specificTrigger.ShowText(displayText, "#FFFF00");
// All subsequent actions execute if ContinueIf passed
```

## Multi-Conditional Logic Architecture

### For Large Switch-Like Scenarios (100+ conditions)

**Architecture**: Router + Individual Triggers
```csharp
// 1. Create individual triggers for each case
var cardTriggers = new List<Trigger>();
for (int i = 0; i < 101; i++)
{
    var trigger = new Trigger($"#card_{i}");
    trigger.ContinueIf(currentCard == i);  // Only acts if this card
    trigger.AddAction(displayText.SetValue(flashcards[i].Number));
    cardTriggers.Add(trigger);
}

// 2. Router executes ALL triggers - each decides if it should act  
var router = new Trigger("#display_card");
for (int i = 0; i < cardTriggers.Count; i++)
{
    router.Execute(cardTriggers[i]);  // No ContinueIf in router!
}
```

**Why This Works**:
- Router has no conditionals, just executes everything
- Each individual trigger uses single ContinueIf to self-filter
- Only the matching trigger performs actions, others exit immediately

## Performance Considerations

### Object Count Impact
- Individual triggers: High object count but reliable logic
- Single complex trigger: Lower object count but fragile with multiple ContinueIf
- **Recommendation**: Favor correctness over object count optimization

### Trigger Execution Order
- Triggers execute in creation order within PlazmaScript
- Router pattern ensures all conditions are checked regardless of order
- No dependency on trigger execution sequence

## Common Gotchas

1. **Never chain ContinueIf statements** - only the first can succeed
2. **ContinueIf exits the entire trigger**, not just a block
3. **Router triggers should not use ContinueIf** - they should execute everything
4. **Use single ContinueIf at trigger start** for early exit filtering
5. **Test edge cases** like first/last array indices

## Debugging Tips

1. **Check object counts**: Dramatic changes indicate architecture shifts
2. **XML inspection**: Look for action type "116" (ContinueIf) patterns
3. **Test boundary conditions**: Index 0, max index, random middle values
4. **Verify trigger UIDs**: Ensure router targets exist in generated XML

## Intra-Tick Variable Conflicts

### The Problem: Same-Tick Variable Changes
When a trigger modifies a variable, that change is visible to subsequent executions **within the same tick**.

**Problematic Pattern**:
```csharp
mainButton.Execute(checkState0);  // If state=0, execute actionA and set state=1
mainButton.Execute(checkState1);  // Now sees state=1 and also executes!
```

**Result**: Both actionA and actionB execute on same button press.

### Solution: ExecuteOnNextTick
Use `ExecuteOnNextTick()` to defer execution until after current tick completes:

```csharp
// Wrong - both execute same tick if variable changes
checkState0.Execute(actionTrigger);

// Correct - deferred to next tick
checkState0.ExecuteOnNextTick(actionTrigger);
```

### ExecuteOnNextTick Implementation
Creates a Timer with `delay=0` that executes the target trigger on the next game tick:

```csharp
trigger.ExecuteOnNextTick("#target_trigger");
// Generates: <timer delay="0" maxcalls="1" enabled="false" target="#target_trigger" />
```

**Use Cases**:
- State transitions that should not affect same-tick logic
- Preventing variable conflicts in button logic
- Ensuring proper sequence: number → (button press) → association
- Breaking infinite execution loops

### Critical Lesson: Variable Setting Must Use NextTick

**The Key Insight**: When you have multiple conditional triggers checking the same variable, **variable setting operations must be deferred to next tick** to prevent both conditions from executing in the same button press.

**Wrong Pattern**:
```csharp
// Association trigger sets variable immediately (WRONG!)
associationTrigger.AddAction(showingAssociation.SetValue(1)); // Same tick change
associationTrigger.AddAction(displayText.SetValue(association));

// Main button executes both checks same tick
mainButton.Execute(checkIfNotShowingAssoc); // Executes if showingAssociation == 0
mainButton.Execute(checkIfShowingAssoc);    // ALSO executes because variable changed!
```

**Correct Pattern**:
```csharp
// Separate state change trigger (executed on next tick)
var setShowingAssociationTrigger = new Trigger("#set_showing_assoc");
setShowingAssociationTrigger.AddAction(showingAssociation.SetValue(1));

// Association trigger only displays (no variable change)
associationTrigger.AddAction(displayText.SetValue(association));

// Conditional logic
checkIfNotShowingAssoc.ContinueIf(showingAssociation == 0);
checkIfNotShowingAssoc.Execute(displayAssociation);              // Immediate display
checkIfNotShowingAssoc.ExecuteOnNextTick(setShowingAssociation); // Deferred state change

checkIfShowingAssoc.ContinueIf(showingAssociation == 1);
checkIfShowingAssoc.Execute(nextCard); // Immediate OK (no conflict)
```

**Why This Works**:
1. Button press triggers both checks immediately (same tick)
2. Only one condition passes initially (showingAssociation is either 0 OR 1)
3. Display happens immediately, but **variable change is deferred**
4. Next tick: variable changes, but no new conditional checks are running
5. Next button press: now only the other condition can pass

### Example: Flashcard State Management
```csharp
// Button checks current state (both execute same tick)
mainButton.Execute(checkShowingNumber);     // If showing number, reveal association  
mainButton.Execute(checkShowingAssociation); // If showing association, next card

// State transitions - CRITICAL: Variable changes deferred to next tick!
checkShowingNumber.ContinueIf(showingAssociation == 0);
checkShowingNumber.Execute(displayAssociation);              // Show answer immediately
checkShowingNumber.ExecuteOnNextTick(setShowingToTrue);      // Change state next tick

checkShowingAssociation.ContinueIf(showingAssociation == 1);
checkShowingAssociation.Execute(nextCard);                   // Next card immediately
checkShowingAssociation.ExecuteOnNextTick(setShowingToFalse); // Reset state next tick
```

**Execution Timeline**:
- **Tick 1**: Button pressed, `showingAssociation = 0`
  - `checkShowingNumber` passes, displays association immediately
  - Timer activates to set `showingAssociation = 1` on next tick
  - `checkShowingAssociation` fails (still 0), does nothing
- **Tick 2**: Timer fires
  - `showingAssociation` becomes 1
  - No conditional checks running, no conflicts
- **Next button press (Tick 3)**: `showingAssociation = 1`
  - `checkShowingNumber` fails (now 1), does nothing
  - `checkShowingAssociation` passes, goes to next card
  - Timer activates to set `showingAssociation = 0` for next card

## Alternative Approaches

### For Simple Conditions (2-5 cases)
Can use sequential triggers with proper early exit planning:
```csharp
// Acceptable for small condition sets
mainTrigger.ContinueIf(state == "ready");
mainTrigger.Execute(readyTrigger);
// No additional ContinueIf statements after this point
```

### For Very Large Condition Sets (500+)
Consider breaking into logical groups:
```csharp
// Group by ranges
var lowNumberRouter = new Trigger("#numbers_0_to_50");
var highNumberRouter = new Trigger("#numbers_51_to_100");

// First router checks range, then executes appropriate sub-router
mainRouter.ContinueIf(currentCard <= 50);
mainRouter.Execute(lowNumberRouter);
// This approach still has the chaining problem - avoid!
```

**Better**: Use flat individual trigger architecture even for 1000+ cases.

## Key Takeaways: NextTick Variable Setting

### 🚨 CRITICAL RULE: Variable Changes in Multi-Conditional Systems

**When you have multiple conditional triggers checking the same variable in a button press, ALL variable setting operations MUST use `ExecuteOnNextTick()` to prevent intra-tick conflicts.**

### Real-World Example: The Flashcard Bug

**Original Issue**: 
```csharp
// Bug: Both question AND answer showed simultaneously
associationTrigger.AddAction(showingAssociation.SetValue(1)); // Same tick!
```

**Root Cause**: 
1. Button executes `checkIfNotShowing` (showingAssociation == 0) ✓ passes
2. `checkIfNotShowing` displays association AND sets showingAssociation = 1
3. Button executes `checkIfShowing` (showingAssociation == 1) ✓ NOW ALSO passes!
4. Both triggers executed in same button press

**Solution**:
```csharp
// Fixed: Separate variable setting to next tick
checkIfNotShowing.Execute(displayAssociation);       // Immediate display
checkIfNotShowing.ExecuteOnNextTick(setState1);      // Deferred variable change
```

### When to Use NextTick for Variables

✅ **ALWAYS use NextTick when**:
- Multiple conditional triggers check the same variable
- State machine transitions (showing → not showing)
- Any variable that affects subsequent trigger conditions
- Button logic with multiple execution paths

❌ **Don't need NextTick when**:
- Only one trigger checks the variable
- Variable only affects display/text (not trigger logic)
- Single-use triggers or linear execution flows

### ExecuteOnNextTick Implementation Pattern

The complete pattern creates:
1. **Timer** with infinite calls, disabled initially
2. **Cleanup trigger** that disables timer and executes target
3. **Activate timer** action in current trigger

```csharp
// This creates the full NextTick infrastructure automatically
trigger.ExecuteOnNextTick("#target_trigger");
```

**Remember**: This lesson applies to ANY PlazmaScript system where multiple triggers check the same variable state. The PB2 execution engine processes all immediate actions before moving to the next tick, so variable changes must be carefully managed to avoid unintended trigger cascades.