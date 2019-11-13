using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public bool Spinning;

    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Spinning == true)
        {
            transform.Rotate(Vector3.forward * Speed * Time.deltaTime);

        }
        else
        {
            transform.rotation = transform.rotation;
        }
    }
}
