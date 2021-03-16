using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public AudioSource AllSounds;
    public Spawner mainNPC;
    public GameObject menu;
    public GameObject PauseMenu;
    bool Opened = false;

    [Header("Josh's Connections")]
    [SerializeField] public Button pauseButton;
    public static UIManager instance;

    void Start()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        instance = this;
    }
    void Update()
    {
        AllSounds = mainNPC.Main.GetComponent<AudioSource>();
        if (Opened == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(true);
                AllSounds.mute = true;
                Time.timeScale = 0f;
                Opened = true;
            }
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(false);
                AllSounds.mute = false;
                Time.timeScale = 1f;
                Opened = false;
            }
            
        } 
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        AllSounds.mute = true;
        Time.timeScale = 0f;
        Opened = true;
        
    }
    public void Continue()
    {
        PauseMenu.SetActive(false);
        AllSounds.mute = false;
        Time.timeScale = 1f;
        Opened = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Timer.shiftsCompleted = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadSceneAssociate()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Timer.shiftsCompleted = 0;
    }
    public void LoadSceneManager()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        Timer.shiftsCompleted = 0;
    }


}
