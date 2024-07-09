using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    // name of the wave
    public string waveName;
    public int enemyNumber;
    public GameObject[] enemyType;
    public float spawnInterval;
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;

    // randomly spawn
    public Transform[] spawnPoints;

    // set up new list for enemies
    //public List<Enemies> enemies = new List<Enemies>();
    //public int currentWave;
    //public int waveValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void GenerateWave()
    //{
      //  waveValue = currentWave * 10;
        //GenerateEnemies();
    //}

   // public void GenerateEnemies()
    //{

    //}
}

// to edit in the inspector
//[System.Serializable]

//public class Enemies
//{
   // public GameObject enemyPrefab;
    // u dont hav cost, change it to something else later
    //public int cost;
//}
