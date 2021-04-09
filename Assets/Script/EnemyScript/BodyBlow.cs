using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBlow : MonoBehaviour
{
    GameObject playerObj;
    Vector3 targetPos;

    public Material White;
    public Material normal;
    public float bodyBlowSpeed;

    private Rigidbody2D rb;
    private PlayerHpController playerHpController;
    private SpriteRenderer spriteRenderer;

    private bool isBodyBlow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GetPlayerPos()
    {
        if (playerObj = GameObject.FindWithTag("Player"))
        {
            targetPos = Vector3.Scale((playerObj.transform.position - this.transform.position), new Vector3(1, 1, 0)).normalized;
        }
    }

    public void AttackBodyBlow()
    {
        isBodyBlow = false;
        GetPlayerPos();
        GetComponent<EnemyMove>().enabled = false;//移動停止
        StartCoroutine(BodyBlowMove());
    }

    //攻撃の動き（やけくそコード）
    private IEnumerator BodyBlowMove()
    {
        StartCoroutine(Flashing());
        rb.velocity = targetPos * -0.5f;//少し下がって突進
        yield return new WaitForSeconds(1);
        this.gameObject.layer = LayerMask.NameToLayer("AttackEnemy");
        isBodyBlow = true;
        rb.velocity = targetPos * bodyBlowSpeed;
        Sound.PlaySe("EnemyAttack");
        yield return new WaitForSeconds(1.5f);
        stopEnemy();
    }

    private void stopEnemy()
    {
        GetComponent<EnemyMove>().enabled = true;
        rb.velocity = Vector3.zero;
        spriteRenderer.color = Color.white;
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    //点滅(やけくそ）
    private IEnumerator Flashing()
    {
        int count = 0;
        while(count++ < 5)
        {
            spriteRenderer.material = White;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.material = normal;
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.color = Color.red;
    }


    //体当たり中にダメージ
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (GetComponent<EnemyMove>().enabled ==false && isBodyBlow)
        {
            if (c.tag == "Player")
            {
                playerHpController = c.GetComponent<PlayerHpController>();
                playerHpController.HPProcessing(-1);
            }
        }
    }
}
