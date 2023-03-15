using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBee", menuName = "ScriptableObjects/Bee")] // To make it possible to create this object throught the create asset menu
public class Bee : ScriptableObject
{
    // The name you want to input in for this game object
    [SerializeField] private string _name;

    // The cost you want this game object to be
    [SerializeField] private int _speed;

    // To access the data on our Scriptable Objects.
    public string Name => _name;
    public int Speed => _speed;
}
