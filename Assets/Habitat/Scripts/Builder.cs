using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private float gridSize = 10f;

    [SerializeField, Tooltip("Object to be used as foundation. Must be a 1x1x1 cube!")]
    private GameObject foundation;

    [SerializeField] private float sideLength = 4f;
    [SerializeField] private float foundationHeight = 10f;

    [SerializeField] private float heightOffset = 0.5f;

    /// <summary> Instantiate the given object. </summary>
    /// <param name="go">The object (prefab) to spawn.</param>
    /// <param name="amount">How many objects are spawned.</param>
    public void PlaceBuilding(GameObject building, Vector3 position, int amount)
    {
        Vector3 placementPoint =
            new Vector3(position.x, GetHighestPoint(position, sideLength, terrainLayer).y, position.z);
        GameObject current = building;
        current.transform.position = placementPoint;

        //int dimensions = AmountToDimensions(amount);
        //Create grid

        //PlaceFoundations(current.transform, placementPoint, amount);

        //Determine highest point of foundation and lowest center point of building
    }

    public void PlaceFoundations(Transform parent, Vector3 centerPos, int amount)
    {
        int dimensions = AmountToDimensions(amount);
        Vector3[] gridPoints = GridPoints(dimensions, sideLength);

        for (int i = 0; i < amount; i++)
        {
            Vector3 currentPos = new Vector3(centerPos.x, 0f, centerPos.z) + gridPoints[i] + new Vector3(
                0f,
                GetHighestPoint(centerPos + gridPoints[i], sideLength / 8f, terrainLayer).y,
                0f);
            PlaceFoundation(parent, currentPos, foundationHeight);
        }
    }

    private void PlaceFoundation(Transform parent, Vector3 position, float foundationHeight)
    {
        //Placement. Offset foundation so that is at placement point.
        GameObject go = Instantiate(foundation, parent);
        go.transform.position = position + new Vector3(0f, -foundationHeight / 2f + heightOffset, 0f);

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
        return (int) Mathf.Ceil(sqrt);
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