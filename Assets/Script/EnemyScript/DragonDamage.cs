using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDamage : MonoBehaviour , IDamagable
{
    public GameObject ghost;
    public float hitPoint;

    public void AddDamage(float damage)
    {
        hitPoint -= damage;
        StartCoroutine(AddDamegeFlashing());
        if (hitPoint <= 0)
        {
            Sound.PlaySe("Dragon");
            ScoreManeger.scoreValue += 10;
            Instantiate(ghost, transform.position, Quaternion.identity);
            AllEnemyClean();
            GameManager.Instance.dispatch(GameManager.GameState.Clear); // クリア
            Destroy(this.gameObject);
        }
    }

    //点滅
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

    //残っている敵全て削除
    private void AllEnemyClean()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy != this.gameObject)
            {
                enemy.GetComponent<IDamagable>().AddDamage(100);
            }
        }
    }
}
