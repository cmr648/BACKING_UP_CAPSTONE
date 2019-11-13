using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Floor : MonoBehaviour
{
    public Sprite[] Floor_Sprites;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Floor_Sprites[Random.Range(0, Floor_Sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
