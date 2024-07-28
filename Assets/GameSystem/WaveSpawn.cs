//Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// wavespawn class representing an wave in the game.
public class Wavespawn 
{
    
    public string waveId { get; }
    public string waveName { get; }
    public string enemyId { get; }
    public int enemyCount { get; }
    public int totalHP { get; }

    // Constructor to create a new wavespawner instance.
    // Called when the game loads wavespawner data.
    // Initializes the wavespawner's properties with the provided values.
    public Wavespawn(string waveId, string waveName, string enemyId, int enemyCount, int totalHP)
    {
        this.waveId = waveId;
        this.waveName = waveName;
        this.enemyId = enemyId;
        this.enemyCount = enemyCount;
        this.totalHP = totalHP;
    }

}
