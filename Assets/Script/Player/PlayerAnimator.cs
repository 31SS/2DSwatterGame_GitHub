using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly Animator _animator;
    private readonly PlayerController _playerController;
    [SerializeField] private Renderer spriteRenderer;
    private bool damageAniFlag;

    public PlayerAnimator(Animator animator, PlayerController playerController)
    {
        _animator = animator;
        _playerController = playerController;
        damageAniFlag = false;
    }

    public void HoldedExchange()
    {
        
    }

    public void DamagedExchange()
    {
        StartCoroutine("DamageTimer");
    }

    public IEnumerator DamageTimer()
    {
        if (damageAniFlag)
        {
            yield break;
        }
        damageAniFlag = true;
        _animator.SetTrigger("is_Attacked");
        for (int i = 0; i < 10; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
        _playerController.IsDamaged = false;
    }
}
