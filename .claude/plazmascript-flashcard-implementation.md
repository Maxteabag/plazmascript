# PlazmaScript Flashcard System Implementation

Complete implementation guide for interactive flashcard maps in PlazmaBurst 2.

## Architecture Overview

### Core Components
- **101 Individual Card Triggers**: One trigger per flashcard (number + association)
- **Router System**: Executes all card triggers, each self-filters with ContinueIf
- **State Management**: Variables track current card index and display state
- **Button Interaction**: E-key press region toggles between number and association

### Data Structure
```csharp
private struct FlashcardEntry
{
    public string Number { get; set; }      // "00", "01", "42", etc.
    public string Association { get; set; }  // "Sauce", "Seed", "Rain", etc.
}

private static readonly FlashcardEntry[] Flashcards = new FlashcardEntry[]
{
    new FlashcardEntry("00", "Sauce"),
    new FlashcardEntry("01", "Seed"),
    // ... 101 total entries
};
```

## Implementation Flow

### 1. Initialization
```csharp
var initTrigger = new Trigger("#init_trigger", true); // Auto-execute at start
initTrigger.AddAction(showingAssociation.SetValue(0));
initTrigger.Execute(cardSelectionTrigger);
```

### 2. Card Selection (Random)
```csharp
var cardSelectionTrigger = new Trigger("#card_selection");
cardSelectionTrigger.AddAction(currentCardIndex.SetRandomMinusOne(101)); // 0-100
cardSelectionTrigger.Execute("#display_number");
```

### 3. Display System Architecture
```csharp
// Individual triggers for each card's number display
for (int i = 0; i < Flashcards.Length; i++)
{
    var numberTrigger = new Trigger($"#number_{i}");
    numberTrigger.ContinueIf(currentCardIndex == i); // Self-filter
    numberTrigger.AddAction(showingAssociation.SetValue(0));
    numberTrigger.AddAction(displayText.SetValue(Flashcards[i].Number));
    numberTrigger.ShowText(displayText, "#FFFF00"); // Yellow
}

// Router executes ALL number triggers
var displayNumberRouter = new Trigger("#display_number");
for (int i = 0; i < Flashcards.Length; i++)
{
    displayNumberRouter.Execute($"#number_{i}");
}
```

### 4. Button Logic (State Toggle)
```csharp
var mainButton = new Trigger("#main_button");
mainButton.Execute("#check_showing_assoc");      // If showing association -> next card
mainButton.Execute("#check_not_showing_assoc");  // If showing number -> show association

var checkShowingAssoc = new Trigger("#check_showing_assoc");
checkShowingAssoc.ContinueIf(showingAssociation == 1);
checkShowingAssoc.Execute(cardSelectionTrigger); // Next random card

var checkNotShowingAssoc = new Trigger("#check_not_showing_assoc");
checkNotShowingAssoc.ContinueIf(showingAssociation == 0);
checkNotShowingAssoc.Execute("#display_association"); // Show association
```

## User Interaction Flow

1. **Map Start**: Random number appears in yellow (e.g., "42")
2. **Press E**: Association appears in green (e.g., "Rain")
3. **Press E**: New random number appears in yellow (e.g., "73")
4. **Press E**: Association appears in green (e.g., "Gum")
5. **Continue**: Infinite cycle through all 101 flashcards

## Key Technical Details

### Variables Used
- `current_card` (Integer): Index of selected flashcard (0-100)
- `showing_association` (Integer): State flag (0 = showing number, 1 = showing association)
- `display_text` (String): Current text to display

### Color Coding
- **Yellow (#FFFF00)**: Numbers (question phase)
- **Green (#00FF00)**: Associations (answer phase)

### Physical Layout
- **Ground Platform**: 1000×100 units at y=200
- **Display Background**: 600×200 dark plate at center
- **Button Platform**: 100×50 units at (200, 100)
- **Player Spawn**: (-200, 100)
- **Button Region**: E-key activation at button platform

## Performance Metrics
- **Total Objects**: 237 (after optimization)
- **Triggers**: ~210 (101 number + 101 association + infrastructure)
- **Variables**: 3 core state variables
- **Map Complexity**: High (due to 101-way branching logic)

## Testing Checklist

### Functionality Tests
- [ ] Random number displays on start
- [ ] E-key reveals association
- [ ] Second E-key shows new random number
- [ ] All 101 flashcards accessible
- [ ] No duplicate cards in sequence
- [ ] Color coding correct (yellow/green)

### Edge Case Tests
- [ ] Card index 0 ("00" -> "Sauce")
- [ ] Card index 100 ("100" -> "Daisies")
- [ ] Rapid button pressing
- [ ] Long play session (100+ cards)

## Common Issues & Solutions

### Issue: Only First Card Works
**Cause**: Multiple `ContinueIf` in single trigger
**Solution**: Use individual triggers with single `ContinueIf` each

### Issue: Text Formatting Problems
**Cause**: `\n` newlines don't work in PB2
**Solution**: Keep text simple, just number/association strings

### Issue: Simultaneous Color Display
**Cause**: Improper state management in trigger execution
**Solution**: Ensure `showing_association` variable properly set before text display

### Issue: Button Not Responding
**Cause**: Region activation settings or trigger targeting
**Solution**: Verify region `use_on="1"` and `use_target` pointing to correct trigger UID

## Extensions & Modifications

### Adding New Flashcard Sets
1. Modify `FlashcardEntry[]` array with new data
2. Update array length references (currently 101)
3. Recompile - architecture automatically scales

### Customizing Display
- Modify color codes in `ShowText()` calls
- Adjust text positioning via display background coordinates
- Change button size/position via platform and region parameters

### Performance Optimization
- For smaller card sets (≤20), consider single trigger with sequential `ContinueIf` (acceptable risk)
- For larger sets (≥500), consider grouped architecture with range checks

## File Structure
- **Main Implementation**: `Examples/FlashcardPracticeMap.cs`
- **Entry Point**: `MapEntry.cs` (calls `FlashcardPracticeMap.CreateMap()`)
- **Generated Output**: `GeneratedMaps/MapExample.xml`
- **Framework**: PlazmaScript.Core namespace with Trigger, Variable, Region classes