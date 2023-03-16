using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    public static int height = 50;
    public static int width = 50;
    public int[,] maze = new int[width, height];
    public GameObject cube, button;
    public int scale = 3;

    private void Start()
    {
        InstantiateMap();
        Generate();
        DrawMap();
    }

    public void InstantiateMap()
    {
        for(int x = 0; x < height; x++)
        {
            for(int z = 0; z < height; z++)
            {
                maze[x, z] = 1;
            }
        }
    }
    public void DrawMap()
    {
        for (int x = 0; x < height; x++)
        {
            for (int z = 0; z < height; z++)
            {
                if(maze[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x, 0, z);
                    Instantiate(cube, pos, Quaternion.identity);
                } else if(maze[x, z] == 2)
                {
                    Vector3 pos = new Vector3(x, 0, z);
                    Instantiate(button, pos, Quaternion.identity);
                }
            }
        }
    }

    public void Generate()
    {
        int z = 0;
        int x = 0;
        while (x < width && z < height)
        {
            maze[x, z] = 0;
            int random = Random.Range(0, 100);
            if(random < 50)
            {
                x++;
            }else
            {
                z++;
            }
        }
        if(x >= width)
        {
            maze[x - 1, z] = 2;
        } else if(z >= height)
        {
            maze[x, z - 1] = 2;
        }
    }
}
