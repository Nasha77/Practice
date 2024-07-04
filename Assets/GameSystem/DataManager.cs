using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.U2D.Animation;

public class DataManager : MonoBehaviour
{
    public void LoadRefData()
    {
        // Load speaker data
        string filePath = Path.Combine(Application.dataPath, "GameSystem/Data/CharacterRef.txt"); //where is the file 
        string dataString = File.ReadAllText(filePath); //
    } 
}