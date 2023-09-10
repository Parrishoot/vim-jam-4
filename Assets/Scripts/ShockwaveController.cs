using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveController : MonoBehaviour
{
    [SerializeField]
    private float shockwaveSpeed;

    [SerializeField]
    private float shockwaveStrength = -.1f;

    [SerializeField]
    private float shockwaveDistance = .3f;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Timer timer;

    private Material material;

    private const String SHADER_STRENGTH_PARAM = "_Strength";
    private const String SHADER_DISTANCE_PARAM = "_WaveDistanceFromCenter";

    // Start is called before the first frame update
    void Start()
    {
        material = spriteRenderer.material;
        timer = new Timer(shockwaveSpeed);

        SetParamsBasedOnTime();

        timer.AddOnTimerFinishedEvent(() => {
            Destroy(gameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {
        timer.DecreaseTime(Time.deltaTime);

        SetParamsBasedOnTime();
    }

    private void SetParamsBasedOnTime() {
        float completionPercentage = timer.GetPercentageFinished();

        material.SetFloat(SHADER_STRENGTH_PARAM, Mathf.Lerp(shockwaveStrength, 0f, completionPercentage));
        material.SetFloat(SHADER_DISTANCE_PARAM, Mathf.Lerp(0f, shockwaveDistance, completionPercentage));
    }
}
