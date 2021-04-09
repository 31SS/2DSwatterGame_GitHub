using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float bulletSpeed;
    public Vector3 shotPos;
    private PlayerHpController playerHpController;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = shotPos * bulletSpeed;
    }

    //画面外出たら削除
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            playerHpController = c.GetComponent<PlayerHpController>();
            playerHpController.HPProcessing(-1);
            Destroy(this.gameObject);
        }
    }
}
