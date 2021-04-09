using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{

    private Vector3 shotPos;
    private GameObject playerObj;
    public GameObject fireBall;

    public FireAttack(GameObject fire)
    {
        fireBall = fire;
    }

    public void GetPlayerPos(float angle, Vector3 thisPos)
    {
        if (playerObj = GameObject.FindWithTag("Player"))
        {
            var x = playerObj.transform.position.x * Mathf.Cos(angle) - playerObj.transform.position.y * Mathf.Sin(angle);
            var y = playerObj.transform.position.x * Mathf.Sin(angle) + playerObj.transform.position.y * Mathf.Cos(angle);
            shotPos = Vector3.Scale((new Vector3(x,y,0) - thisPos), new Vector3(1, 1, 0)).normalized;
        }
    }

    //火の攻撃
    public void FireBallAttack(Vector3 thisPos)
    {
        Sound.PlaySe("DragonFire");
        //５方向
        for (var i = -2;i < 3; i++)
        {
            GetPlayerPos(i * 0.5f, thisPos);
            GameObject cloneFireBall = Instantiate(fireBall, thisPos, Quaternion.identity);
            cloneFireBall.GetComponent<FireBall>().shotPos = shotPos;
        }
    }
}
