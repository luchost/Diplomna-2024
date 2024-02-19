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
                HelpPopUps.Instance.HelpSetText(13, "Red Altar", "Creates a healing area effect.");
                break;
            case GameColor.Yellow:
                gameObject.AddComponent<YellowAltar>();
                HelpPopUps.Instance.HelpSetText(14, "Yellow Altar", "Stuns all enemies around it once as it gets colored.");
                break;
            case GameColor.Blue:
                gameObject.AddComponent<BlueAltar>();
                HelpPopUps.Instance.HelpSetText(15, "Blue Altar", "Enemies in its area will attract leaves and apples created by trees.");
                break;
            case GameColor.Green:
                gameObject.AddComponent<GreenAltar>();
                HelpPopUps.Instance.HelpSetText(16, "Green Altar", "Significantly slows the enemies in its area and damages them over time.");
                break;
            case GameColor.Orange:
                gameObject.AddComponent<OrangeAltar>();
                HelpPopUps.Instance.HelpSetText(17, "Orange Altar", "Burns the enemies in its area with high damage over time.");
                break;
            case GameColor.Pink:
                gameObject.AddComponent<PurpleAltar>();
                HelpPopUps.Instance.HelpSetText(18, "Pink Altar", "Boosts the range and damage of all mushrooms in its area.");
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
