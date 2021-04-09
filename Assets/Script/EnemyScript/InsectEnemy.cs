using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectEnemy : MonoBehaviour,IDamagable
{
    public float hitPoint;
    public GameObject ghost;

    public void AddDamage(float damage)
    {
        hitPoint -= damage;

        if (hitPoint <= 0)
        {
            Sound.PlaySe("Bug");
            ScoreManeger.scoreValue += 1;
            Instantiate(ghost, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
