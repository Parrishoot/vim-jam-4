using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float rotationAmount = 360f;

    [SerializeField]
    private float waitTimeBetweenRotations;

    [SerializeField]
    private bool playOnStart = true;

    private Sequence rotationSequence;

    // Start is called before the first frame update
    void Start()
    {
        if(playOnStart) {
            StartRotation();
        }
    }

    public void StartRotation() {
        rotationSequence = DOTween.Sequence();
        rotationSequence.AppendInterval(waitTimeBetweenRotations);
        rotationSequence.Join(transform.DOLocalRotate(Vector3.forward * rotationAmount, rotationSpeed, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.InOutCubic));
        rotationSequence.Play().SetLoops(-1);
    }

    public void StopRotation() {
        if(rotationSequence.IsPlaying()){
            rotationSequence.Kill();
        }
    }
}
