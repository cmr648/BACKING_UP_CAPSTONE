using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_For_Camera : MonoBehaviour
{
    public Transform Player_1;
    public Transform Player_2;

    public float Max_Distance;
    public float Current_Distance;

    public Camera Main_Camera;
    public Camera Second_Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Current_Distance = Vector2.Distance(Player_1.position, Player_2.position);

        if(Current_Distance > Max_Distance)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(transform.localScale.x, 1, transform.localScale.z), Time.deltaTime *2);
            Second_Camera.gameObject.SetActive(true);
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(transform.localScale.x, 0, transform.localScale.z), Time.deltaTime *2);
            Second_Camera.gameObject.SetActive(false);

        }
    }
}
