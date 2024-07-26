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
        // Load the quest data from the Game class
        List<Quest> questList = Game.GetQuestList();

        // Create a Quest object from the first QuestRef in the list
        currentQuest = questList[0];

        // Display the quest description
        Debug.Log("Quest: " + currentQuest.questName);
        Debug.Log("Description: " + currentQuest.questDescription);
    }

    public void OnEnemyKilled()
    {
        enemyKillCount++;

        // Check if the quest is complete
        if (enemyKillCount >= 1)
        {
            // Reward the player
            Debug.Log("Quest complete! Reward: " + currentQuest.questReward);
            // Display the reward text
            rewardText.text = "Reward: " + currentQuest.questReward;
            // Add the reward to the player's inventory
            //...

            // Reset the quest
            currentQuest = null;
            enemyKillCount = 0;
        }
    }
}