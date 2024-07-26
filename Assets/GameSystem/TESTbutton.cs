using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TESTbutton : MonoBehaviour
{

    public Button testButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TestButton()
    {
        SceneManager.LoadScene("CONVO 1");
    }
}
