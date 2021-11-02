using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private Vector3 origin;

    [SerializeField, Tooltip("Area size.")]
    private Vector3 size;

    [SerializeField, Tooltip("Square grid dimensions.")]
    private int dimensions;

    public WorldGrid Worldgrid { get; private set; }

    [SerializeField] private LayerMask heightCheckTargetLayers;
    [SerializeField] private Vector3 heightCheckOffset = new Vector3(0f, 1000f, 0f);

    private void Awake()
    {
        InitializeWorldGrid();
    }

    [Button]
    private void InitializeWorldGrid()
    {
        Worldgrid = new WorldGrid(dimensions, size);
        SetupGrid(Worldgrid);
    }

    private void SetupGrid(WorldGrid wg)
    {
        //Determine grid centers

        //NOTE: Currently cellSizeX and Y should be identical because only square area sizes are supported.
        float cellSizeX = wg.size.x / dimensions;
        float cellSizeZ = wg.size.z / dimensions;

        for (int x = 0; x < wg.dimensions; x++)
        {
            for (int z = 0; z < wg.dimensions; z++)
            {
                wg.cellCenters[x, z] = new Vector3(cellSizeX * x + cellSizeX / 2f, 0f, cellSizeZ * z + cellSizeZ / 2f);
            }
        }

        //Determine cell heights
        Ray ray;
        RaycastHit hit;

        for (int x = 0; x < wg.dimensions; x++)
        {
            for (int z = 0; z < wg.dimensions; z++)
            {
                ray = new Ray(wg.cellCenters[x, z] + heightCheckOffset, Vector3.down);
                if (Physics.Raycast(ray, out hit, 10000f, heightCheckTargetLayers))
                {
                    wg.cellState[x, z] = 0;
                    wg.cellHeights[x, z] = hit.point.y;
                }
                else
                {
                    wg.cellState[x, z] = -1;
                }
            }
        }
    }

    public Vector2Int PosToCell(WorldGrid wg, Vector3 pos)
    {
        float cellSizeX = wg.size.x / dimensions;
        float cellSizeZ = wg.size.z / dimensions;
        int x = (int) (pos.x / cellSizeX);
        int z = (int) (pos.z / cellSizeZ);
        print(x + " - " + z);
        return new Vector2Int(x, z);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (Worldgrid == null) return;
        for (int x = 0; x < Worldgrid.dimensions; x++)
        {
            for (int z = 0; z < Worldgrid.dimensions; z++)
            {
                Gizmos.DrawWireCube(Worldgrid.cellCenters[x, z] + new Vector3(0f, Worldgrid.cellHeights[x, z]),
                    Vector3.one * size.x / dimensions);
            }
        }
    }
#endif
}