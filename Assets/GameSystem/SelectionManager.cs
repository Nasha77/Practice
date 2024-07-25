using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class SelectionManager : MonoBehaviour
{

    public Image image;
    private List<Character> characterText;
    private List<Weapon> weapon;
   
    public GameObject charaSkin;
    public List<Sprite> sprite;
    public int characterIndex = 0;
    public TextMeshProUGUI characterName;

    public static SelectionManager instanceRef;

    public SpriteRenderer playerSprite;


    void Start()
    {
        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instanceRef != this)
        {
            Destroy(gameObject);
        }
        InitializeMenu();
    }

    public void InitializeMenu()
    {
        characterText = Game.GetCharacterList();
        UpdateMenuText();
    }

    private void UpdateMenuText()
    {

        Debug.Log(characterText[characterIndex].characterName);
        // get data from excel
        characterName.text = characterText[characterIndex].characterName;
        
        

        playerSprite.sprite = sprite[characterIndex];

    }

    public void NextOption()
    {
        characterIndex++;
        if(characterIndex == characterText.Count)
        {
            characterIndex = 0;
        }
        UpdateMenuText();

       // playerSprite.sprite = SetSprite();

    }

    public void BackOption()
    {
        characterIndex--;
        if(characterIndex < 0)
        {
            characterIndex = characterText.Count - 1;
        }
        UpdateMenuText();

        //playerManager.UpdatePlayerStats();
    }

    public void PlayOption()
    {
        // Set the current character ID
        Game.GetPlayer().SetCurrentCharacter(characterText[characterIndex].characterId);
        Debug.Log("Selected Character ID: " + characterText[characterIndex].characterId);

        // Set the current character weapon ID
        Game.GetPlayer().SetCurrentCharacterWeapon(Game.GetWeaponList()[characterIndex].weaponID);
        Debug.Log("Selected Weapon ID: " + Game.GetWeaponList()[characterIndex].weaponID);

        // Save the player data
        GameController.instanceRef.dataManager.SavePlayerData();

        SceneManager.LoadScene("CONVO 2");
    }



    //public void SetSprite(string name)
    //{
    //    // load sprite and make sprite appear on scene
    //    AssetManager.LoadSprite(name, (Sprite sp) =>
    //    {
    //        gameObject.GetComponent<SpriteRenderer>().sprite = sp;


    //    });
    //}
}
