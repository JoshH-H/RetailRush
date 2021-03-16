using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool HasCameBack;
    public GameObject[] NPCs;
    public GameObject Main;
    [SerializeField] PathController MainController;
    public GameObject[] RandomBG;

    void Start()
    {
        int a = 0;
        int b = NPCs.Length;
        int c;
        int d = RandomBG.Length;
        int e;

        c = Random.Range(a, b);
        e = Random.Range(a, d);

        Main = Instantiate(NPCs[c], NPCs[c].transform);
        Instantiate(RandomBG[e], RandomBG[e].transform);
        MainController = Main.GetComponent<PathController>();
        HasCameBack = MainController.CameBack;
        RemoveAt(ref NPCs, c);
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
            RemoveAt(ref NPCs, c);
        }

    }
    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            arr[a] = arr[a + 1];
        }

        System.Array.Resize(ref arr, arr.Length - 1);
    }
}