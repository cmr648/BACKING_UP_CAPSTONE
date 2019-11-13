using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_Brain : MonoBehaviour
{
    [SerializeField]
    GameObject Closest_Enemy = null;

    public GameObject[] Players;


    public GameObject Bullet;
    public Transform Bullet_Spawn;
    public float Seconds_In_Between;

    public float Bullet_Force;

    public bool Started_Shooting;

    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
       
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

            if (Next_Player.GetComponent<Player_Health>().Player_Alive == true)
            {
                if (Distance_To_Player < Distance_To_Closest)
                {
                    Distance_To_Closest = Distance_To_Player;
                    Closest_Enemy = Next_Player;
                }
            }


            if(Vector2.Distance(transform.position,Closest_Enemy.transform.position) < 9)
            {
                transform.right = Closest_Enemy.transform.position - transform.position;
               
                 if (Started_Shooting == false)
                {

                    StartCoroutine("Shoot_IT");
                    Started_Shooting = true;
                }

            }
            else
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
                StopCoroutine("Shoot_IT");
                Started_Shooting = false;
            }


        }


    }


    IEnumerator Shoot_IT()
    {
        while (true)
        {
            GameObject New_Bullet = Instantiate(Bullet, Bullet_Spawn.position, Quaternion.identity);

            New_Bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Bullet_Force);

            yield return new WaitForSeconds(Seconds_In_Between);

        }

    }
}
