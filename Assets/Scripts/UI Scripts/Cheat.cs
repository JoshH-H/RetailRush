using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    public static int shiftsCompleted = 0;
    public Timer TimerO;
    public GameObject ShiftsResults;

    [SerializeField] public AudioSource AllSounds;
    public Spawner mainNPC;

    public ScoreManager ScM;

    void Start()
    {
        ShiftsResults.SetActive(false);
        //CurrentTime = StartTime;
        Time.timeScale = 1f;
    }
    void Update()
    {
        AllSounds = mainNPC.Main.GetComponent<AudioSource>();
        TimerO.CurrentTime -= 1 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 50;
        }
        if (TimerO.CurrentTime <= 0)
        {
            AllSounds.mute = true;
            ShiftsResults.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 100;
        }
        if (TimerO.CurrentTime <= 0)
        {
            AllSounds.mute = true;
            ShiftsResults.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 150;
        }
        if (TimerO.CurrentTime <= 0)
        {
            AllSounds.mute = true;
            ShiftsResults.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 200;
        }
        if (TimerO.CurrentTime <= 0)
        {
            AllSounds.mute = true;
            ShiftsResults.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 250;
        }
        if (TimerO.CurrentTime <= 0)
        {
            AllSounds.mute = true;
            ShiftsResults.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 300;
        }
        if (TimerO.CurrentTime <= 0)
        {
            AllSounds.mute = true;
            ShiftsResults.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 350;
        }
        if (TimerO.CurrentTime <= 0)
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