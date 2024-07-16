using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameController : MonoBehaviour //start funtion and calls data manager
{
    public DataManager dataManager; //call the data

    public SelectionManager selectionManager; // ref to selectionmanager script

    // Start is called before the first frame update

    public string initCharacter; //set in inspector
    public string initWeapon;
    


    void Start()
    {
        // selection SCENE
        //if(characters.Length > 0 && currentCharacter != null)
        //{

         //   currentCharacter = characters[0];
       // }

        dataManager = GetComponent<DataManager>();
        dataManager.LoadRefData();

        //character selection
        Debug.Log(Game.GetCharacterList());


        Game.GetPlayer().GetCurrentCharacter();

        selectionManager.InitializeMenu(Game.GetCharacterList());
        // save data in game?? then put it in p;layer??



        Debug.Log("NOW" + initCharacter);
        Debug.Log("NOW" + initWeapon);

        Debug.Log("Character" + Game.GetCharacterList().Count); //debugger
        Debug.Log("Weapon" + Game.GetWeaponList().Count); //debugger

        //set player
        Game.SetPlayer(new Player("1", initCharacter, initWeapon)); //will be passed into new player 


    }

    // sELECTION SCENE

    //public void SetCharacter(Character character)
    //{
    //    currentCharacter = character;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
