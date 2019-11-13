using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Weapon : MonoBehaviour
{

    public GameObject Holder;

    public bool Holding_Weapon;
    public bool Holding_Key;
    public bool Holding_Health_Pack;
    public bool Holding_Treasure;
    public bool Holding_Trophy;

    public float Throw_Force;

    public KeyCode Hold_Button;
    public KeyCode Throw_Button;

    public GameObject Weapon_Held;

    Player_Health My_Player_Health;

    public Color Original_Color;

    public Shooting_Script My_Shooting_Script;
   
    public float Timer_Time;
    public float Time_To_Throw;

    public Multiplayer_Checker My_Multiplayer_Checker;

    // Start is called before the first frame update
    void Start()
    {
        My_Player_Health = GetComponent<Player_Health>();
        Original_Color = GetComponent<SpriteRenderer>().color;

        My_Shooting_Script = GetComponent<Shooting_Script>();

        My_Multiplayer_Checker = GetComponent<Multiplayer_Checker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (My_Multiplayer_Checker.Player == 1)
        {
            if (Input.GetKeyDown(Hold_Button) || Input.GetButtonDown("Player_1_Circle"))
            {
                Drop_Weapon();
            }

            if (Input.GetKeyDown(Throw_Button) || Input.GetButtonDown("Player_1_Triangle"))
            {
                Thow_Weapon();
            }
        }
        else
        {

            if (Input.GetKeyDown(Hold_Button))
            {
                Drop_Weapon();
            }

            if (Input.GetKeyDown(Throw_Button))
            {
                Thow_Weapon();
            }
        }






    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Treasure")
        {
            Drop_Weapon();
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            collision.transform.parent = Holder.transform;
            collision.transform.localPosition = new Vector3(0, 0, 0);
            collision.transform.localRotation = Holder.transform.localRotation;

            //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Holding_Weapon = false;
            Holding_Key = false;
            Holding_Health_Pack = false;
            Holding_Treasure = true;
            Holding_Trophy = false;
        }

        if (collision.gameObject.tag == "Trophy")
        {
            Drop_Weapon();
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            collision.transform.parent = Holder.transform;
            collision.transform.localPosition = new Vector3(0, 0, 0);
            collision.transform.localRotation = Holder.transform.localRotation;

            //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Holding_Weapon = false;
            Holding_Key = false;
            Holding_Health_Pack = false;
            Holding_Treasure = false;
            Holding_Trophy = true;
        }

        if (collision.gameObject.tag == "Weapon")
        {
            Drop_Weapon();
            collision.gameObject.GetComponent<Spin>().Spinning = false;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            collision.transform.parent = Holder.transform;
            collision.transform.localPosition = new Vector3(0, 0, 0);
            collision.transform.localRotation = Holder.transform.localRotation;


            My_Shooting_Script.Amount_Of_Bulelts = 20;

            //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Holding_Weapon = true;
            Holding_Key = false;
            Holding_Health_Pack = false;
            Holding_Treasure = false;
            Holding_Trophy = false;



            Weapon_Held = collision.gameObject;

        }

        if (collision.gameObject.tag == "Key")
        {
            Drop_Weapon();
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            collision.transform.parent = Holder.transform;
            collision.transform.localPosition = new Vector3(0, 0, 0);
            collision.transform.localRotation = Holder.transform.localRotation;

            //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Holding_Weapon = false;
            Holding_Key = true;
            Holding_Health_Pack = false;
            Holding_Treasure = false;
            Holding_Trophy = false;


        }

        if (collision.gameObject.tag == "Health")
        {

            if(My_Player_Health.Player_Alive == true)
            {
                Drop_Weapon();
                collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                collision.transform.parent = Holder.transform;
                collision.transform.localPosition = new Vector3(0, 0, 0);
                collision.transform.localRotation = Holder.transform.localRotation;

                //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Holding_Weapon = false;
                Holding_Key = false;
                Holding_Health_Pack = true;
                Holding_Treasure = false;
                Holding_Trophy = false;

            }
            else
            {
                My_Player_Health.Player_Current_Health = My_Player_Health.Player_Start_Health * .75f;
                Destroy(collision.gameObject);
                GetComponent<SpriteRenderer>().color = new Color(Original_Color.r, Original_Color.g, Original_Color.b);

            }


           



        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Weapon")
    //    {
    //        Drop_Weapon();
    //        collision.GetComponent<Rigidbody2D>().isKinematic = true;
    //        collision.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
    //        collision.transform.parent = Holder.transform;
    //        collision.transform.localPosition = new Vector3(0, 0, 0);
    //        collision.transform.localRotation = Holder.transform.localRotation;

    //        //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //        Holding_Weapon = true;
    //        Holding_Key = false;

    //    }
    //}

   public void Drop_Weapon()
    {
        Holding_Weapon = false;
        Holding_Key = false;
        Weapon_Held = null;
       foreach(Transform child in Holder.transform)
        {
            child.parent = null;
            child.GetComponent<Rigidbody2D>().isKinematic = false;


        }

    }


   public void Thow_Weapon()
    {

        Weapon_Held = null;
        foreach (Transform child in Holder.transform)
        {
            var Throwing_Object = new GameObject();
            Throwing_Object = child.gameObject;
            child.parent = null;
            child.GetComponent<Rigidbody2D>().isKinematic = false;
            Throwing_Object.GetComponent<Rigidbody2D>().AddForce(transform.right * Throw_Force);

            if(Throwing_Object.GetComponent<Spin>() != null)
            {
                Throwing_Object.GetComponent<Spin>().Spinning = true;

            }



        }



    }

  

}
