using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerEnemy : MonoBehaviour,IDamagable
{
    public float hitPoint;
    public GameObject bullet;
    public GameObject ghost;
    public float attackTime;
    private bool isAttack = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        GunAttack();
    }

    public void AddDamage(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            Sound.PlaySe("Gunner");
            ScoreManeger.scoreValue += 1;
            Instantiate(ghost, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    //攻撃
    public void GunAttack()
    {
        if (isAttack == true)
        {
            if (GameManager.Instance.currentState == GameManager.GameState.Playing)
            {
                //ゲームプレイ中のみ敵弾発射
                Sound.PlaySe("GunnerShot");
                Instantiate(bullet, transform.position, Quaternion.identity);
                StartCoroutine(Intarval());
            }
        }
    }

    //インターバル
    private IEnumerator Intarval()
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
