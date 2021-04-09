using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpin
{
    GameObject playerGameObject;

    public ShadowSpin(GameObject gameObject)
    {
        playerGameObject = gameObject;
    }

    public void Spinning(float speed)
    {
        playerGameObject.transform.Rotate(0, 0, speed);
    }
}
