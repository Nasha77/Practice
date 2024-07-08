using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //show in inspector

public class CharacterRef //stores feilds that match the the excel/json file
{
    public string characterId;
    public string characterName;
    public string description;
    public int characterHealth;
    public int characterAtk;
    public int characterSpeed;

}
