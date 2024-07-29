//NASHA
using UnityEngine;
using UnityEngine.UI;

public class SaveDataDisplay : MonoBehaviour
{
    public Text saveDataText; // Reference to the Text component
    private DataManager dataManager; // Reference to the DataManager

    void Start()
    {
        // Find the DataManager object
        dataManager = FindObjectOfType<DataManager>();

        // Ensure saveDataText is assigned
        if (saveDataText == null)
        {
            Debug.LogError("SaveDataText is not assigned in the inspector.");
            return;
        }

        // Display the saved data
        DisplaySavedData();
    }

    void DisplaySavedData()
    {
        // Get the saved data string from DataManager
        string savedData = dataManager.GetSavedDataString();

        // Set the text component to display the saved data
        saveDataText.text = savedData;
    }
}
