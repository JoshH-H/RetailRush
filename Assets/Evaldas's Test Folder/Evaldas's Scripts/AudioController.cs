using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Toggle Mute;
    private void Awake()
    {
        if(AudioListener.volume == 1)
        {
            Mute.isOn = true ;
        }
        if (AudioListener.volume == 0)
        {
            Mute.isOn = false;
        }
    }
    void Start()
    {
        
    }

    public void MuteChange(bool audioIn)
    {
        if(audioIn)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
}
