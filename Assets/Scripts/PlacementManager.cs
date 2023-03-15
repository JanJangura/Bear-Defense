using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlacementManager : MonoBehaviour
{
    public Shop ShopManager;
    public GameObject bigXPrefab;

    private GameObject dummyPlacement; // The image of the prefab before placing it down
    private GameObject currentTowerPlacement;
    private GameObject hoverBackground; // Used for the raycast

    public Camera cam;

    public LayerMask mask;
    public LayerMask towerMask;

    public bool isBuilding;

    RaycastHit2D hit;

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = GetMousePosition();

        hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, mask, -100, 100);

        if (isBuilding == true)
        {
            if (dummyPlacement != null)
            {
                GetCurrentHoverBackground();

                if (hoverBackground != null)
                {
                    dummyPlacement.transform.position = GetMousePosition();

                    if (Input.GetButtonDown("Fire1"))
                    {
                        PlaceBuilding();
                    }
                    else if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        EndBuilding();
                    }
                }
            }
        }
    }

    public Vector2 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void GetCurrentHoverBackground()
    {     
        if (hit.collider != null)
        {
            hoverBackground = hit.collider.gameObject;
        }
    }

    public void StartBuilding(GameObject towerToBuild)
    {
        isBuilding = true;

        currentTowerPlacement = towerToBuild;

        dummyPlacement = Instantiate(currentTowerPlacement, GetMousePosition(), Quaternion.identity);

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
            if (ShopManager.CanBuyTower(currentTowerPlacement) == true && hit.collider.tag != "NoBuild" && hit.collider.tag != "Flowers")
            {
                GameObject newTowerObject = Instantiate(currentTowerPlacement);
                InstatiatingObjects(newTowerObject);
                ShopManager.BuyTower(currentTowerPlacement);
            }
            else
            {
                Instantiate(bigXPrefab, GetMousePosition(), Quaternion.identity);
                EndBuilding();
            }
        }
    }

    public void InstatiatingObjects(GameObject newTowerObject)
    {
        newTowerObject.layer = 10;
        newTowerObject.transform.position = GetMousePosition();

        EndBuilding();
    }

    public void EndBuilding()
    {
        isBuilding = false;

        if (dummyPlacement != null)
        {
            Destroy(dummyPlacement);           
        }
    }    
}
