// Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //show in inspector

public class CharacterRef //// This class represents a reference to a character, stores feilds that match the the excel/json file
{
    public string characterId;
    public string characterName;
    public string description;
    public int characterHealth;
    public int characterAtk;
    public int characterSpeed;
    public string characterSprite;
}

// This class represents a list of character references
public class CharcterDataList
{
    // List of character references
    // Use the list to populate
    public List<CharacterRef> characterRef;
}