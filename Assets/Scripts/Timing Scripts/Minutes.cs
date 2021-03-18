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

    int[] Scores8 = {350, 349, 270, 269, 240, 239, 145, 144};
    int[] Scores5 = {190, 180, 160, 159, 120, 100, 70, 50};

    int minimum5 = 110;
    int minimum8 = 200;

    int maximum5 = 200;
    int maximum8 = 400;

    void Start()
    {
        if(Is5Min == true)
        {
            ScoreManager.minimum = minimum5;
            ScoreManager.maximum = maximum5;
            ScoreManager.Scores = Scores5;
            Timer.StartTime = StartTime1;
            Toggle1.isOn = true;
        }
        if (Is5Min == false)
        {
            ScoreManager.minimum = minimum8;
            ScoreManager.maximum = maximum8;
            ScoreManager.Scores = Scores8;
            Timer.StartTime = StartTime2;
            Toggle2.isOn = true;
        }
        
    }

    void Update()
    {
        if (Is5Min == true)
        {
            ScoreManager.minimum = minimum5;
            ScoreManager.maximum = maximum5;
            ScoreManager.Scores = Scores5;
            Timer.StartTime = StartTime1;
            Toggle1.isOn = true;
        }
        if (Is5Min == false)
        {
            ScoreManager.minimum = minimum8;
            ScoreManager.maximum = maximum8;
            ScoreManager.Scores = Scores8;
            Timer.StartTime = StartTime2;
            Toggle2.isOn = true;
        }

        print(ScoreManager.minimum + " " + ScoreManager.maximum);
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
