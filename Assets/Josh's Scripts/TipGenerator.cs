using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipGenerator : MonoBehaviour
{
    [SerializeField] string[] tips;
    [SerializeField] Text tipText;

    void Start()
    {
        PickATip();
    }

    void PickATip()
    {
        string tipPicker = tips[Random.Range(0, tips.Length)];
        tipText.text = tipPicker.ToString();
    }
}
