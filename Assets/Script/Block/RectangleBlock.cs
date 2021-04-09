using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleBlock : BaseBlock
{
    private bool damageFlag;

    private void Start()
    {
        damageFlag = false;
        StartCoroutine("SelfDamageInterval");
        StartCoroutine("ClearBlock");
        Sound.PlaySe("BlocKPut");

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (damageFlag)
        {
            other.GetComponent<ISelfAttackable>()?.SelfAttacked();
        }
        else
        {
            //置いた瞬間敵にダメージ
            if (other.tag == "Enemy")
                other.GetComponent<IDamagable>()?.AddDamage(1);
        }
    }

    public override void SelfAttacked()
    {
        base.SelfAttacked();
    }

    private IEnumerator SelfDamageInterval()
    {
        yield return new WaitForSeconds(0.1f);
        damageFlag = true;
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    //ブロック削除
    private IEnumerator ClearBlock()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
