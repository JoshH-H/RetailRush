using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Timer timer;
    public float Countdown;
    public float time;
    public Text ClockonScreen;
    void Start()
    {
        time = timer.StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown = timer.CurrentTime;
        print(Countdown);
        if(Countdown >= (float)8/(float)9 * time)
        {
            ClockonScreen.text = "09:00";
        }
        if (Countdown >= (float)7 / (float)9 * time && Countdown < (float)8 / (float)9 * time)
        {
            ClockonScreen.text = "10:00";
        }
        if (Countdown >= (float)6 / (float)9 * time && Countdown < (float)7 / (float)9 * time)
        {
            ClockonScreen.text = "11:00";
        }
        if (Countdown >= (float)5 / (float)9 * time && Countdown < (float)6 / (float)9 * time)
        {
            ClockonScreen.text = "12:00";
        }
        if (Countdown >= (float)4 / (float)9 * time && Countdown < (float)5 / (float)9 * time)
        {
            ClockonScreen.text = "13:00";
        }
        if (Countdown >= (float)3 / (float)9 * time && Countdown < (float)4 / (float)9 * time)
        {
            ClockonScreen.text = "14:00";
        }
        if (Countdown >= (float)2 / (float)9 * time && Countdown < (float)3 / (float)9 * time)
        {
            ClockonScreen.text = "15:00";
        }
        if (Countdown >= (float)1 / (float)9 * time && Countdown < (float)2 / (float)9 * time)
        {
            ClockonScreen.text = "16:00";
        }
        if (Countdown < (float)1 / (float)9 * time)
        {
            ClockonScreen.text = "17:00";
        }


    }
}
