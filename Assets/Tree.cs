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
                break;
            case GameColor.Yellow:
                gameObject.AddComponent<TestEffect>();
                break;
            case GameColor.Blue:
                gameObject.AddComponent<TestEffect>();
                break;
            case GameColor.Green:
                gameObject.AddComponent<TestEffect>();
                break;
            case GameColor.Orange:
                gameObject.AddComponent<TestEffect>();
                break;
            case GameColor.Pink:
                gameObject.AddComponent<TestEffect>();
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
                Destroy(gameObject.GetComponent<TestEffect>());
                break;
            case GameColor.Blue:
                Destroy(gameObject.GetComponent<TestEffect>());
                break;
            case GameColor.Green:
                Destroy(gameObject.GetComponent<TestEffect>());
                break;
            case GameColor.Orange:
                Destroy(gameObject.GetComponent<TestEffect>());
                break;
            case GameColor.Pink:
                Destroy(gameObject.GetComponent<TestEffect>());
                break;

        }
    }
}
