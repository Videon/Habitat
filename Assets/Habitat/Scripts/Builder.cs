using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Builder : MonoBehaviour
{
    private WorldGrid worldGrid;

    [SerializeField] private World world;
    [SerializeField] private LayerMask terrainLayer;

    [SerializeField, Tooltip("Object to be used as foundation. Must be a 1x1x1 cube!")]
    private GameObject foundation;

    [SerializeField] private float sideLength = 4f;
    [SerializeField] private float foundationHeight = 10f;

    [SerializeField] private float heightOffset = 0.5f;

    #region Temporary variables

    [SerializeField] private Building[] testBuildings;

    #endregion

    private void Awake()
    {
        worldGrid = world.Worldgrid;
    }

    /// <summary> Checks if an area of equal side lengths in the grid is not obstructed. </summary>
    /// <param name="position">Center position to check.</param>
    /// <param name="dimensions">Side dimensions in amount of adjacent grid cells.</param>
    /// <returns>True if free, false if obstructed.</returns>
    public bool CheckAreaFree(Vector3 position, int dimensions)
    {
        Vector2Int cell = world.PosToCell(worldGrid, position);

        int offset = (int)(dimensions / 2f);


        for (int x = 0; x < dimensions; x++)
        {
            for (int y = 0; y < dimensions; y++)
            {
                if (world.Worldgrid.cellState[cell.x - offset, cell.y - offset] > 0) return false;
            }
        }

        return true;
    }

    /// <summary> Instantiate the given object. </summary>
    /// <param name="go">The object (prefab) to spawn.</param>
    /// <param name="amount">How many objects are spawned.</param>
    public void PlaceBuilding(GameObject building, Vector3 position, int amount)
    {
        if (!CheckAreaFree(position, 1)) return;
        Vector2Int cell = world.PosToCell(worldGrid, position);
        world.Worldgrid.cellState[cell.x, cell.y] = 1;
        Vector3 placementPoint =
            worldGrid.cellCenters[cell.x, cell.y] + Vector3.up * worldGrid.cellHeights[cell.x, cell.y];
        GameObject current = building;
        current.transform.position = placementPoint;
    }

    public void PlaceFoundations(Transform parent, Vector3 centerPos, int amount)
    {
        Vector2Int centerCell = world.PosToCell(worldGrid, centerPos);

        int sideLength = (int)Mathf.Sqrt(amount); //TODO Implement placement of otherwise cut-off buildings
        int offset = (int)(sideLength / 2f);

        for (int x = 0; x < sideLength; x++)
        {
            for (int y = 0; y < sideLength; y++)
            {
                int posX = centerCell.x - offset + x;
                int posY = centerCell.y - offset + y;

                //Check if within worldGrid bounds
                if (posX < 0 || posX >= worldGrid.cellCenters.GetLength(0)
                             || posY < 0 || posY >= worldGrid.cellCenters.GetLength(1)) continue;

                //Placement
                Vector3 placementPoint =
                    worldGrid.cellCenters[posX, posY] + Vector3.up * (worldGrid.cellHeights[posX, posY]);
                PlaceFoundation(parent, placementPoint + Vector3.up * heightOffset, foundationHeight);
                GameObject go = Instantiate(testBuildings[Random.Range(0, testBuildings.Length)].gameObject);
                go.transform.position = placementPoint;
            }
        }
    }

    private void PlaceFoundation(Transform parent, Vector3 position, float foundationHeight)
    {
        //Placement.
        Vector2Int cell = world.PosToCell(worldGrid, position);

        world.Worldgrid.cellState[cell.x, cell.y] = 1;

        GameObject go = Instantiate(foundation, parent);

        Vector3 placementPoint =
            worldGrid.cellCenters[cell.x, cell.y] + Vector3.up * worldGrid.cellHeights[cell.x, cell.y]
            - Vector3.up * foundationHeight / 2f;

        go.transform.position = placementPoint;

        //Scaling
        go.transform.localScale = new Vector3(sideLength, foundationHeight, sideLength);
    }

    private Vector3 GridCenter(Vector3 position)
    {
        Vector3 center = new Vector3();

        return center;
    }

    //TODO MAKE STATIC
    public static Vector3 GetHighestPoint(Vector3 position, float cellSize, LayerMask layers)
    {
        Vector3 highestPoint = new Vector3(0f, -10000f, 0f);

        int raycasts = 64;
        float raycastHeight = 100f;

        int dimensions = AmountToDimensions(raycasts);


        List<Vector3> hitPoints = new List<Vector3>();
        Vector3[] gridPoints = GridPoints(dimensions, cellSize / dimensions);

        for (int i = 0; i < gridPoints.Length; i++)
        {
            Ray ray = new Ray(position + gridPoints[i] + new Vector3(0f, raycastHeight, 0f), Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hit, raycastHeight * 2f, layers))
            {
                hitPoints.Add(hit.point);
            }
        }

        for (int i = 0; i < hitPoints.Count; i++)
        {
            if (hitPoints[i].y > highestPoint.y)
            {
                highestPoint = hitPoints[i];
            }
        }

        return highestPoint;
    }

    /// <summary> Calculates square dimensions of a grid to fit given amount. </summary>
    /// <returns></returns>
    private static int AmountToDimensions(int amount)
    {
        float sqrt = Mathf.Sqrt(amount);
        return (int)Mathf.Ceil(sqrt);
    }

    /// <summary> Generates a 2d grid of points around a given position in 3d space. </summary>
    /// <param name="sqLength">Amount of cells as side length of a square.</param>
    /// <param name="cellSize"></param>
    /// <returns>Relative positions to be used with a given point.</returns>
    private static Vector3[] GridPoints(int sqLength, float cellSize)
    {
        Vector3[] gridPoints = new Vector3[sqLength * sqLength];

        Vector3 gridOffset = new Vector3(-(sqLength / 2f) * cellSize, 0f, -(sqLength / 2f) * cellSize);

        for (int z = 0; z < sqLength; z++)
        {
            for (int x = 0; x < sqLength; x++)
            {
                Vector3 point = gridOffset + new Vector3(x * cellSize, 0f, z * cellSize);
                gridPoints[z * sqLength + x] = point;
            }
        }

        return gridPoints;
    }
}