using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIFollowPath : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        // We are calling this points array from the "WayPoints" script and accessing here. Our target position is set equal to the position of points,
        // which is the first child of the WayPoints GameObject.
        target = WayPoints.points[0]; 
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (wavepointIndex <= WayPoints.points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, WayPoints.points[wavepointIndex].transform.position, moveSpeed * Time.deltaTime);

            if(transform.position == WayPoints.points[wavepointIndex].transform.position )
            {
                wavepointIndex += 1;
            }

            if(wavepointIndex == WayPoints.points.Length)
            {
                Destroy(this.gameObject);
            }
        }
    }

    /* This is one way to do it, but look beyond these codes because we are going to follow Brackeys Codes instead.
     * 
     * 
    // Array of waypoints to walk from one to the next one
    [SerializeField] private Transform[] waypoints;

    // Walk sped that can be set in Inspector
    [SerializeField] private float moveSpeed = 1f;

    // Index of current waypoint from which Enemy walks to the next one
    private int wayPointIndex = 0;

    // Use this for initialization
    private void Awake()
    {
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[wayPointIndex].position;
    }

    private void Update()
    {
        // Move Enemy
        Move();
    }

    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If Enemy reached last waypoint then it stops
        if(wayPointIndex <= waypoints.Length - 1)
        {
            // Move Enemy from current waypoint to the next one using MoveTowards method
                                                     // Current Position, Target Position, Movement Speed       
            transform.position = Vector2.MoveTowards(transform.position, waypoints[wayPointIndex].transform.position,moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards to, then wayPointIndex is increased by 1 and
            // Enemy starts to walk to the next waypoint.
            if(transform.position == waypoints[wayPointIndex].transform.position)
            {
                wayPointIndex += 1;
            }
        }
    }*/
}
