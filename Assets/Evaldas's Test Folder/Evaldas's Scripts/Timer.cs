using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static int shiftsCompleted = 0;

    public float CurrentTime = 0f;
    public static float StartTime = 480f;

    public GameObject ShiftsResults;

    [SerializeField] public AudioSource AllSounds;
    public Spawner mainNPC;

    //public Text TimerO;

    int Min;
    int Sec;

    void Start()
    {
        ShiftsResults.SetActive(false);
        CurrentTime = StartTime;
        Time.timeScale = 1f;
    }
    void Update()
    {
        AllSounds = mainNPC.Main.GetComponent<AudioSource>();
        CurrentTime -= 1 * Time.deltaTime;

     /* Min = Mathf.FloorToInt(CurrentTime / 60);
        Sec = Mathf.FloorToInt(CurrentTime % 60);
        TimerO.text = Min.ToString("00") + ":" + Sec.ToString("00"); */ 
        // If we decide to show the timer on the cash register

        if(Input.GetKeyDown("space"))
        {
            CurrentTime = 0;
        }
        if (CurrentTime <= 0 )
        {
            AllSounds.mute = true;
            ShiftsResults.SetActive(true);
            Time.timeScale = 0f;
        }

        if (shiftsCompleted == 4)
        {
            SceneManager.LoadScene("Certified");
            shiftsCompleted = 0;
        }
    }
    public void RestartTheScene()
    {
        SceneManager.LoadScene(1); // loads current scene
        shiftsCompleted++;
    }
    public void LoadManager()
    {
        SceneManager.LoadScene(3); // loads current scene
        shiftsCompleted++;
    }
    public void Unfreeze()
    {
        Time.timeScale = 1f;
    }
}
