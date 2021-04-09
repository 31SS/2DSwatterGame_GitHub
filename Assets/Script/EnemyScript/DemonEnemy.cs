using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonEnemy : MonoBehaviour,IDamagable
{

    public float hitPoint;
    public GameObject ghost;
    public float attackTime; //攻撃インターバル

    private bool isAttack;
    private BodyBlow bodyBlow;

    // Start is called before the first frame update
    void Start()
    {
        bodyBlow = GetComponent<BodyBlow>();
        StartCoroutine(AttackIntarval());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.currentState == GameManager.GameState.Playing)
        {
            //ゲームプレイ中のみ敵弾発射
            if (isAttack && GetComponent<EnemyMove>().enabled == true)
            {
                if (Random.Range(0, 2) == 0)
                {
                    bodyBlow.AttackBodyBlow();
                }
                StartCoroutine(AttackIntarval());
            }
        }
    }

    public void AddDamage(float damage)
    {
        hitPoint -= damage;
        StartCoroutine(AddDamegeFlashing());
        if (hitPoint <= 0)
        {
            Sound.PlaySe("Devil");
            ScoreManeger.scoreValue += 1;
            Instantiate(ghost, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    //ダメージ食らうと点滅
    private IEnumerator AddDamegeFlashing()
    {
        int count = 0;
        this.GetComponent<BoxCollider2D>().isTrigger = true;
        while (count++ < 10)
        {
            this.GetComponent<SpriteRenderer>().enabled =
                !this.GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
        }
        this.GetComponent<BoxCollider2D>().isTrigger = false;
    }
    //インターバル
    private IEnumerator AttackIntarval()
    {
        isAttack = false;
        yield return new WaitForSeconds(attackTime);
        isAttack = true;
    }

    //画面内入ったら攻撃
    private void OnBecameVisible()
    {
        isAttack = true;
    }

}
