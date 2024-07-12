using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> selection = new List<Sprite>();
    private int selectedChara = 0;
    public GameObject player;

    public void Next()
    {
        selectedChara = selectedChara + 1;
        if(selectedChara == selection.Count)
        {
            selectedChara = 0;
        }
        sr.sprite = selection[selectedChara];
    }

    public void Back()
    {
        selectedChara = selectedChara - 1;
        if (selectedChara < 0)
        {
            selectedChara = selection.Count - 1;
        }
        sr.sprite = selection[selectedChara];
    }

    public void PlayGame()
    {
        // load scene.
    }
}
