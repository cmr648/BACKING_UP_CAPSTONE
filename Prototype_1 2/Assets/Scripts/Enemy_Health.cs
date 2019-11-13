using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int Start_Health;

    public int Current_Health;

    public float Red_Time;

    public Color Red;

    public Color Original_Color;

    public GameObject Key;

    // Start is called before the first frame update
    void Start()
    {
        Current_Health = Start_Health;

        Original_Color = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {

        if(Current_Health == 0)
        {
            Instantiate(Key, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }

    }

    IEnumerator Lose_Health()
    {
        Current_Health -= 1;
        GetComponent<SpriteRenderer>().color = new Color(Red.r, Red.g, Red.b);
        yield return new WaitForSeconds(Red_Time);
        GetComponent<SpriteRenderer>().color = new Color(Original_Color.r, Original_Color.g, Original_Color.b);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            StartCoroutine("Lose_Health");
        }
    }

}
