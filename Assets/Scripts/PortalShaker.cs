using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PortalShaker : MonoBehaviour
{
    [SerializeField]
    private float shakeAmount = 10f;

    [SerializeField]
    private int shakeVibrato = 100;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOShakePosition(1000f, shakeAmount, shakeVibrato, fadeOut: false)
                 .SetLoops(-1);
    }
}
