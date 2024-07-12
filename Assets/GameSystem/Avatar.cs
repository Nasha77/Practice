using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Avatar
{
    public string refId { get; }
    public string name { get; }
    public int health { get; }
    public int attack { get; }
    public int speed { get; }

    public Avatar(string refId, string name, int health, int attack, int speed)
    {
        this.refId = refId;
        this.name = name;       
        this.health = health;
        this.attack = attack;
        this.speed = speed;
    }
}
