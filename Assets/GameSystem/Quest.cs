using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{

    public string questId { get; set; }
    public string questName { get; set; }
    public string questDescription { get; set; }
    public string questReward { get; set; }




    public Quest(string questId, string questName, string questDescription, string questReward)
    {
        this.questId = questId;
        this.questName = questName;
        this.questDescription = questDescription;
        this.questReward = questReward;


    }



}
