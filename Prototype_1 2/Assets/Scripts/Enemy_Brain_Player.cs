using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Brain_Player : MonoBehaviour
{

    public GameObject[] Players;


    [SerializeField]
    Enemy_Brain_2 Brain;

    [SerializeField]
    GameObject Closest_Enemy = null;

    public GameObject Bullet;
    public Transform Bullet_Spawn;
    public float Seconds_In_Between;

    public float Bullet_Force;

    public float Max_Player_DIstacne;

    public float Enemy_Speed_Follow_Player;

    // Start is called before the first frame update
    void Start()
    {

        Brain = GetComponent<Enemy_Brain_2>();
        Players = GameObject.FindGameObjectsWithTag("Player");

        StartCoroutine("Shoot_IT");

    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log(Vector2.Distance(transform.position, Closest_Enemy.transform.position));

        if (Vector2.Distance(transform.position, Closest_Enemy.transform.position) <= Max_Player_DIstacne)
        {
            Brain.enabled = false;

            transform.position = Vector2.MoveTowards(transform.position, Closest_Enemy.transform.position, Time.deltaTime * Brain.Enemy_Speed / Enemy_Speed_Follow_Player);
        }
        else
        {
            Brain.enabled = true;
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
