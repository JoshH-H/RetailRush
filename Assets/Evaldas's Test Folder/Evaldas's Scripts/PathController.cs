using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
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
    public Transform DirectionToLook;

    private Quaternion rotationToTarget;
    bool WasZero;

    public float MovementSpeed = 1.0f;
    public float RotationSpeed = 5.0f;

    public Animator BetaTest;

    public bool DoneTalking;
    private bool CanBeDestroyed = false;
    void Start()
    {
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

        lastWaypointIndex = Waypoints.Length - 1;
        targetWaypoint = Waypoints[targetWaypointIndex];

        Quaternion rotationToTarget = Quaternion.LookRotation(targetWaypoint.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        float movementStep = MovementSpeed * Time.deltaTime;
        float rotationStep = RotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Vector3 Zero = new Vector3(0, 0, 0);

        Quaternion ZeroToTarget = Quaternion.LookRotation(Zero);
        Quaternion directionToLook = Quaternion.LookRotation(DirectionToLook.position);

        if (rotationToTarget == ZeroToTarget)
        {

            rotationToTarget = directionToLook;
            WasZero = true;
            return;
        }
        else
        {
            rotationToTarget = Quaternion.LookRotation(directionToTarget);
            BetaTest.SetBool("IsWalking", true);
        }

        if (rotationToTarget == ZeroToTarget && WasZero == true)
        {
            BetaTest.SetBool("IsWalking", false);
            rotationToTarget = directionToLook;
        }


        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);



        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

        if (DoneTalking == true || Input.GetKeyDown("q"))
        {
            System.Array.Reverse(Waypoints);
            targetWaypointIndex = 0;
            CanBeDestroyed = true;
            DoneTalking = false;
        }

        if (CanBeDestroyed == true && targetWaypointIndex == lastWaypointIndex)
        {
            Destroy(gameObject);
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
            targetWaypointIndex = lastWaypointIndex;
        }
        targetWaypoint = Waypoints[targetWaypointIndex];
    }
}