using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minutes : MonoBehaviour
{
    public Toggle Toggle1;
    public Toggle Toggle2;

    public float StartTime1 = 300f;
    public float StartTime2 = 480f;

    public static bool Is5Min = true;

    void Start()
    {
        if(Is5Min == true)
        {
            Timer.StartTime = StartTime1;
            Toggle1.isOn = true;
        }
        if (Is5Min == false)
        {
            Timer.StartTime = StartTime2;
            Toggle2.isOn = true;
        }

    }

    void Update()
    {
        //print(Timer.StartTime);
    }

    public void FirstChoice(bool check1)
    {
        if(check1)
        {
            Is5Min = true;
            Toggle2.isOn = false;
            Timer.StartTime = StartTime1;
        }
        else
        {
            Toggle2.isOn = true;
        }
    }
    public void SecondChoice(bool check2)
    {
        if (check2)
        {
            Is5Min = false;
            Toggle1.isOn = false;
            Timer.StartTime = StartTime2;
        }
        else
        {
            Toggle1.isOn = true;
        }
    }


}
