using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minutes : MonoBehaviour
{
    public Toggle Toggle1;
    public Toggle Toggle2;

    public float StartTime1 = 480;
    public float StartTime2 = 900;

    public static bool Is8Min;

    void Start()
    {
        if(Is8Min == true)
        {
            Timer.StartTime = StartTime1;
            Toggle1.isOn = true;
        }
        if (Is8Min == false)
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
            Is8Min = true;
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
            Is8Min = false;
            Toggle1.isOn = false;
            Timer.StartTime = StartTime2;
        }
        else
        {
            Toggle1.isOn = true;
        }
    }


}
