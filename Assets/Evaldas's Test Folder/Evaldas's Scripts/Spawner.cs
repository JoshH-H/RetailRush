using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool HasCameBack;
    public GameObject[] NPCs;
    public GameObject Main;
    [SerializeField] PathController MainController;

    void Start()
    {
        int a = 0;
        int b = NPCs.Length;
        int c;

        c = Random.Range(a, b);

        Main = Instantiate(NPCs[c], NPCs[c].transform);
        MainController = Main.GetComponent<PathController>();
        HasCameBack = MainController.CameBack;
    }
    void Update()
    {
        HasCameBack = MainController.CameBack;
        if (HasCameBack == true)
        {
            Destroy(Main);
            int a = 0;
            int b = NPCs.Length;
            int c;

            c = Random.Range(a, b);

            Main = Instantiate(NPCs[c], NPCs[c].transform);
            MainController = Main.GetComponent<PathController>();
            HasCameBack = false;
            HasCameBack = MainController.CameBack;
            
        }

    }

}