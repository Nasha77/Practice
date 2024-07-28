// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI rewardText; // Store the reward text component

    private Quest currentQuest; // Store the current quest
    private int enemyKillCount = 0; // tracks no. of enemies killed by player

    void Start()
    {
        //Retrieve the quest with the specified ID from the game
        currentQuest = Game.GetQuestRefById("Q101"); // Get the quest with ID "Q101"

        if (currentQuest != null)
        {
            // Set the reward text to display the quest description
            rewardText.text = "Quest: " + currentQuest.questDescription;
            rewardText.enabled = true; // Enable the reward text ui component
        }
        else
        {
            // enable reward text ui componentt
            rewardText.enabled = true;
        }
    }

    // when enemy is killed
    public void OnEnemyKilled()
    {
        // increment enemy kill count
        enemyKillCount++;


        // basically checks if the player has killed enough enemies to complete the quest
        if (enemyKillCount >= 1) // Change 1 to the required kill count if necessary
        {

            // Update the reward text to display the quest reward
            if (currentQuest != null)
            {
                rewardText.text = "Reward: " + currentQuest.questReward;
            }
            else
            {
                // if quest not found then display this
                rewardText.text = "Quest not found!";
            }
        }
    }
}