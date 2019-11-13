using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Brain : MonoBehaviour
{
    public int Health;

    public GameObject[] Players;


   
    [SerializeField]
    GameObject Closest_Enemy = null;

    public GameObject Bullet;
    public Transform Bullet_Spawn;
    public float Seconds_In_Between;

    public float Bullet_Force;

    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine("Shoot_IT");
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    void Look()
    {
        // for greatest distance
        float Distance_To_Closest = Mathf.Infinity;
       
       

        foreach (GameObject Next_Player in Players)
        {
            float Distance_To_Player = (Next_Player.transform.position - transform.position).sqrMagnitude;

            if(Next_Player.GetComponent<Player_Health>().Player_Alive == true)
            {
                if (Distance_To_Player < Distance_To_Closest)
                {
                    Distance_To_Closest = Distance_To_Player;
                    Closest_Enemy = Next_Player;
                }
            }


        //    transform.right = Closest_Enemy.transform.position - transform.position;

        }


    }

    IEnumerator Shoot_IT()
    {
        while (true)
        {
            GameObject New_Bullet =  Instantiate(Bullet, Bullet_Spawn.position, Quaternion.identity);

            New_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force);

            yield return new WaitForSeconds(Seconds_In_Between);

        }

    }
}
