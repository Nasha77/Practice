using System.Collections;
using System.Collections.Generic;
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

        if (currentQuest != null)
        {
            // Display the quest description
            Debug.Log("Description: " + currentQuest.questDescription);

            // Set the reward text to display the quest description
            rewardText.text = "Quest: " + currentQuest.questDescription;
            rewardText.enabled = true; // Enable the reward text
        }
        else
        {
            Debug.LogError("Quest with ID 'Q101' not found!");
            rewardText.text = "Quest not found!";
            rewardText.enabled = true;
        }
    }

    public void OnEnemyKilled()
    {
        enemyKillCount++;
        Debug.Log("Enemy killed. Current kill count: " + enemyKillCount);

        // Check if the quest is complete
        if (enemyKillCount >= 1) // Change 1 to the required kill count if necessary
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