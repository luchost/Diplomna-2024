using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// global lists
// - list of all game objects
// - list of all area effects

// class InteractableObject
// (an object that can participate in interactions, e.g. be colored, and can have Effects attached to it)
// - methods AddEffect(string effectClass, GameObject owner), RemoveEffect(string effectClass, GameObject owner)
// - keeps a list of effects, which are auto-removed when the object "dies"

// class ColorizableObject (inherits InteractableObject)
// - "knows" the list of effects that need to be applied for each color (which includes combination of colors)
// - method AddColor, which calculates the final color (current combined with a new one), calls SetColor
// - method SetColor, which removes the effect list of the old color (if any), and adds the effects for the new color

// class Effect
// - is attached to a game object
// - provides virtual methods to override, which are called on specific events, e.g.
//    a) OnUpdate - called periodically, e.g. at each frame or at each 100ms interval
//    b) int OnBeforeTakeDamage(int amount) - called to modify damage amount before this game object takes damage

// class AreaEffect, inherits Effect
// - automatically adds and maintains a list of effects in all game objects in a specific area (point, radius)
// - keeps an internal list of object "last known to be" in the area, tracks when new objects need to enter or leave this list
