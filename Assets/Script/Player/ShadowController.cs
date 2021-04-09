using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    private ShadowSpin _shadowSpin;
    [SerializeField] private float spinSpeed;

    private void Awake()
    {
        _shadowSpin = new ShadowSpin(gameObject);
    }

    private void Update()
    {
        _shadowSpin.Spinning(spinSpeed);
    }
}
