using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.VFX;

public class MapPainter : MonoBehaviour
{
    public WorldGrid worldGrid;
    [SerializeField] private Material terrainMaterial;

    [SerializeField] private VisualEffect vfx;

    public ComputeShader terrainTypePainter;
    public ComputeShader heightMapPainter;

    public RenderTexture terrainTypeRT;
    public RenderTexture terrainHeightRT;

    // Start is called before the first frame update
    void Start()
    {
        RenderTextureSetup();

        terrainMaterial.SetTexture("LookupTexture", terrainTypeRT);
        vfx.SetTexture("TerrainType", terrainTypeRT);

        MakeHeightMap();
        vfx.SetTexture("TerrainHeight", terrainHeightRT);
    }

    private void RenderTextureSetup()
    {
        int dimensions = Mathf.ClosestPowerOfTwo(worldGrid.dimensions);

        //Terrain type
        terrainTypeRT = new RenderTexture(dimensions, dimensions, 24);
        terrainTypeRT.enableRandomWrite = true;
        terrainTypeRT.Create();

        //Terrain height
        terrainHeightRT = new RenderTexture(dimensions, dimensions, 24);
        terrainHeightRT.enableRandomWrite = true;
        terrainHeightRT.Create();
    }


    public void PaintPixels(Vector2 startPos, Vector2 endPos)
    {
        terrainTypePainter.SetInt("_Dimensions", worldGrid.dimensions);

        ComputeBuffer positionBuffer =
            new ComputeBuffer(worldGrid.dimensions * worldGrid.dimensions, sizeof(float) * 4);

        Vector4[] positions = new Vector4[1];
        positions[0] = new Vector4(startPos.x, startPos.y, endPos.x, endPos.y);

        positionBuffer.SetData(positions);
        terrainTypePainter.SetBuffer(0, "_Positions", positionBuffer);

        terrainTypePainter.Dispatch(0, terrainTypeRT.width, terrainTypeRT.height, 1);
        terrainTypePainter.SetTexture(0, "_Result", terrainTypeRT);

        positionBuffer.Release();
    }

    public void MakeHeightMap()
    {
        int dimensions = worldGrid.dimensions;
        heightMapPainter.SetInt("_Dimensions", dimensions);

        ComputeBuffer heightDataBuffer = new ComputeBuffer(dimensions * dimensions, sizeof(float));

        float[] heights = new float[dimensions * dimensions];

        for (int i = 0; i < heights.Length; i++)
        {
            heights[i] = worldGrid.cellHeights[i % dimensions, i / dimensions];
        }

        heightDataBuffer.SetData(heights);
        heightMapPainter.SetBuffer(0, "_HeightMap", heightDataBuffer);
        heightMapPainter.Dispatch(0, terrainHeightRT.width, terrainHeightRT.height, 1);

        heightMapPainter.SetTexture(0, "_Result", terrainHeightRT);

        heightDataBuffer.Release();

        vfx.Reinit();
    }

#if UNITY_EDITOR
    [SerializeField] private Vector4 testPos;

    [Button]
    private void TestPainter()
    {
        if (terrainTypeRT == null) RenderTextureSetup();

        Vector4[] positions = new Vector4[1];
        positions[0] = testPos;

        PaintPixels(new Vector2(positions[0].x, positions[0].y), new Vector2(positions[0].z, positions[0].w));
    }

#endif
}