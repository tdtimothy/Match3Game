using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    [Header("UI Elements")]
    public TileBase[] tilesTypes;
    public Tilemap board;
    public int boardRows;
    public int boardCols;

    System.Random random;
    // Start is called before the first frame update
    void Start()
    {
        string seed = getRandomSeed();
        random = new System.Random(seed.GetHashCode());
        generateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateBoard()
    {
        BoundsInt bounds = board.cellBounds;
        board.ClearAllTiles();        
        for (boardRows = 0; boardRows < bounds.size.x; boardRows++)
        {
            for (boardCols = 0; boardCols < bounds.size.y; boardCols++)
            {
                int type = random.Next(0, tilesTypes.Length);
                board.SetTile(new Vector3Int(boardRows, boardCols, 0), tilesTypes[type]);            }
        }
    }

    string getRandomSeed()
    {
        string seed = "";
        string acceptableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdeghijklmnopqrstuvwxyz1234567890!@#$%^&*()";
        for (int i = 0; i < 20; i++)
            seed += acceptableChars[Random.Range(0, acceptableChars.Length)];
        return seed;
    }
}
