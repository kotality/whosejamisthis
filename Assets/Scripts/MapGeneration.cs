using System.Collections;
using System;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    public int width = 10;
    public int height = 10;
    public string seed = "tester";
    public bool randomSeed;

    //[Range(0, 100)]
    public int randomFillPercent = 40;

    int[,] map;
    
    void Start()
    {
        MakeMap();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MakeMap();
        }
    }

    void MakeMap()
    {
        map = new int[width, height];
        RandomFillMap();

        int borderSize = 1;
        int[,] borderedMap = new int[width + borderSize * 2, height + borderSize * 2];

        for (int x = 0; x < borderedMap.GetLength(0); x++)
        {
            for (int y = 0; y < borderedMap.GetLength(1); y++)
            {
                if (x >= borderSize && x < width + borderSize && y >= borderSize && y < height + borderSize)
                {
                    borderedMap[x, y] = map[x - borderSize, y - borderSize];
                }
                else
                {
                    borderedMap[x, y] = 1;
                }
            }
        }

        MeshGenerator meshGen = GetComponent<MeshGenerator>();
        meshGen.GenerateMesh(borderedMap, 1);
    }

    void RandomFillMap()
    {
        if (randomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random rand = new System.Random(seed.GetHashCode());

        // Go throgh tiles of map
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == (width - 1) || y == 0 || y == (height - 1))
                {
                    map[x, y] = 1; // wall
                }
                else
                {
                    // If < randomFillPercent add wall. If greater leave as blank tile
                    map[x, y] = (rand.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
        }
    }
}
