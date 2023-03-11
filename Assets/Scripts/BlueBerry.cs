using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBerry : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public void Seek(Transform _target) // This will take in a transform
    {
        target = _target;   // Then we set the target = to _target
    }

    private void Update()
    {
        if (target == null) 
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // The length of our direction Vector, this is basically the current distance to our target. The
        // distance from our bullet to a target is equal to the direction magnitude. If this is less than the
        // distance that we are going to move this frame, this means that we already hit this target, meaning we're
        // going to over shoot and we do not want that.
        if (direction.magnitude <= distanceThisFrame)    
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);  // Moves at a constant speed
    }

    void HitTarget()
    {
        Destroy(this.gameObject);
    }
}
