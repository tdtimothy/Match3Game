using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public Tilemap board;
    public Board grid;
    Vector2 startPos;
    static int MINIMUM_SWAP_DISTANCE = 32; //32 is placeholder, think about distance wanted later
    Vector3Int gridPos;
    Vector3Int swapTarget;
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
            gridPos = board.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if ((gridPos.x >= 0 && gridPos.x < grid.boardRows) && (gridPos.y >= 0 && gridPos.y < grid.boardCols))
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 swapDir = ((Vector2)Input.mousePosition - startPos);
                Vector2 normDir = swapDir.normalized;
                Vector2 absValDir = new Vector2(Mathf.Abs(swapDir.x), Mathf.Abs(swapDir.y));
                if (swapDir.magnitude > MINIMUM_SWAP_DISTANCE)
                {
                    if (absValDir.x > absValDir.y)
                    {
                        if (normDir.x > 0)
                            swapTarget = Vector3Int.right;
                        else
                            swapTarget = Vector3Int.left;
                    }
                    else
                    {
                        if (normDir.y > 0)
                            swapTarget = Vector3Int.up;
                        else
                            swapTarget = Vector3Int.down;
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swapTiles(swapTarget);
                swapTarget = Vector3Int.zero;
            }
        }
    }

    void swapTiles(Vector3Int direction)
    {
        TileBase holdTile = board.GetTile(gridPos);
        Vector3Int swapPos = gridPos + direction;
        if ((swapPos.x >= 0 && swapPos.x < grid.boardRows) && (swapPos.y >= 0 && swapPos.y < grid.boardCols))
        {
            board.SetTile(gridPos, board.GetTile(swapPos));
            board.SetTile(swapPos, holdTile);
        }
    }
}
