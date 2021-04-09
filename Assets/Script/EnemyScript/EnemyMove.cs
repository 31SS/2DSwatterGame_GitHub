using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float moveSpeed;
    private Vector2 cameraMin;
    private Vector2 cameraMax;
    private Vector3 movePos;
    private bool inMovePos;

    // Start is called before the first frame update
    void Start()
    {
        inMovePos = true;
        movePos.z = 0;

        //画面の範囲取得
        cameraMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        cameraMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMovement();
    }
    //敵の動き
    private void EnemyMovement()
    {
        if (inMovePos)
        {
            movePos.x = Random.Range(cameraMin.x, cameraMax.x + 0.5f);
            movePos.y = Random.Range(cameraMin.y, cameraMax.y + 0.5f);
            inMovePos = false;
        }
        //WallCheck();
        transform.position = Vector2.MoveTowards(transform.position, movePos, 1 * moveSpeed  / 50);
        if (transform.position == movePos )
            inMovePos = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        inMovePos = true;
    }
}
