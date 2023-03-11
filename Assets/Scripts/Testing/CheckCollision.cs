using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo != null)
        {
            if (hitInfo.tag == "TurnLeft")
            {
                transform.Rotate(0f, 180f, 0f);
                Debug.Log("HIT!");
            }
        }
    }
}
