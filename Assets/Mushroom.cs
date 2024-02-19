using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : ColorizableObject
{

    public override void AddEffectsForColor(GameColor color)
    {
        switch (color)
        {
            case GameColor.Red:
                gameObject.AddComponent<RedMushroom>();
                HelpPopUps.Instance.HelpSetText(7, "Red Mushroom", "Absorbs all damage from hits if you are around.");
                break;
            case GameColor.Yellow:
                gameObject.tag = "Friendly";
                gameObject.AddComponent<YellowMushroom>();
                HelpPopUps.Instance.HelpSetText(8, "Yellow Mushroom", "Moves toward enemies and burns every enemy around it over time.");
                break;
            case GameColor.Blue:
                gameObject.tag = "Friendly";
                gameObject.AddComponent<BlueMushroom>();
                HelpPopUps.Instance.HelpSetText(9, "Blue Mushroom", "Fires explosive projectiles towards enemies from afar.");
                break;
            case GameColor.Green:
                gameObject.tag = "Friendly";
                gameObject.AddComponent<GreenMushroom>();
                HelpPopUps.Instance.HelpSetText(10, "Green Mushroom", "Moves toward enemies and then goes BOOM!");
                break;
            case GameColor.Orange:
                gameObject.tag = "Friendly";
                gameObject.AddComponent<OrangeMushroom>();
                HelpPopUps.Instance.HelpSetText(11, "Orange Mushroom", "Set enemies on fire one by one, enraging them to attack it back.");
                break;
            case GameColor.Pink:
                gameObject.tag = "Friendly";
                gameObject.AddComponent<PurpleMushroom>();
                HelpPopUps.Instance.HelpSetText(12, "Pink Mushroom", "Shoots encharming projectiles that make enemies attack their kin.");
                break;

        }
    }

    public override void RemoveEffectsForColor(GameColor color)
    {
        switch (color)
        {
            case GameColor.Red:
                Destroy(gameObject.GetComponent<RedMushroom>());
                break;
            case GameColor.Yellow:
                Destroy(gameObject.GetComponent<YellowMushroom>());
                break;
            case GameColor.Blue:
                Destroy(gameObject.GetComponent<BlueMushroom>());
                break;
            case GameColor.Green:
                Destroy(gameObject.GetComponent<GreenMushroom>());
                break;
            case GameColor.Orange:
                Destroy(gameObject.GetComponent<OrangeMushroom>());
                break;
            case GameColor.Pink:
                Destroy(gameObject.GetComponent<PurpleMushroom>());
                break;

        }
    }
}
