using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private GameObject player;
    public float speed;

    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetupEnemy(GameObject player)
    {
        this.player = player;
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            return;
        }
       
        dist = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.position;

        // enemy move towards the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
