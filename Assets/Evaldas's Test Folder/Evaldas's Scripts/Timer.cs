using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float CurrentTime = 0f;
    public float StartTime = 900f;

    public GameObject ShiftsResults;

    //public Text TimerO;

    int Min;
    int Sec;

    void Start()
    {
        ShiftsResults.SetActive(false);
        CurrentTime = StartTime;
    }
    void Update()
    {
        
        CurrentTime -= 1 * Time.deltaTime;
        //Min = Mathf.FloorToInt(CurrentTime / 60);
        //Sec = Mathf.FloorToInt(CurrentTime % 60);
        //TimerO.text = Min.ToString("00") + ":" + Sec.ToString("00"); 
        // If we decide to show the timer on the cash register
        if (CurrentTime <= 0 || Input.GetKeyDown("space"))
        {
            CurrentTime = 0;
            ShiftsResults.SetActive(true);
        }
    }
}
