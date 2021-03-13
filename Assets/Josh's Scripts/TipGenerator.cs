using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipGenerator : MonoBehaviour
{
    [SerializeField] string[] tips;
    [SerializeField] Text tipText;
    [SerializeField] GameObject mainPannel;
    [SerializeField] int timeToDisappear;

    void Start()
    {
        PickATip();
        Invoke("Disappear", timeToDisappear);
    }

    void PickATip()
    {
        string tipPicker = tips[Random.Range(0, tips.Length)];
        tipText.text = tipPicker.ToString();
    }

    void Disappear()
    {
        mainPannel.SetActive(false);
    }
}
