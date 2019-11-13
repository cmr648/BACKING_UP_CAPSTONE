using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Brain_2 : MonoBehaviour
{
    public Transform[] Enemy_Points;

    public Transform Current_Enemy_Point;

    public int Index;

    public float Enemy_Speed;


    // Start is called before the first frame update
    void Start()
    {
        Index = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Current_Enemy_Point = Enemy_Points[Index];

        transform.position = Vector2.MoveTowards(transform.position, Current_Enemy_Point.position, Time.deltaTime * Enemy_Speed);

        if (Vector2.Distance(transform.position, Enemy_Points[Index].position) <=.1f){
            Index += 1;
        }


    }

  
}
