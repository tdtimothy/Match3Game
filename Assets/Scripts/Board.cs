using System.Collections;
using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    [System.Serializable]
    public struct gridRow{
        public bool[] row;
    }
    public Grid grid;
    public gridRow[] rows = new gridRow[7];
}
