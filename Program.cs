﻿// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// Array used to store runtime data, as there is no persistent data
// This is a string array storing info on 8 pets with 6 dimensions. Matrix is 8x6
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "?";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "?";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all pets of a certain species and physical description");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    //Console.WriteLine($"You selected menu option {menuSelection}.");
    //Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    //readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();

                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "2":
            // List all of our current pet information
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }
            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more pets.");
            }


            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;

                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();

                        validEntry = (animalSpecies != "dog" && animalSpecies != "cat" ? false : true);
                    }
                } while (!validEntry);

                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                do
                {
                    int petAge;

                    Console.WriteLine("Enter the pet's age or enter ? if its unknown.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;

                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (!validEntry);

                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPhysicalDescription == "");

                do
                {
                    Console.WriteLine("Enter a personality description of the pet (likes, dislikes, tricks, energy level etc.)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        } 
                    }
                } while (animalPersonalityDescription == "");

                do
                {
                    Console.WriteLine("Enter a nickname for the pet.");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        } 
                    }
                } while (animalNickname == "");

                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount++;
                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet? y/n");
                    do
                    {
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();   
            }



            break;
        case "3":
            for (int i = 0; i < maxPets; i++)
            {
                // Skip if ID is blank
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }

                // Verify pet age
                if (ourAnimals[i, 2] == "Age: ?")
                {
                    bool validEntry = false;
                    do
                    {
                        int petAge;

                        Console.WriteLine($"Missing Pet Age for {ourAnimals[i, 0]}, please enter.");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;

                            if (ourAnimals[i, 2] == "Age: ?")
                            {
                                validEntry = int.TryParse(animalAge, out petAge);
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (!validEntry);

                    ourAnimals[i, 2] = "Age: " + animalAge;
                }

                // Verify pet physical description
                if (ourAnimals[i, 4] == "Physical description: " || ourAnimals[i, 4] == "Physical description: tbd")
                {
                    bool validEntry = false;
                    do
                    {

                        Console.WriteLine($"Missing physical description for {ourAnimals[i, 0]}. Specify (size, color, breed, gender, weight, housebroken)");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            animalPhysicalDescription = readResult;

                            if (animalPhysicalDescription.Length == 0)
                            {
                                validEntry = false;
                                Console.WriteLine("Cannot enter nothing.");
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (!validEntry);

                    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                }
            }


            Console.WriteLine();
            Console.WriteLine("Age and physical descriptions are complete for all our friends :)");
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "4":
            // Add menu to verify pet nickname and personality description, same as above essentially.
            for (int i = 0; i < maxPets; i++)
            {
                // Skip if ID is blank
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                // Verify nickname
                if (ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 3] == "Nickname: tbd")
                {
                    bool validEntry = false;
                    do
                    {

                        Console.WriteLine($"Missing nickname for {ourAnimals[i, 0]}. What should we call them? :)");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            animalNickname = readResult;

                            if (animalNickname.Length == 0)
                            {
                                validEntry = false;
                                Console.WriteLine("Cannot enter nothing.");
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (!validEntry);

                    ourAnimals[i, 3] = "Nickname: " + animalNickname;
                }


                // Verify pet personality description
                if (ourAnimals[i, 5] == "Personality: " || ourAnimals[i, 5] == "Personality: tbd")
                {
                    bool validEntry = false;
                    do
                    {

                        Console.WriteLine($"Missing personality description for {ourAnimals[i, 3]}. Specify (energy, friendliness, etc.)");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            animalPersonalityDescription = readResult;

                            if (animalPersonalityDescription.Length == 0)
                            {
                                validEntry = false;
                                Console.WriteLine("Cannot enter nothing.");
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (!validEntry);

                    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Nickname and personality descriptions are complete for all our friends :)");
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "5":
            // Edit animals age
            for (int i = 0; i < maxPets; i++)
            {
                // Skip if ID is blank
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }

                if (ourAnimals[i, 2] == "Age: ?")
                {
                    bool validEntry = false;
                    int petAge;

                    do
                    {
                        Console.WriteLine($"No age for {(ourAnimals[i, 0])}. Do you want to add their age? y/n");

                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            menuSelection = readResult;
                            if (menuSelection == "n")
                            {
                                validEntry = true;
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Input age.");

                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalAge = readResult;

                                    if (ourAnimals[i, 2] == "Age: ?")
                                    {
                                        validEntry = int.TryParse(animalAge, out petAge);
                                    }
                                    else
                                    {
                                        validEntry = true;
                                    }
                                }
                            }

                            ourAnimals[i, 2] = "Age: " + animalAge;
                        }
                    } while (!validEntry);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                Console.WriteLine($"{(i + 1)}: {ourAnimals[i, 3]},  ({ourAnimals[i, 0]}) is {ourAnimals[i, 2].Replace("Age: ", "")} years old.");
            }
            Console.WriteLine();
            
            
            int selectedRow = -1;
            bool rowSelectionValid = false;

            do
            {
                Console.WriteLine("Enter the row number of the animal whose age you wish to edit:");
                readResult = Console.ReadLine();

                if (readResult != null && int.TryParse(readResult, out selectedRow))
                {
                    if (selectedRow >= 1 && selectedRow <= maxPets && ourAnimals[selectedRow - 1, 0] != "ID #: ")
                    {
                        Console.WriteLine($"You selected row #{selectedRow}: {ourAnimals[selectedRow - 1, 3]}");
                        rowSelectionValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter a valid row number.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a numeric value.");
                }
            } while (!rowSelectionValid);

            bool ageEntryValid = false;
            string newAge = "";
            int ageInt;

            do
            {
                Console.WriteLine("Enter the new age (or '?' if unknown):");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    newAge = readResult;
                    if (newAge == "?")
                    {
                        ageEntryValid = true;
                    }
                    else
                    {
                        ageEntryValid = int.TryParse(newAge, out ageInt);
                        if (!ageEntryValid)
                        {
                            Console.WriteLine("Please enter a valid number or '?'");
                        }
                    }
                }
            } while (!ageEntryValid);

            // Update the age
            ourAnimals[selectedRow - 1, 2] = "Age: " + newAge;
            Console.WriteLine("Age updated successfully! Press Enter to continue.");
            Console.ReadLine();
            break;
        case "6":
            // Edit animals personality description
            for (int i = 0; i < maxPets; i++)
            {
                // Skip if ID is blank
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }

                if (ourAnimals[i, 5] == "Personality: ")
                {
                    bool validEntry = false;

                    do
                    {
                        Console.WriteLine($"No personality for {(ourAnimals[i, 0])}. Do you want to add their personality? y/n");

                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            menuSelection = readResult;
                            if (menuSelection == "n")
                            {
                                validEntry = true;
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Input personality details (energy, cuddliness, etc.).");

                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalPersonalityDescription = readResult;

                                    if (animalPersonalityDescription.Length == 0)
                                    {
                                        Console.WriteLine("Personality can't be empty.");
                                    }
                                    else
                                    {
                                        validEntry = true;
                                        ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                                    }
                                }
                            }
                        }
                    } while (!validEntry);
                }
            }

            Console.WriteLine();
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                {
                    continue;
                }
                Console.WriteLine($"{(i + 1)}: {ourAnimals[i, 3]}. {ourAnimals[i, 5]}");
            }
            Console.WriteLine();
            
            
            int selectedRow6 = -1;
            bool rowSelectionValid6 = false;

            do
            {
                Console.WriteLine("Enter the row number of the animal whose personality you wish to edit:");
                readResult = Console.ReadLine();

                if (readResult != null && int.TryParse(readResult, out selectedRow6))
                {
                    if (selectedRow6 >= 1 && selectedRow6 <= maxPets && ourAnimals[selectedRow6 - 1, 0] != "ID #: ")
                    {
                        Console.WriteLine($"You selected row #{selectedRow6}: {ourAnimals[selectedRow6 - 1, 3]}");
                        rowSelectionValid6 = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter a valid row number.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a numeric value.");
                }
            } while (!rowSelectionValid6);

            bool personalityEntryValid = false;
            string newPersonality = "";

            do
            {
                Console.WriteLine("Enter the new personality (or '?' if unknown):");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    newPersonality = readResult;
                    if (newPersonality == "?")
                    {
                        personalityEntryValid = true;
                    }
                    else if (newPersonality.Length == 0)
                    {
                        Console.WriteLine("Must enter personality details.");
                    }
                    else
                    {
                        personalityEntryValid = true;
                    }
                }
            } while (!personalityEntryValid);

            // Update the personality
            ourAnimals[selectedRow6 - 1, 5] = "Personality: " + newPersonality;
            Console.WriteLine("Personality updated successfully! Press Enter to continue.");
            Console.ReadLine();
            break;
        case "7":
            // Display all pets of certian species and physical description
            bool speciesValid = false;
            string speciesFilter = "";

            do
            {
                Console.WriteLine();
                Console.WriteLine("Select the species you want to filter by (cat/dog):");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    speciesFilter = readResult.ToLower();
                    if (speciesFilter != "dog" && speciesFilter != "cat")
                    {
                        Console.WriteLine("Must select one of 'cat' or 'dog'");
                    }
                    else
                    {
                        speciesValid = true;
                    }
                }
            } while (!speciesValid);

            Console.WriteLine();
            Console.Clear();
            Console.WriteLine($"Listing all {speciesFilter}s:");
            Console.WriteLine();

            bool anyFound = false;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 1] == "Species: " + speciesFilter)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                    Console.WriteLine();
                    anyFound = true;
                }
            }

            if (!anyFound)
            {
                Console.WriteLine($"No {speciesFilter}s found.");
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        default:
            break;
    }

} while (menuSelection != "exit");