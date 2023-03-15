using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBumbleBee : AIFollowPath
{
    [Header("Game Object")]
    public GameObject yellowBee;   

    AIFollowPath AIFP;

    protected override void Die()
    {
        Instantiate(PEPrefab, transform.position, Quaternion.identity);
        Instantiate(yellowBee, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        AdditionalIncome(1);
    }
}
