// Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents dynamic data that will be stored and written to a JSON file
public class DynamicData
{
    // These three variables store data from the Player class
    // They will be serialized to JSON and written to SaveData.txt

    // Unique identifier for the player
    public string id;

    // The current character being played
    public string currentCharacter;

    // The current weapon being used by the character
    public string currentCharacterWeapon;
}
