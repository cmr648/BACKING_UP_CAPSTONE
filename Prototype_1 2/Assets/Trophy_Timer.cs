using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trophy_Timer : MonoBehaviour
{
    public float Start_Time_Amount;

    public float Current_Time_Amount;

    public Text Trophy_Text;

    Rigidbody2D Trophy_Rigidbody;

    public bool Holding_Trophy;


    // Start is called before the first frame update
    void Start()
    {
        Trophy_Rigidbody = GetComponent<Rigidbody2D>();
        Current_Time_Amount = Start_Time_Amount;

    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(Trophy_Rigidbody.velocity);

        Trophy_Text.text = Current_Time_Amount.ToString("00");

        if (Trophy_Rigidbody.isKinematic == true && Current_Time_Amount > 0)
        {
            Current_Time_Amount -= Time.deltaTime;
            Holding_Trophy = true;

        }
        else if (Trophy_Rigidbody.isKinematic == false && Trophy_Rigidbody.velocity != new Vector2(0, 0))
        {
            Current_Time_Amount = Current_Time_Amount;

            Holding_Trophy = false;

        }
        else if (Trophy_Rigidbody.isKinematic == false && Trophy_Rigidbody.velocity == new Vector2(0, 0))
        {

            Current_Time_Amount = Start_Time_Amount;

            Holding_Trophy = false;

        }
    }
}
