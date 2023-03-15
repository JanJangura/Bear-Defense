using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* getters & setters = add security to fields by encapsulation 
 * They're accessors found within properties
 * 
 * properties = combine aspect of both fields and methods (share name with a field)
 * get accessor = used to return the property value
 * set accessor = used to assign a new value
 * value keyword = defines the value being assigned by the set (parameter)
  
*/

// Speed is actually set up as an enum
public enum TowerSpeed
{
    Slow,           // By default the first member is 0
    Medium,         // Set as 1 and so forth
    Fast,           // Set as 2
    Hypersonic      // Set as 3
}

[CreateAssetMenu(fileName = "NewBear", menuName = "ScriptableObjects/Bear")] // To make it possible to create this object throught the create asset menu
public class Bear : ScriptableObject
{
    // The name you want to input in for this game object
    [SerializeField] private string _name;                  

    // The cost you want this game object to be
    [SerializeField] private int _cost;

    // The fire rate speed you want this G.O. to be
    [SerializeField] private TowerSpeed _speed;

    // The Description you would like to have for this G.O.
    [TextArea][SerializeField] private string _description;

    // The GameObject
    public GameObject bear;

    // To access the data on our Scriptable Objects.
    public string Name => _name;        
    public int Cost => _cost;

    // Here is our 
    public string Speed
    {
        get
        {
            switch (_speed)
            {
                case TowerSpeed.Slow:
                    return "Slow";

                case TowerSpeed.Medium:
                    return "Medium";

                case TowerSpeed.Fast:
                    return "Fast";

                case TowerSpeed.Hypersonic:
                    return "Hypersonic";

                default:
                    return "Undefined";
            }
        }
    }

    // To access Description data
    public string Description => _description;
}
