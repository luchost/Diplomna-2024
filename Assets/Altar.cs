using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : ColorizableObject
{
    public override void AddEffectsForColor(GameColor color)
    {
        switch (color)
        {
            case GameColor.Red:
                gameObject.AddComponent<RedAltar>();
                break;
            case GameColor.Yellow:
                gameObject.AddComponent<YellowAltar>();
                break;
        }

    }

    public override void RemoveEffectsForColor(GameColor color)
    {
        switch (color)
        {
            case GameColor.Red:
                Destroy(gameObject.GetComponent<RedAltar>());
                break;
            case GameColor.Yellow:
               Destroy( gameObject.GetComponent<YellowAltar>());
                break;
        }
    }
}
