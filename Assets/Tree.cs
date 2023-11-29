using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ColorizableObject
{
    public override void AddEffectsForColor(GameColor color)
    {
        switch (color)
        {
            case GameColor.Red:
                gameObject.AddComponent<TestEffect>();
                break;
        }
    }

    public override void RemoveEffectsForColor(GameColor color)
    {
        switch (color)
        {
            case GameColor.Red:
                Destroy(gameObject.GetComponent<TestEffect>());
                break;
        }
    }
}
