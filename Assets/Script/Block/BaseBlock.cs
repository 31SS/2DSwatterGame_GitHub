using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlock : MonoBehaviour, ISelfAttackable
{
    private GameObject playerPos;
    private PlayerHpController playerHpController;

    public void Awake()
    {
        if (playerPos = GameObject.FindWithTag("Player"))
        {
            playerHpController = playerPos.GetComponent<PlayerHpController>();
        }
    }
    public virtual void SelfAttacked()
    {
        playerHpController.SelfHPProcessing(-1);
    }
}