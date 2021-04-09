using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public void HPProcessing(int DamageValue)//敵によるダメージ用
    {
        if (playerController.IsDamaged)
        {
            return;
        }
        if ((playerController.HpValue += DamageValue) < 0)
        {
            playerController.HpValue = 0;
        }
        if(playerController.HpValue > 0 && DamageValue < 0)
        {
            playerController.IsDamaged = true;
        }
    }

    public void SelfHPProcessing(int DamageValue)//ブロックによる自傷ダメージ用
    {
        if ((playerController.HpValue += DamageValue) < 0)
        {
            playerController.HpValue = 0;
        }
        if (playerController.HpValue > 0 && DamageValue < 0)
        {
            playerController.IsDamaged = true;
        }
    }
}