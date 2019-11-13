using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure_Points : MonoBehaviour
{
    public float Score;

    public float Current_Score;

    public Text Score_Text;


    // Start is called before the first frame update
    void Start()
    {
        Current_Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
    Score_Text.text = "Score: " + Current_Score.ToString("0");
    
   Current_Score = Mathf.MoveTowards(Current_Score, Mathf.RoundToInt(Score), Time.deltaTime *50);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Treasure")
        {
            if(collision.transform.parent != null)
            {
                Destroy(collision.gameObject);
                Score += 10;
               
            }
        }
    }
}
