using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Behavior : MonoBehaviour
{
    public Transform[] Movement_Transforms;

    public float Speed;

    public float Wait_Time;
    

    [SerializeField]
    int index;

    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Change_Index();
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Movement_Transforms[index].position, Time.deltaTime * Speed);

        if(Vector2.Distance(transform.position,Movement_Transforms[index].position) <= .3f)
        {

            Timer += Time.deltaTime;
          
        }

        if(Timer >= Wait_Time)
        {
            Timer = 0;
            Change_Index();
        }



    }

    void Change_Index()
    {
        index = Random.Range(0, Movement_Transforms.Length);
    }



}
