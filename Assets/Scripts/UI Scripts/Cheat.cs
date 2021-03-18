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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 50;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 100;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 150;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 200;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 250;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TimerO.CurrentTime = 0;
            ScM.playerScore = 300;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
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