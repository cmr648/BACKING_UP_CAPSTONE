using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Goal : MonoBehaviour
{
    public GameObject[] Players;

    public Text Win_Text;
    

    public Countdown My_Countdown;

    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        Win_Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            My_Countdown.timer_going = false;
          
            Win_Text.enabled = true;

            for(int i = 0; i < Players.Length; i++) {
                Players[i].transform.position = transform.position;
            }
            Destroy(gameObject);
        }
    }
}
