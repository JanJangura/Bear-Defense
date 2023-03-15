using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigX : MonoBehaviour
{
    public float timer = .05f;

    private void Awake()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(timer);
        Object.Destroy(this.gameObject);
    }
}
