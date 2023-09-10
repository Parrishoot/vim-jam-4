using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindCooldownController : MonoBehaviour
{
    [SerializeField]
    private float rewindCooldownTime = 2f;

    [SerializeField]
    [Range(0, 1)]
    private float startingCooldownPercentage = 1f;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Material material;

    private Timer rewindTimer;

    private const String FADE_AMOUNT_PARAM = "_FadeAmount";

    // Start is called before the first frame update
    void Start()
    {
        material = spriteRenderer.material;
        rewindTimer = new Timer(rewindCooldownTime);
        rewindTimer.DecreaseTime(rewindCooldownTime * startingCooldownPercentage);

        rewindTimer.AddOnTimerFinishedEvent(() => {
            CameraController.Instance.Shaker.SetShake(strength: .1f, time: .1f, vibrato:200);
        });
    }

    private void SetMaterialProperties() {
        material.SetFloat(FADE_AMOUNT_PARAM, rewindTimer.GetPercentageFinished());
    }

    // Update is called once per frame
    void Update()
    {
        rewindTimer.DecreaseTime(Time.deltaTime);

        SetMaterialProperties();
    }

    public bool CanRewind() {
        return rewindTimer.IsFinished();
    }
}
