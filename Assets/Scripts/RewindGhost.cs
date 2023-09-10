using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RewindGhost : MonoBehaviour
{
    [SerializeField]
    private float startingAlpha = .8f;

    [SerializeField]
    private float fadeSpeed = .2f;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.DOFade(0f, fadeSpeed)
                      .OnComplete(() => {
                        Destroy(gameObject);
                      });
    }
}
