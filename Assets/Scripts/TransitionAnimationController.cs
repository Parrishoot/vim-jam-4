using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransitionAnimationController : MonoBehaviour
{
    [SerializeField]
    RectTransform transitionMaskTransform;

    [SerializeField]
    private float transitionTime = .25f;

    private delegate void OnTransitionOutFinished();

    private const float MAX_SIZE = 2000;

    public void Start() {
        TransitionIn();
    }

    public void TransitionIn() {
        transitionMaskTransform.DOSizeDelta(new Vector2(MAX_SIZE, MAX_SIZE), transitionTime).SetEase(Ease.InOutCubic);
    }

    public void TransitionOut(TweenCallback tweenCallback) {
        transitionMaskTransform.DOSizeDelta(new Vector2(0, 0), transitionTime).SetEase(Ease.InOutCubic).OnComplete(tweenCallback);
    }
}
