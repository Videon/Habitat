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

    [SerializeField] private float cellSize = 4f;
    [SerializeField] private float foundationHeight = 10f;

    [SerializeField] private float heightOffset = 0.5f;

    /// <summary> Instantiate the given object. </summary>
    /// <param name="go">The object (prefab) to spawn.</param>
    /// <param name="amount">How many objects are spawned.</param>
    public void PlaceBuilding(GameObject building, Vector3 position, int amount)
    {
        Vector3 placementPoint = GetHighestPoint(position, 4f); //TODO CELL SIZE SHOULD REFLECT FOUNDATION DIMENSIONS!
        GameObject current = new GameObject("Building_generic");
        current.transform.position = placementPoint;

        int dimensions = AmountToDimensions(amount);
        //Create grid


        Vector3 gridOffset = new Vector3(position.x - cellSize / 2f, position.y, position.z - cellSize / 2f);

        int count = 0;
        for (int x = 0; x < dimensions; x++)
        {
            for (int z = 0; z < dimensions; z++)
            {
                if (count >= amount) break;
                Vector3 currentPos = GetHighestPoint(gridOffset + new Vector3(
                    x * cellSize,
                    0f,
                    z * cellSize), cellSize);
                PlaceFoundation(current.transform, currentPos, foundationHeight);
                count++;
            }
        }

        //Determine highest point of foundation and lowest center point of building
    }

    private void PlaceFoundation(Transform parent, Vector3 position, float foundationHeight)
    {
        //Placement. Offset foundation so that is at placement point.
        GameObject go = Instantiate(foundation, parent);
        go.transform.position = position + new Vector3(0f, -foundationHeight / 2f + heightOffset, 0f);

        //Scaling
        go.transform.localScale = new Vector3(cellSize, foundationHeight, cellSize);
    }

    private Vector3 GridCenter(Vector3 position)
    {
        Vector3 center = new Vector3();

        return center;
    }

    private Vector3 GetHighestPoint(Vector3 position, float cellSize)
    {
        Vector3 highestPoint = new Vector3(0f, -10000f, 0f);

        int raycasts = 64;
        float raycastHeight = 100f;

        int dimensions = AmountToDimensions(raycasts);


        Ray ray;
        RaycastHit hit;

        Vector3 gridOffset = new Vector3(position.x - cellSize / 2f, position.y, position.z - cellSize / 2f);

        List<Vector3> hitPoints = new List<Vector3>();

        for (int x = 0; x < dimensions; x++)
        {
            for (int z = 0; z < dimensions; z++)
            {
                Vector3 origin = gridOffset + new Vector3(
                    cellSize / dimensions * x,
                    gridOffset.y + raycastHeight,
                    cellSize / dimensions * z);

                ray = new Ray(origin, Vector3.down);

                if (Physics.Raycast(ray, out hit, 1000f, terrainLayer))
                {
                    hitPoints.Add(hit.point);
                }
            }

            //Determine highest point
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
    private int AmountToDimensions(int amount)
    {
        float sqrt = Mathf.Sqrt(amount);
        return (int) Mathf.Ceil(sqrt);
    }
}