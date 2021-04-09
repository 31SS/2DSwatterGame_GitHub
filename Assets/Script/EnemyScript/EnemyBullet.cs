using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private GameObject playerPos;
    private PlayerHpController playerHpController;
    public float bulletSpeed;
    private Vector3 shotPos;


    // Start is called before the first frame update
    void Start()
    {
        if (playerPos = GameObject.FindWithTag("Player"))
        {
            //発射する方向を取得
            shotPos = Vector3.Scale((playerPos.transform.position - transform.position), new Vector3(1, 1, 0)).normalized;
        }
        this.GetComponent<Rigidbody2D>().velocity = shotPos * bulletSpeed;
    }


    //画面外出たら削除
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
            playerHpController = c.GetComponent<PlayerHpController>();
            playerHpController.HPProcessing(-1);
            Destroy(this.gameObject);
        }
    }

}
