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
   

    public static GameController instanceRef;

    void Awake()
    {
        if(instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instanceRef != this)
        {
            Destroy(gameObject);
        }



        dataManager = GetComponent<DataManager>();
        dataManager.LoadRefData();

        //character selection
        Debug.Log(Game.GetCharacterList());

        // shd be the default selection
        //set player
        //auto load funtion in if
        if (!dataManager.LoadPlayerData()) //if its true it will ignore what is in the bracket if fails shows that there is no exsisting data
        {
            Game.SetPlayer(new Player("1", initCharacter, initWeapon)); //will be passed into new player 
        }
        Game.GetPlayer().GetCurrentCharacter();

        //selectionManager.InitializeMenu(Game.GetCharacterList()); //PUT IT BACK LATER
        // save data in game?? then put it in p;layer??
        // store in game mainplayer, then in player currentplayer



        Debug.Log("NOW" + initCharacter);
        Debug.Log("NOW" + initWeapon);

        Debug.Log("Character" + Game.GetCharacterList().Count); //debugger
        Debug.Log("Weapon" + Game.GetWeaponList().Count); //debugger



    }

  
}
