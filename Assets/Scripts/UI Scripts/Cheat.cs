using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    public Timer TimerO;
    public GameObject ShiftsResults;
    public Spawner mainNPC;

    public ScoreManager ScM;

    void Start()
    {
        ShiftsResults.SetActive(false);
        //CurrentTime = StartTime;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 50;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 100;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 150;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 200;
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 250;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 300;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 350;
        }

        if (Timer.shiftsCompleted == 4)
        {
            SceneManager.LoadScene("Certified");
            Timer.shiftsCompleted = 0;
        }
    }
}