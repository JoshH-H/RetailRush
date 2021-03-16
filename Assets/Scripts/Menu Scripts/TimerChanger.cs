using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerChanger : MonoBehaviour
{
    private float timer;
    [SerializeField] private float easyTimer;
    [SerializeField] private float medTimer;
    [SerializeField] private float highTimer;
    public Button lowestTimer;
    public Button middleTimer;
    public Button highestTimer;

    void Start()
    {
        timer = medTimer;
        PlayerPrefs.SetFloat("_timing", timer = 15f);
    }

    public void Changer()
    {
        timer = easyTimer;
        PlayerPrefs.SetFloat("_timing", timer = easyTimer);
        Debug.Log("Set " + timer);
        lowestTimer.interactable = false;
        middleTimer.interactable = true;
        highestTimer.interactable = true;
    }
    public void Changer1()
    {
        timer = medTimer;
        PlayerPrefs.SetFloat("_timing", timer = medTimer);
        Debug.Log("Set1 " + timer);
        lowestTimer.interactable = true;
        middleTimer.interactable = false;
        highestTimer.interactable = true;
    }
    public void Changer2()
    {
        timer = highTimer;
        PlayerPrefs.SetFloat("_timing", timer = highTimer);
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
