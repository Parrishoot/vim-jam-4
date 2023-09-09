using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float waitTimeBetweenRotations;

    // Start is called before the first frame update
    void Start()
    {
        Sequence s = DOTween.Sequence();
        s.Join(transform.DOLocalRotate(Vector3.forward * 720, rotationSpeed, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.InOutElastic));
        s.AppendInterval(waitTimeBetweenRotations);
        s.Play().SetLoops(-1);
    }
}
