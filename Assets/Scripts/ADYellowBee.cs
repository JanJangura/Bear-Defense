using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ADYellowBee : RedBumbleBee
{
    public GameObject RedBear;
    private void Awake()
    {
        wavepointIndex = holder;
    }
    public override void Index()
    {
        target = WayPoints.points[WPI];
    }

    public override void FixedUpdate()
    {
        Move();
    }
    protected override void Die()
    {
        Instantiate(PEPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        AdditionalIncome(1);
    }

    private void Move()
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
}
