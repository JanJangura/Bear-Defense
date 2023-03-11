using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            Debug.LogError("More than one BuildManager in Scene!");
            return;
        }
        instance = this;    // Can be reference from anywhere, it's to use only one Build Manager that can be called from anywhere
    }

    public GameObject standardBearPrefab;

    private void Start()
    {
        bearToBuild = standardBearPrefab;
    }
    private GameObject bearToBuild;

    public GameObject GetBearToBuild()
    {
        return bearToBuild;
    }
}
