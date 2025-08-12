using PlazmaScript.Core;
using System;
using System.Collections.Generic;

namespace PlazmaScript.Examples
{
    public class FlashcardPracticeMap
    {
        // Flashcard data structure
        private struct FlashcardEntry
        {
            public string Number { get; set; }
            public string Association { get; set; }
            
            public FlashcardEntry(string number, string association)
            {
                Number = number;
                Association = association;
            }
        }

        // All flashcard entries (00-100)
        private static readonly FlashcardEntry[] Flashcards = new FlashcardEntry[]
        {
            new FlashcardEntry("00", "Sauce"),
            new FlashcardEntry("01", "Seed"),
            new FlashcardEntry("02", "Sun"),
            new FlashcardEntry("03", "Sumo"),
            new FlashcardEntry("04", "Sir (Knight)"),
            new FlashcardEntry("05", "Soul"),
            new FlashcardEntry("06", "Sushi"),
            new FlashcardEntry("07", "Ski"),
            new FlashcardEntry("08", "Sofa"),
            new FlashcardEntry("09", "Soap"),
            new FlashcardEntry("10", "Dice"),
            new FlashcardEntry("11", "Dad"),
            new FlashcardEntry("12", "Dino"),
            new FlashcardEntry("13", "Adam (the first man)"),
            new FlashcardEntry("14", "Thor"),
            new FlashcardEntry("15", "Adele"),
            new FlashcardEntry("16", "DJ"),
            new FlashcardEntry("17", "Dog"),
            new FlashcardEntry("18", "TV"),
            new FlashcardEntry("19", "Tuba"),
            new FlashcardEntry("20", "Nose"),
            new FlashcardEntry("21", "Nut"),
            new FlashcardEntry("22", "Nun"),
            new FlashcardEntry("23", "Nemo"),
            new FlashcardEntry("24", "Norway"),
            new FlashcardEntry("25", "Neal (Caffrey)"),
            new FlashcardEntry("26", "Nacho"),
            new FlashcardEntry("27", "Nuke"),
            new FlashcardEntry("28", "Knife"),
            new FlashcardEntry("29", "NBA"),
            new FlashcardEntry("30", "Mouse"),
            new FlashcardEntry("31", "Mat"),
            new FlashcardEntry("32", "Moon"),
            new FlashcardEntry("33", "Mummy"),
            new FlashcardEntry("34", "Mario (Super Mario)"),
            new FlashcardEntry("35", "Mole"),
            new FlashcardEntry("36", "Match"),
            new FlashcardEntry("37", "Mickey"),
            new FlashcardEntry("38", "Mafia"),
            new FlashcardEntry("39", "Map"),
            new FlashcardEntry("40", "Rose"),
            new FlashcardEntry("41", "Radio"),
            new FlashcardEntry("42", "Rain"),
            new FlashcardEntry("43", "Rum"),
            new FlashcardEntry("44", "Error (red X mark)"),
            new FlashcardEntry("45", "Ariel (the little mermaid)"),
            new FlashcardEntry("46", "Arch"),
            new FlashcardEntry("47", "Rocky"),
            new FlashcardEntry("48", "Roof"),
            new FlashcardEntry("49", "RIP"),
            new FlashcardEntry("50", "Lasso"),
            new FlashcardEntry("51", "Lady (Gaga)"),
            new FlashcardEntry("52", "Lion"),
            new FlashcardEntry("53", "Lime"),
            new FlashcardEntry("54", "Hilary (Clinton)"),
            new FlashcardEntry("55", "Lily (himym)"),
            new FlashcardEntry("56", "Leech"),
            new FlashcardEntry("57", "Lake"),
            new FlashcardEntry("58", "Lava"),
            new FlashcardEntry("59", "Lip"),
            new FlashcardEntry("60", "Cheese"),
            new FlashcardEntry("61", "Cheetah"),
            new FlashcardEntry("62", "China"),
            new FlashcardEntry("63", "Jam"),
            new FlashcardEntry("64", "Chair"),
            new FlashcardEntry("65", "Chilli"),
            new FlashcardEntry("66", "Yo-yo"),
            new FlashcardEntry("67", "Chick"),
            new FlashcardEntry("68", "Chef"),
            new FlashcardEntry("69", "Ship"),
            new FlashcardEntry("70", "Goose"),
            new FlashcardEntry("71", "Cat"),
            new FlashcardEntry("72", "Gun"),
            new FlashcardEntry("73", "Gum"),
            new FlashcardEntry("74", "Car"),
            new FlashcardEntry("75", "Koala"),
            new FlashcardEntry("76", "Cash"),
            new FlashcardEntry("77", "Cake"),
            new FlashcardEntry("78", "Coffee"),
            new FlashcardEntry("79", "Cube (Rubik's Cube)"),
            new FlashcardEntry("80", "Vase"),
            new FlashcardEntry("81", "Foot"),
            new FlashcardEntry("82", "Fan"),
            new FlashcardEntry("83", "Foam"),
            new FlashcardEntry("84", "Fire"),
            new FlashcardEntry("85", "Fly"),
            new FlashcardEntry("86", "Fish"),
            new FlashcardEntry("87", "Fog"),
            new FlashcardEntry("88", "FIFA"),
            new FlashcardEntry("89", "Phoebe (from Friends)"),
            new FlashcardEntry("90", "Bus"),
            new FlashcardEntry("91", "Bat"),
            new FlashcardEntry("92", "Piano"),
            new FlashcardEntry("93", "Beam"),
            new FlashcardEntry("94", "Beer"),
            new FlashcardEntry("95", "Bell"),
            new FlashcardEntry("96", "Bush"),
            new FlashcardEntry("97", "Book"),
            new FlashcardEntry("98", "Beef"),
            new FlashcardEntry("99", "Pope"),
            new FlashcardEntry("100", "Daisies")
        };

        public static void CreateMap()
        {
            // Initialize the map
            PB2Map.Initialize();

            // ===================
            // TERRAIN & STRUCTURE
            // ===================
            
            // Main ground platform
            var ground = new Box(-500, 200, 1000, 100, WallMaterial.Concrete);
            
            // Display background
            var displayBG = new Box(-300, -100, 600, 200, WallMaterial.DarkPlate);
            
            // Interaction button platform
            var buttonPlatform = new Box(200, 100, 100, 50, WallMaterial.BrownConcrete);

            // ===================
            // VARIABLES
            // ===================
            
            var currentCardIndex = new Variable("current_card");
            var showingAssociation = new Variable("showing_association");
            var displayText = new Variable("display_text");
            var tempNumber = new Variable("temp_number");
            var tempAssociation = new Variable("temp_association");

            // ===================
            // PLAYER SPAWN
            // ===================
            
            var player = new Player("#player", -200, 100);

            // ===================
            // INITIALIZATION TRIGGER
            // ===================
            
            var initTrigger = new Trigger("#init_trigger", true); // Execute at start
            
            // Initialize variables and start with first random card
            initTrigger.AddAction(showingAssociation.SetValue(0));
            initTrigger.Execute("#card_selection");

            // ===================
            // CARD SELECTION TRIGGER
            // ===================
            
            var cardSelectionTrigger = new Trigger("#card_selection");
            
            // Generate random card index (0-100)
            cardSelectionTrigger.AddAction(currentCardIndex.SetRandomMinusOne(101)); // 0-100 inclusive
            
            // Execute display trigger
            cardSelectionTrigger.Execute("#display_number");

            // ===================
            // STATE CHANGE TRIGGER
            // ===================
            
            var setShowingAssociationTriggerFalse = new Trigger("#set_showing_assoc_false");
            setShowingAssociationTriggerFalse.AddAction(showingAssociation.SetValue(0));
            
            var setShowingAssociationTrigger = new Trigger("#set_showing_assoc");
            setShowingAssociationTrigger.AddAction(showingAssociation.SetValue(1));

            // ===================
            // INDIVIDUAL CARD TRIGGERS
            // ===================
            
            // Create separate triggers for each card's number and association
            var cardNumberTriggers = new List<Trigger>();
            var cardAssociationTriggers = new List<Trigger>();
            
            for (int i = 0; i < Flashcards.Length; i++)
            {
                // Number display trigger for card i - only acts if currentCardIndex matches
                var numberTrigger = new Trigger($"#number_{i}");
                numberTrigger.ContinueIf(currentCardIndex == i); // Exit if not this card
                numberTrigger.ExecuteOnNextTick(setShowingAssociationTriggerFalse);
                numberTrigger.AddAction(displayText.SetValue(Flashcards[i].Number));
                numberTrigger.ShowText(displayText, "#FFFF00");
                cardNumberTriggers.Add(numberTrigger);
                
                // Association display trigger for card i - only acts if currentCardIndex matches
                var associationTrigger = new Trigger($"#association_{i}");
                associationTrigger.ContinueIf(currentCardIndex == i); // Exit if not this card
                associationTrigger.AddAction(displayText.SetValue(Flashcards[i].Association));
                associationTrigger.ShowText(displayText, "#00FF00");
                cardAssociationTriggers.Add(associationTrigger);
            }

            // ===================
            // DISPLAY NUMBER ROUTER
            // ===================
            
            var displayNumberTrigger = new Trigger("#display_number");
            
            // ===================
            // DISPLAY ASSOCIATION ROUTER
            // ===================
            
            var displayAssociationTrigger = new Trigger("#display_association");

            // Execute ALL number triggers - each will check if it should act
            for (int i = 0; i < Flashcards.Length; i++)
            {
                displayNumberTrigger.Execute(cardNumberTriggers[i]);
            }
            
            // Execute ALL association triggers - each will check if it should act
            for (int i = 0; i < Flashcards.Length; i++)
            {
                displayAssociationTrigger.Execute(cardAssociationTriggers[i]);
            }

            // ===================
            // CONDITIONAL TRIGGERS
            // ===================
            
            // Create conditional triggers for button behavior
            var checkIfShowingAssociation = new Trigger("#check_showing_assoc");
            var checkIfNotShowingAssociation = new Trigger("#check_not_showing_assoc");
            
            // If showing association (value = 1), go to next card
            checkIfShowingAssociation.ContinueIf(showingAssociation == 1);
            checkIfShowingAssociation.Execute(cardSelectionTrigger);
            
            // If not showing association (value = 0), show association immediately and set state on next tick
            checkIfNotShowingAssociation.ContinueIf(showingAssociation == 0);
            checkIfNotShowingAssociation.Execute(displayAssociationTrigger);
            checkIfNotShowingAssociation.ExecuteOnNextTick(setShowingAssociationTrigger);

            // ===================
            // MAIN BUTTON TRIGGER
            // ===================
            
            var mainButtonTrigger = new Trigger("#main_button");
            mainButtonTrigger.MaxCalls = -1; // Unlimited uses
            
            // Execute both conditional checks
            mainButtonTrigger.Execute(checkIfShowingAssociation);
            mainButtonTrigger.Execute(checkIfNotShowingAssociation);

            // ===================
            // BUTTON REGION
            // ===================
            
            var buttonRegion = new Region("#button", 200, 100, 100, 50, ActivationTrigger.UseKeyWithButton, mainButtonTrigger.Uid);

            Console.WriteLine("🃏 Flashcard Practice Map created!");
            Console.WriteLine("Features:");
            Console.WriteLine("- 101 number association flashcards (00-100)");
            Console.WriteLine("- Press E on button to cycle through cards");
            Console.WriteLine("- Random card selection for effective practice");
            Console.WriteLine("- Fixed intra-tick variable conflicts with ExecuteOnNextTick");
            Console.WriteLine($"- Total objects: {PB2Map.MapObjects.Count}");
        }
    }
}