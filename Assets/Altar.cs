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
            case GameColor.Blue:
                gameObject.AddComponent<BlueAltar>();
                break;
            case GameColor.Green:
                 gameObject.AddComponent<GreenAltar>();
                break;
            case GameColor.Orange:
                gameObject.AddComponent<OrangeAltar>();
                break;
            case GameColor.Pink:
                gameObject.AddComponent<PurpleAltar>();
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
            case GameColor.Blue:
                Destroy(gameObject.GetComponent<BlueAltar>());
                break;
            case GameColor.Green:
                Destroy(gameObject.GetComponent<GreenAltar>());
                break;
            case GameColor.Orange:
                Destroy(gameObject.GetComponent<OrangeAltar>());
                break;
            case GameColor.Pink:
                Destroy(gameObject.GetComponent<PurpleAltar>());
                break;
        }
    }
}
