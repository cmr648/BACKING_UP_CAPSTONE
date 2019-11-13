using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    Rigidbody2D My_Rigidbody;

    public float Playerspeed;

    Vector2 input;

    Vector2 Joystick_Input;

    public Multiplayer_Checker My_Multiplayer_Checker;

    public bool Can_Move;

    // Start is called before the first frame update
    void Start()
    {
        My_Rigidbody = GetComponent<Rigidbody2D>();

        My_Multiplayer_Checker = GetComponent<Multiplayer_Checker>();
        Can_Move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(My_Multiplayer_Checker.Player == 1)
        {
            Joystick_Input = new Vector2(Input.GetAxis("Player_1_Horizontal_Axis"), -Input.GetAxis("Player_1_Vertical_Axis"));
            Joystick_Input.Normalize();
          //  Debug.Log(Joystick_Input);
            transform.eulerAngles = new Vector3(0,0, Mathf.Atan2(-Input.GetAxis("Player_1_Vertical_Axis"), Input.GetAxis("Player_1_Horizontal_Axis")) * 180 / Mathf.PI);


            //if(Mathf.Abs(Joystick_Input.x) > Mathf.Abs(Joystick_Input.y))
            //{
            //    if(Joystick_Input.x < 0)
            //    {
            //        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

            //    }
            //    else if (Joystick_Input.x > 0)
            //    {
            //        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            //    }
            //}
            //else
            //{
            //    if (Joystick_Input.y > 0)
            //    {
            //        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

            //    }
            //    else if (Joystick_Input.y < 0)
            //    {
            //        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));

            //    }

            //}

            if (Input.GetButtonDown("Player_1_R2"))
            {
                Can_Move = false;
            }
            if (Input.GetButtonUp("Player_1_R2"))
            {
                Can_Move = true;
            }
        }

        if(My_Multiplayer_Checker.Player == 1)
        {
            if(Can_Move == true)
            {
                My_Rigidbody.MovePosition((Vector2)transform.position + Joystick_Input * Time.deltaTime * Playerspeed);
                input = Vector2.zero;
            }
           



        }
        else
        {
            My_Rigidbody.MovePosition((Vector2)transform.position + input * Time.deltaTime * Playerspeed);
            input = Vector2.zero;

        }



        if (Input.GetKey(Right))
        {
            input += new Vector2(1, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        }

        if (Input.GetKey(Left))
        {
            input += new Vector2(-1, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }

        if (Input.GetKey(Up))
        {
            input += new Vector2(0, 1);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }

        if (Input.GetKey(Down))
        {
            input += new Vector2(0, -1);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }

     
    }
}
