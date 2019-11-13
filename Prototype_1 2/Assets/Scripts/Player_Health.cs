using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float Player_Start_Health;
    public float Player_Current_Health;

    public float Red_Time;
    public Color Red;
    public Color Original_Color;

    public bool Player_Alive = true;

    Player_Controls My_Playercontrols;

    Rigidbody2D My_Player_Rigidbody;
    BoxCollider2D My_PlayerboxCollider;

    // Start is called before the first frame update
    void Start()
    {
        Player_Current_Health = Player_Start_Health;
        Original_Color = GetComponent<SpriteRenderer>().color;
        My_Playercontrols = GetComponent<Player_Controls>();
        My_Player_Rigidbody = GetComponent<Rigidbody2D>();
        My_PlayerboxCollider = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Player_Current_Health <= 0)
        {
            Player_Alive = false;
        }
        else
        {
            Player_Alive = true;
        }

        if(Player_Alive == true)
        {
            My_Playercontrols.enabled = true;
            My_PlayerboxCollider.enabled = true;

            My_Player_Rigidbody.isKinematic = false;

        }
        if(Player_Alive == false)
        {
            My_Playercontrols.enabled = false;
            My_Player_Rigidbody.isKinematic = false;
            GetComponent<SpriteRenderer>().color = new Color(Red.r, Red.g, Red.b);


        }


    }

    IEnumerator Lose_Health()
    {
        Player_Current_Health -= 1;
        GetComponent<SpriteRenderer>().color = new Color(Red.r, Red.g, Red.b);
        yield return new WaitForSeconds(Red_Time);
        GetComponent<SpriteRenderer>().color = new Color(Original_Color.r, Original_Color.g, Original_Color.b);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy_Bullet")
        {
            My_Player_Rigidbody.velocity = new Vector3(0, 0, 0);
            Destroy(collision.gameObject);
            StartCoroutine("Lose_Health");
        }
    }
}
