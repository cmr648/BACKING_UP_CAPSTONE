using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Countdown : MonoBehaviour
{
    public bool timer_going = true;

    public float Amount_Of_Time;

    public int Current_CountDown;

    public Text Timer_Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer_going == true)
        {
            Amount_Of_Time -= Time.deltaTime;
            Current_CountDown = Mathf.RoundToInt(Amount_Of_Time);

            Timer_Text.text = Current_CountDown.ToString();

            if (Amount_Of_Time < 0)
            {
                SceneManager.LoadScene(0);
            }
        }



    }
}
