using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GenerateMaze maze;
    public int playerX = 0;
    public int playerZ = 0;
    public bool MoveLeft()
    {
        if(playerX > 0) {
            if (maze.maze[playerX - 1, playerZ] == 1) { return false; }
            transform.Translate(Vector3.left);
            playerX -= 1;
            return true;
        }
        return false;
    }

    public bool MoveRight()
    {
        if (playerX < GenerateMaze.width - 1)
        {
            if (maze.maze[playerX + 1, playerZ] == 1) { return false; }
            transform.Translate(Vector3.right);
            playerX += 1;
            return true;
        }
        return false;
    }

    public bool MoveForward()
    {
        if (playerZ < GenerateMaze.height - 1)
        {
            if (maze.maze[playerX, playerZ + 1] == 1) { return false; }
            transform.Translate(Vector3.forward);
            playerZ += 1;
            return true;
        }
        return false;
    }
    
    public bool MoveBack()
    {
        if (playerZ > 0)
        {
            if (maze.maze[playerX, playerZ - 1] == 1) { return false; }
            transform.Translate(Vector3.back);
            playerZ -= 1;
            return true;
        }
        return false;
    }

    public bool isOnButton()
    {
        if (maze.maze[playerX, playerZ] == 2)
        {
            return true;
        }
        return false;
    }

    public void ResetPosition()
    {
        playerX = 0;
        playerZ = 0;
        transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
    }
}
