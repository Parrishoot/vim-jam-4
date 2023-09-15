using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class Floater : MonoBehaviour
{

    [SerializeField]
    private float floatAmount;
    
    [SerializeField]
    private float floatSpeed;

    private Sequence floatSequence;

    // Start is called before the first frame update
    void Start()
    {
        StartFloat();
    }

    public void StartFloat() {
        floatSequence = DOTween.Sequence();
        floatSequence.Join(transform.DOLocalMoveY(transform.position.y + floatAmount, floatSpeed).SetEase(Ease.InOutSine));
        floatSequence.Play().SetLoops(-1, LoopType.Yoyo);
    }

    public void StopFloat() {
        if(floatSequence.IsActive()) {
            floatSequence.Kill();
        }
    }
}
