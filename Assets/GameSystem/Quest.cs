// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{

    public string questId { get; }
    public string questName { get; }
    public string questDescription { get; }
    public string questReward { get; }




    public Quest(string questId, string questName, string questDescription, string questReward)
    {
        this.questId = questId;
        this.questName = questName;
        this.questDescription = questDescription;
        this.questReward = questReward;


    }



}
