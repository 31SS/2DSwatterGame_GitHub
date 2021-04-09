using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover 
{
    Vector3 screenPoint;

    public void Move(PlayerController player)
    {
        screenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        player.transform.position = Camera.main.ScreenToWorldPoint(a);
    }


}
