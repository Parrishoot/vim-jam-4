using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PortalAnimationController : MonoBehaviour
{
    [SerializeField]
    private float maxSize = 8f;

    [SerializeField]
    private float animationTime = 1f;

    [SerializeField]
    private float rotationAmount = 45f;

    [SerializeField]
    private ParticleSystem particleSystem;

    public void TransitionOut() {

        if(particleSystem.isPlaying) {
            particleSystem.Stop();
        }

        Sequence sequence = DOTween.Sequence();

        sequence.Join(transform.DOScale(maxSize, animationTime / 2).SetEase(Ease.InCubic).OnComplete(() => {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }));
        sequence.Join(transform.DORotate(Vector3.forward * rotationAmount / 2, animationTime / 2, RotateMode.FastBeyond360).SetEase(Ease.InCubic));
        sequence.Append(transform.DOScale(0, animationTime / 2).SetEase(Ease.OutCubic));
        sequence.Join(transform.DORotate(Vector3.forward * rotationAmount, animationTime / 2, RotateMode.FastBeyond360).SetEase(Ease.OutCubic));

        sequence.Play();
    }
}
