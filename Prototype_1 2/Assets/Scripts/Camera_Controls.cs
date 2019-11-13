using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controls : MonoBehaviour
{
    public Camera My_Player_Camera;

    public float Camera_Speed;

    Vector3 Target_Vector3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        My_Player_Camera.transform.position = Vector3.Lerp(My_Player_Camera.transform.position, new Vector3(Target_Vector3.x, Target_Vector3.y, -10), Time.deltaTime * Camera_Speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // My_Player_Camera.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y,-10);

        Target_Vector3.x = collision.transform.position.x;
        Target_Vector3.y = collision.transform.position.y;

    }

}