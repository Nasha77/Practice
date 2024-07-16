using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavespawn 
{
    
    public string waveId { get; }
    public string waveName { get; }
    public string enemyId { get; }
    public int enemyCount { get; }
    public int totalHP { get; }

    public Wavespawn(string waveId, string waveName, string enemyId, int enemyCount, int totalHP)
    {
        this.waveId = waveId;
        this.waveName = waveName;
        this.enemyId = enemyId;
        this.enemyCount = enemyCount;
        this.totalHP = totalHP;
    }

}
