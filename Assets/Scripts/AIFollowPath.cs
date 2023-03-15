using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class AIFollowPath : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] private Bee enemyBee;   

    [Header("Privates")]
    private Transform target;
    public int wavepointIndex = 0;
    string _name;
    public int moveSpeed;
    WaveSpawner waveSpawner;
    int x = 1;
    int y = 2;

    BeeHive BH;

    private void Start()
    {
        // We are calling this points array from the "WayPoints" script and accessing here. Our target position is set equal to the position of points,
        // which is the first child of the WayPoints GameObject.
        target = WayPoints.points[0];
        waveSpawner = GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>();
        BH = GameObject.Find("BeeHive").GetComponent<BeeHive>();
        Assignment();
    }

    public void Assignment()
    {
        moveSpeed = enemyBee.Speed;
        _name = enemyBee.Name;
    }

    private void FixedUpdate()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            DamageDealt(x);
            Destroy(this.gameObject);
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }

    public virtual void DamageDealt(int x)
    {
        if (this.gameObject.layer == 12)
        {
            BH.TakeDamage(y);
        }
        else
            BH.TakeDamage(x);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Physics2D.IgnoreLayerCollision(3, 3);
        Physics2D.IgnoreLayerCollision(3, 12);
        Physics2D.IgnoreLayerCollision(12, 12);
        if (hitInfo != null)
        {
            if (hitInfo.tag == "TurnLeft")          
            {
                transform.localScale = new Vector3(-1, 1, 1);     // This is to rotate the sprite on the 180             
            }
            else if (hitInfo.tag == "TurnRight")
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            if (hitInfo.tag == "BlueBerry")
            {
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
        AdditionalIncome(x);       
    }

    public void Kills(int x)
    {
        waveSpawner.TotalKills(x);       
    }

    public void AdditionalIncome(int x)
    {
        waveSpawner.AdditionalIncome(x);
        Kills(x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(3, 3);
    }



    /////////////////////// IGNORE THE REST, BUT CAN GO AHEAD AND LOOK AT THE LAST CODE FOR BRACKEYS
    /*
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

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo != null)
        {
            if(hitInfo.tag == "ThisLeft")
            {
                transform.Rotate(0f, 180f, 0f);
                Debug.Log("HIT LEFT");
            }
            else if (hitInfo.tag == "ThisRight")
            {
                transform.Rotate(0f, 0f, 0f);
                Debug.Log("HIT RighT");
            }
        }
    }
    */

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


            public virtual void Move()
        {
            if (wavepointIndex <= WayPoints.points.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, WayPoints.points[wavepointIndex].transform.position, moveSpeed * Time.deltaTime);

                if (transform.position == WayPoints.points[wavepointIndex].transform.position)
                {
                    wavepointIndex += 1;            
                }


                if (wavepointIndex == WayPoints.points.Length)
                {
                    Destroy(this.gameObject);
                }

            }
        }





        }*/

        /* BRACKEYS CODE
            private void FixedUpdate()
        {
            /*
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

            if (Vector2.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWayPoint();
            }
        }*/
        /*
        private void GetNextWayPoint()
        {
            if (wavepointIndex >= WayPoints.points.Length - 1)
            {
                Destroy(this.gameObject);
            }
            wavepointIndex++;
            target = WayPoints.points[wavepointIndex];
        }*/
    }
