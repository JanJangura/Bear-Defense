using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBumbleBee : AIFollowPath
{
    [Header("Game Object")]
    public GameObject yellowBee;
    public int holder;
    protected override void Die()
    {
        holder = starter();

        Instantiate(PEPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

        GameObject newYellowBee = Instantiate(yellowBee, transform.position, Quaternion.identity);
        AIFollowPath newYellowBeeScript = newYellowBee.GetComponent<AIFollowPath>();
        
        if(newYellowBee != null && newYellowBeeScript != null)
        {
            newYellowBeeScript.target = this.target;
            newYellowBeeScript.wavepointIndex = this.wavepointIndex;
        }
      
        AdditionalIncome(1);
    }
}
