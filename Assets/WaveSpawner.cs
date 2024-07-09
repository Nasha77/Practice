using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // set up new list for enemies
    public List<Enemies> enemies = new List<Enemies>();
    public int currentWave;
    public int waveValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();
    }

    public void GenerateEnemies()
    {

    }
}

// to edit in the inspector
[System.Serializable]

public class Enemies
{
    public GameObject enemyPrefab;
    // u dont hav cost, change it to something else later
    public int cost;
}
