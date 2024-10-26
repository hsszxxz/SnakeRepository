using sneak;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneMove
{
    public static void MoveSneak(Vector3 Position, GameObject camera)
    {
        GameObject snake = SneakManager.Instance.sneakBodies;
        snake.transform.position = Position;
        int sneakBodyLength = SneakManager.Instance.length;
        SneakManager.Instance.InitHeads();
        for (int i = 0; i < sneakBodyLength; i++)
        {
            SneakManager.Instance.AddSneakBodyToPrevious(SneakManager.Instance.head1.GetComponent<SneakBody>());
        }
        camera.transform.position = Position;
    }
}
