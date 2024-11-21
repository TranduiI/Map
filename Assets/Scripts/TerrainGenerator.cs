using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Terrain terrain;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    void Start()
    {
        RemoveOldTerrain();
        GenerateTerrain();
    }

    void RemoveOldTerrain()
    {
        Terrain[] terrains = FindObjectsOfType<Terrain>();
        foreach (Terrain t in terrains)
        {
            Destroy(t.gameObject);
        }
    }

    void GenerateTerrain()
    {
        terrain = gameObject.AddComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, scale, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = Mathf.PerlinNoise(x * 0.1f, y * 0.1f);
            }
        }
        return heights;
    }
}


    


