using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeChanger : MonoBehaviour
{
    [SerializeField]
    private float timer;
    public Button lowestTimer;
    public Button middleTimer;
    public Button highestTimer;

    void Start()
    {
        timer = 15f;
        PlayerPrefs.SetFloat("_timing", timer = 15f);
    }

    public void Changer()
    {
        timer = 15f;
        PlayerPrefs.SetFloat("_timing", timer = 15f);
        Debug.Log("Set " + timer);
        lowestTimer.interactable = false;
        middleTimer.interactable = true;
        highestTimer.interactable = true;
    }
    public void Changer1()
    {
        timer = 20f;
        PlayerPrefs.SetFloat("_timing", timer = 20f);
        Debug.Log("Set1 " + timer);
        lowestTimer.interactable = true;
        middleTimer.interactable = false;
        highestTimer.interactable = true;
    }
    public void Changer2()
    {
        timer = 25f;
        PlayerPrefs.SetFloat("_timing", timer = 25f);
        Debug.Log("Set2 " + timer);
        lowestTimer.interactable = true;
        middleTimer.interactable = true;
        highestTimer.interactable = false;
    }

    public void Checker()
    {
        Debug.Log("Time set to" + timer);
    }
}
