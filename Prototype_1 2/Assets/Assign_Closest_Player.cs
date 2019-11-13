using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;

public class Assign_Closest_Player : MonoBehaviour
{
    public GameObject Closest_Enemy;

    public GameObject[] Players;

    public bool Holding_Trophy;

    public GameObject Trophy;

    [SerializeField]
    public AIDestinationSetter My_Destition_Setter;
    public AIPath My_AI_PATH;

    public Enemy_Brain My_Enemy_Brain;

    public float Speed_Yes_Trophy;
    public float Speed_No_Trophy;

    public float Bullet_Rate_With_Trophy;
    public float Bullet_Rate_Without_Trophy;

    // Start is called before the first frame update
    private void Awake()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        My_Destition_Setter = GetComponent<AIDestinationSetter>();
        My_AI_PATH = GetComponent<AIPath>();

        Trophy = GameObject.FindGameObjectWithTag("Trophy");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Holding_Trophy = Trophy.GetComponent<Trophy_Timer>().Holding_Trophy;

        Look();

        if (Holding_Trophy == true)
        {
            My_Destition_Setter.target = Trophy.transform.parent;
            My_AI_PATH.speed = Speed_Yes_Trophy;
            My_Enemy_Brain.Seconds_In_Between = Bullet_Rate_With_Trophy;

        }
        else
        {
            My_Destition_Setter.target = Closest_Enemy.transform;
            My_AI_PATH.speed = Speed_No_Trophy;
            My_Enemy_Brain.Seconds_In_Between = Bullet_Rate_Without_Trophy;
        }

       



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


        }

        Vector3 dir = Closest_Enemy.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
}
