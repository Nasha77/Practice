using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //show in inspector

public class Quest //stores feilds that match the the excel/json file
{
    public string questId;
    public string questName;
    public string questDescription;
    public string questReward;


    public class QuestDataList
    {
        public List<Quest> quest;
    }
}
