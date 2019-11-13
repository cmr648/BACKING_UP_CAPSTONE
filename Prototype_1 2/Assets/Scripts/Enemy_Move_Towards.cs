using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move_Towards : MonoBehaviour
{
    public GameObject Closest_Enemy = null;

    public float Enemy_Speed;

    public GameObject[] Players;

    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        Look();

        transform.position = Vector2.MoveTowards(transform.position, Closest_Enemy.transform.position, Time.deltaTime * Enemy_Speed);
       


    }


    void Look()
    {
        // for greatest distance
        float Distance_To_Closest = Mathf.Infinity;



        foreach (GameObject Next_Player in Players)
        {
            float Distance_To_Player = (Next_Player.transform.position - transform.position).sqrMagnitude;

            if (Next_Player.GetComponent<Player_Health>().Player_Alive == true)
            {
                if (Distance_To_Player < Distance_To_Closest)
                {
                    Distance_To_Closest = Distance_To_Player;
                    Closest_Enemy = Next_Player;
                }
            }


            transform.right = Closest_Enemy.transform.position - transform.position;

        }


    }
}
