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
   
    public GameObject charaSkin;
    public List<Sprite> sprite;
    private int characterIndex = 0;
    public TextMeshProUGUI characterName;


    public void InitializeMenu( List<Character> characterText)
    { 
        this.characterText = characterText;

        UpdateMenuText();
    }

    private void UpdateMenuText()
    {

        Debug.Log(characterText[characterIndex].characterName);
        // get data from excel
        characterName.text = characterText[characterIndex].characterName;
        
        

        image.sprite = sprite[characterIndex];

    }

    public void NextOption()
    {
        characterIndex++;
        if(characterIndex == characterText.Count)
        {
            characterIndex = 0;
        }
        UpdateMenuText();

        
    }

    public void BackOption()
    {
        characterIndex--;
        if(characterIndex < characterText.Count)
        {
            characterIndex = characterText.Count - 1;
        }
        UpdateMenuText();
    }

    public void PlayOption()
    {
        

        PlayerPrefs.SetInt("charaSkin", characterIndex);

        //characterText[characterIndex].characterId
        Game.GetPlayer().SetCurrentCharacter(characterText[characterIndex].characterId);

        SceneManager.LoadScene("GameScene");
    }
}
