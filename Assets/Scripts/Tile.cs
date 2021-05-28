using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int typeID;
    public Vector2 pos;
    public RectTransform rect;
    Image img;

    public void Initialize(int type, Vector2 pos, Sprite sprite)
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        typeID = type;
        this.pos = pos;
        img.sprite = sprite;
    }

    public void setPosition(float x, float y)
    {
        pos.x = x;
        pos.y = y;
    }

    public void setPosition(Vector2 vector)
    {
        pos = vector;
    }

    public void movePosition(Vector2 move)
    {
        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, move, Time.deltaTime * 16f); //time to be changed, WIP
    }

    public void updateTile()
    {
        if(Vector3.Distance(rect.anchoredPosition, pos) > 1)
        {
            movePosition(pos);
        }
        else
        {
            rect.anchoredPosition = pos;
        }
    }
}
