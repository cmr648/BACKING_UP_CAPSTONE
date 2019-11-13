using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Conditions : MonoBehaviour
{
    public bool Boss_Defeated;
    public bool Score_Cap_Reached;
    public bool Tresure_Held;

    public GameObject Boss;

    public Treasure_Points MY_Treasurepoints;
    public int Max_Score;

    public Trophy_Timer My_Trophy_Timer;

    public Text Win_Text;

    // Start is called before the first frame update
    void Start()
    {
        Win_Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.gameObject == null)
        {
            Boss_Defeated = true;
        }

        if(MY_Treasurepoints.Current_Score >= Max_Score)
        {
            Score_Cap_Reached = true;
        }

        if(My_Trophy_Timer.Current_Time_Amount <= 0)
        {
            Tresure_Held = true;
        }

        if(Boss_Defeated == true || Score_Cap_Reached == true || Tresure_Held == true)
        {
            Win_Text.enabled = true;
            Time.timeScale = 0;
        }

    }
}
