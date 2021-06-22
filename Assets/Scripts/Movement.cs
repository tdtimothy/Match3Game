using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public Tilemap board;

    Vector2 startPos;
    TileBase holdTile;
    static int MINIMUM_SWAP_DISTANCE = 32; //32 is placeholder, think about distance wanted later
    string swapPlaceHold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            Vector3Int mousePos = board.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            holdTile = board.GetTile(mousePos);
            Debug.Log(holdTile + " " + mousePos);
        }
        if(Input.GetMouseButton(0))
        {
            Vector2 swapDir = ((Vector2)Input.mousePosition - startPos);
            Vector2 normDir = swapDir.normalized;
            Vector2 absValDir = new Vector2(Mathf.Abs(swapDir.x), Mathf.Abs(swapDir.y));
            if(swapDir.magnitude > MINIMUM_SWAP_DISTANCE)
            {
                if (absValDir.x > absValDir.y)
                {
                    if (normDir.x > 0)
                        swapPlaceHold = "right";
                    else
                        swapPlaceHold = "left";
                }
                else
                {
                    if (normDir.y > 0)
                        swapPlaceHold = "up";
                    else
                        swapPlaceHold = "down";
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            swapTiles();
            swapPlaceHold = "no direction picked";
        }
    }

    void swapTiles()
    {
        Debug.Log("Swapping tile " + swapPlaceHold);
    }
}
