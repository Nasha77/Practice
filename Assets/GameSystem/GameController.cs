using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DataManager dataManager; //call the data
    // Start is called before the first frame update

    public string initCharacter; //set in inspector
    public string initWeapon;
    void Start()
    {
        dataManager = GetComponent<DataManager>();
        dataManager.LoadRefData();

        Debug.Log("Character" + Game.GetCharacterList().Count); //debugger
        Debug.Log("Weapon" + Game.GetWeaponList().Count); //debugger

        //set player
        Game.SetPlayer(new Player("1", initCharacter, initWeapon)); //will be passed into new player 


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
