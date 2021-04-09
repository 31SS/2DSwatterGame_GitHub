using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemy : MonoBehaviour
{
    public float attackTime;
    public GameObject fire;

    private bool isAttack;
    private FireAttack fireAttack;
    private BodyBlow bodyBlow;

    // Start is called before the first frame update
    void Start()
    {
        fireAttack = new FireAttack(fire);
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
                    fireAttack.FireBallAttack(this.transform.position);
                }
                else
                {
                    bodyBlow.AttackBodyBlow();
                }
                StartCoroutine(AttackIntarval());
            }
        }

    }

    //インターバル
    private IEnumerator AttackIntarval()
    {
        isAttack = false;
        yield return new WaitForSeconds(attackTime);
        isAttack = true;
    }

}
