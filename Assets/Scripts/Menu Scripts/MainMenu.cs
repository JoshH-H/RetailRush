using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Leena's script to match menu to sounds
    [SerializeField] private GameObject chooseRole;

    public void OpenMenu()
    {
        StartCoroutine(WaitBeforeOpen());
    }

    private IEnumerator WaitBeforeOpen()
    {
        yield return new WaitForSeconds(0.3f);
        chooseRole.SetActive(true);
    }
}
