using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public Tilemap board;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int mousePos = board.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            TileBase clickedTile = board.GetTile(mousePos);
            Debug.Log(clickedTile + " " + mousePos);
        }
    }
}
