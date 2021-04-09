using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        notcollision();
    }

    //衝突消去
    void notcollision()
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int attackEnemyLayer = LayerMask.NameToLayer("AttackEnemy");
        int blockLayer = LayerMask.NameToLayer("Block");
        Physics2D.IgnoreLayerCollision(enemyLayer, enemyLayer); //敵と敵
        Physics2D.IgnoreLayerCollision(enemyLayer, attackEnemyLayer); //敵と攻撃中の敵
        Physics2D.IgnoreLayerCollision(attackEnemyLayer, attackEnemyLayer); // 攻撃中の敵と攻撃中の敵
        Physics2D.IgnoreLayerCollision(attackEnemyLayer, blockLayer); //攻撃中の敵とブロック

    }
}
