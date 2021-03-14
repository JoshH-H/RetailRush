using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool HasCameBack;
    public List<GameObject> npcs = new List<GameObject>();
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
            RemoveAt(ref NPCs, 2); // removes Color.white.
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
    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            arr[a] = arr[a + 1];
        }

        System.Array.Resize(ref arr, arr.Length - 1);
    }
}