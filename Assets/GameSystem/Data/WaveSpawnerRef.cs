// Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Show in Inspector
public class WaveSpawnerRef //stores feilds that match the the excel/json file
{
    public string waveId;
    public string waveName;
    public string enemyId;
    public int enemyCount;
    public int totalHP;

    [System.Serializable]
    public class WaveDataList
    {
        public List<WaveSpawnerRef> waveSpawner;
    }

    
}

