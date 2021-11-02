using UnityEngine;

public class WorldGrid
{
    public int dimensions;
    public Vector3 size;
    public int[,] cellState; //-1 = invalid, 0 = empty, 1 = occupied 
    public Vector3[,] cellCenters;
    public float[,] cellHeights;

    public WorldGrid(int dimensions, Vector3 size)
    {
        this.dimensions = dimensions;
        this.size = size;
        cellState = new int[dimensions, dimensions];
        cellCenters = new Vector3[dimensions, dimensions];
        cellHeights = new float[dimensions, dimensions];
    }
}