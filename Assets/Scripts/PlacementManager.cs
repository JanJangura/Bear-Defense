using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlacementManager : MonoBehaviour
{
    public GameObject basicTowerObject;

    private GameObject dummyPlacement; // The image of the prefab before placing it down

    private GameObject hoverBackground; // Used for the raycast

    public Camera cam;

    public LayerMask mask;
    public LayerMask towerMask;

    public bool isBuilding;

    // Start is called before the first frame update
    void Start()
    {
        StartBuilding();
    }

    public Vector2 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void GetCurrentHoverBackground()
    {
        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, mask, -100, 100);

        if (hit.collider != null)
        {
            hoverBackground = hit.collider.gameObject;
        }
    }

    public void StartBuilding()
    {
        isBuilding = true;

        dummyPlacement = Instantiate(basicTowerObject);

        if (dummyPlacement.GetComponent<BearTowers>() != null)
        {
            Destroy(dummyPlacement.GetComponent<BearTowers>());     // Destroys the script cuz we only need the image.
        }
    }

    public bool CheckForTower()
    {
        bool towerInTheWay = false;

        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, towerMask, -100, 100);

        if (hit.collider != null)
        {
            towerInTheWay = true;
        }

        return towerInTheWay;
    }

    public void PlaceBuilding()
    {
        if (CheckForTower() == false)
        {
            GameObject newTowerObject = Instantiate(basicTowerObject);
            newTowerObject.layer = 10;
            newTowerObject.transform.position = GetMousePosition();

            EndBuilding();
        }
    }

    public void EndBuilding()
    {
        isBuilding = false;

        if (dummyPlacement != null)
        {
            Destroy(dummyPlacement);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuilding == true)
        {
            if(dummyPlacement != null)
            {
                GetCurrentHoverBackground();

                if(hoverBackground != null)
                {
                    dummyPlacement.transform.position = GetMousePosition();

                    if (Input.GetButtonDown("Fire1"))
                    {
                        PlaceBuilding();
                    }
                }              
            } 
        }
    }
}
