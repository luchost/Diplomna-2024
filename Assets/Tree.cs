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
                gameObject.AddComponent<RedTreeEffect>();
                HelpPopUps.Instance.HelpSetText(1, "Red Tree", "Creates apples that attract enemies.");
                break;
            case GameColor.Yellow:
                gameObject.AddComponent<YellowTree>();
                HelpPopUps.Instance.HelpSetText(2, "Yellow Tree", "Leaves falling from the tree hover towards enemies, making them more vulnerable.");
                break;
            case GameColor.Blue:
                gameObject.AddComponent<BlueTree>();
                HelpPopUps.Instance.HelpSetText(3, "Blue Tree", "Creates strong winds that will blow leaves and apples away.");
                break;
            case GameColor.Green:
                gameObject.AddComponent<GreenTree>();
                HelpPopUps.Instance.HelpSetText(4, "Green Tree", "Leaves falling from the tree hover towards enemies, poisoning and killing them within seconds.");
                break;
            case GameColor.Orange:
                gameObject.AddComponent<OrangeTree>();
                HelpPopUps.Instance.HelpSetText(5, "Orange Tree", "Leaves falling from the tree hover towards enemies and burn, dealing damage over time.");
                break;
            case GameColor.Pink:
                gameObject.AddComponent<PurpleTree>();
                HelpPopUps.Instance.HelpSetText(6, "Pink Tree", "Purple mushrooms, which can make enemies attack their own, start growing under the tree.");
                break;
        }
    }

    public override void RemoveEffectsForColor(GameColor color)
    {
        switch (color)
        {
            case GameColor.Red:
                Destroy(gameObject.GetComponent<RedTreeEffect>());
                break;
            case GameColor.Yellow:
                Destroy(gameObject.GetComponent<YellowTree>());
                break;
            case GameColor.Blue:
                Destroy(gameObject.GetComponent<BlueTree>());
                break;
            case GameColor.Green:
                Destroy(gameObject.GetComponent<GreenTree>());
                break;
            case GameColor.Orange:
                Destroy(gameObject.GetComponent<OrangeTree>());
                break;
            case GameColor.Pink:
                Destroy(gameObject.GetComponent<PurpleTree>());
                break;

        }
    }
}
