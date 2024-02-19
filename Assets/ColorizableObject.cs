using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if(newcolor == color || newcolor == GameColor.White)
            SetColor(added_color);
        else if (newcolor != GameColor.White)
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

        ChangeMaterial(color);
    }
    public void ChangeMaterial(GameColor color)
    {
        var obj = transform.gameObject.GetComponent<MeshRenderer>().material;
        switch (color)
        {
            case GameColor.Red:
                obj.color=Color.red;
                break;
            case GameColor.Yellow:
                obj.color = Color.yellow;
                break;
            case GameColor.Blue:
                obj.color = Color.blue;
                break;
            case GameColor.Green:
                obj.color = Color.green;
                break;
            case GameColor.Orange:
                obj.color = Color.red+Color.yellow;
                break;
            case GameColor.Pink:
                obj.color = Color.magenta;
                break;
            case GameColor.None:
                obj.color = Color.gray;
                break;
        }

    }

    public virtual void AddEffectsForColor(GameColor color) {}
    public virtual void RemoveEffectsForColor(GameColor color) {}
}
