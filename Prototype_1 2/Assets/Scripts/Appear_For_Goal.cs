using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear_For_Goal : MonoBehaviour
{
    public Treasure_Points My_Treasurpoints;

    public float Goal;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(My_Treasurpoints.Score > Goal)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
