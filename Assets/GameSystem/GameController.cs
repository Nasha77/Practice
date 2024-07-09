using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DataManager dataManager; //call the data
    // Start is called before the first frame update
    void Start()
    {
        dataManager = GetComponent<DataManager>();
        dataManager.LoadRefData();

        Debug.Log("Character" + Game.GetCharacterList().Count); //debugger
        Debug.Log("Weapon" + Game.GetWeaponList().Count); //debugger

        //set player
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
