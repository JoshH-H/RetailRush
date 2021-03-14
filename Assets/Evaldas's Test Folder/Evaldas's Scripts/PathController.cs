using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public bool CameBack = false;


    private Transform Path;
    public Transform Path1;
    public Transform Path2;
    public Transform Path3;
    public Transform Path4;
    public Transform[] Waypoints;
    private Transform targetWaypoint;

    private int targetWaypointIndex = 0;

    private float minDis = 0.1f;
    private int lastWaypointIndex;

    public bool LastWayPoint;

    public float MovementSpeed = 1.0f;
    public float RotationSpeed = 5.0f;

    public Animator BetaTest;

    public bool DoneTalking;
    private bool CanBeDestroyed = false;

    [Header("Josh Dialogue")]
    [SerializeField] QuestionManager questionManager;
    [SerializeField] GameObject QM;
    [SerializeField] GameObject questionPannels;

    [Header("Audio")]
    [SerializeField] AudioSource Walking;
    void Start()
    {

        QM.SetActive(false);
        //questionPannels.SetActive(false);

        int a = Random.Range(1, 4);
        if (a == 1)
        {
            Path = Path1;
        }
        if (a == 2)
        {
            Path = Path2;
        }
        if (a == 3)
        {
            Path = Path3;
        }
        if (a == 4)
        {
            Path = Path4;
        }

        Waypoints = new Transform[Path.transform.childCount];

        for (int i = 0; i < Path.transform.childCount; i++)
        {
            Waypoints[i] = Path.transform.GetChild(i);
        }

        lastWaypointIndex = Waypoints.Length - 1; //here it gets messy
        targetWaypoint = Waypoints[targetWaypointIndex];

    }

    // Update is called once per frame
    void Update()
    {

        float movementStep = MovementSpeed * Time.deltaTime;
        float rotationStep = RotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        if (LastWayPoint == true)
        {
            BetaTest.SetBool("IsWalking", false);
            QM.SetActive(true);
            //questionPannels.SetActive(true);
        }
        else
        {
            BetaTest.SetBool("IsWalking", true);
        }

        if (DoneTalking == true || Input.GetKeyDown("q"))
        {
            BetaTest.SetBool("IsWalking", true);
            Walking.Play();
            System.Array.Reverse(Waypoints);
            targetWaypointIndex = 0;
            CanBeDestroyed = true;
            DoneTalking = false;
        }

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);


        if (BetaTest.GetComponent<Animator>().GetBool("IsWalking") == true && Walking.isPlaying == false)
        {
            Walking.Play();
            print(BetaTest.GetComponent<Animator>().GetBool("IsWalking"));
        }
        if (BetaTest.GetComponent<Animator>().GetBool("IsWalking") == false && Walking.isPlaying == true)
        {
            Walking.Stop();
            print(BetaTest.GetComponent<Animator>().GetBool("IsWalking"));
        }



        if (CanBeDestroyed == true && targetWaypointIndex == lastWaypointIndex)
        {
            CameBack = true;

        }


    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDis)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {

        if (targetWaypointIndex > lastWaypointIndex)
        {
            LastWayPoint = true;
        }
        else
        {
            LastWayPoint = false;
        }
        targetWaypoint = Waypoints[targetWaypointIndex];
    }
}