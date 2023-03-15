using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADYellowBee : RedBumbleBee
{
    protected override void Die()
    {
        Instantiate(PEPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        AdditionalIncome(1);
    }
}
