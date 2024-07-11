using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //show in inspector

public class EnemyRef //stores feilds that match the the excel/json file
{
    public string enemyId;
    public string enemyName;
    public int enemyHealth;
    public int enemyAtk;
    public int enemySpeed;
    public int enemyEXP; //how many exp it will drop

    public class EnemyDataList
    {
        public List<EnemyRef> enemyRef;
    }
}
