using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using TMPro;


public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI rewardText; // Store the reward text component

    private Quest currentQuest; // Store the current quest
    private int enemyKillCount = 0; // Store the player's progress

    void Start()
    {
        currentQuest = Game.GetQuestRefById("Q101"); // Get the quest with ID "Q101"

        // Display the quest description
        Debug.Log("Quest: " + currentQuest?.questName);
        Debug.Log("Description: " + currentQuest?.questDescription);

        // Set the reward text to display the quest description
        rewardText.text = "Quest: " + currentQuest?.questDescription;
        rewardText.enabled = true; // Enable the reward text

        if (currentQuest == null)
        {
            Debug.LogError("Quest with ID 'Q101' not found!");
        }
    }

    public void OnEnemyKilled()
    {
        enemyKillCount++;
        Debug.Log("DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD"+enemyKillCount);
        // Check if the quest is complete
        if (enemyKillCount >= 1)
        {
            // Reward the player
            Debug.Log("Quest complete! Reward: " + currentQuest?.questReward);


            // Update the reward text to display the quest reward
            if (currentQuest != null)
            {
                rewardText.text = "Reward: " + currentQuest.questReward;
            }
            else
            {
                rewardText.text = "Quest not found!";
            }
        }
    }
}