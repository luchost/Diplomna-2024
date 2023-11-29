using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameColor
{
    None = 0,
    Red = 1,
    Blue = 2,
    Yellow = 4,
    Pink = 3,   // Red + Blue
    Orange = 5, // Red + Yellow
    Green = 6,  // Blue + Yellow
    White = 7,  // forbidden
};

public class ColorizableObject : MonoBehaviour
{
    GameColor color;

    public void AddColor(GameColor added_color)
    {
        var newcolor = (GameColor)((int)color | (int)added_color);
        if (newcolor != GameColor.White)
            SetColor(newcolor);
    }

    public void SetColor(GameColor newcolor)
    {
        if (newcolor == color)
            return;
        if (color != GameColor.None)
            RemoveEffectsForColor(color);
        color = newcolor;
        if (newcolor != GameColor.None)
            AddEffectsForColor(newcolor);
    }

    public virtual void AddEffectsForColor(GameColor color) {}
    public virtual void RemoveEffectsForColor(GameColor color) {}
}
