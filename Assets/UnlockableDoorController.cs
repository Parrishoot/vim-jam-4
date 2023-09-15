using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UnlockableDoorController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private new BoxCollider2D collider;

    [SerializeField]
    private float fadeTime = 1f;

    public void Unlock() {

        collider.enabled = false;

        spriteRenderer.DOFade(0f, fadeTime)
                      .SetEase(Ease.InOutCubic)
                      .OnComplete(() => Destroy(gameObject));
    }
}
