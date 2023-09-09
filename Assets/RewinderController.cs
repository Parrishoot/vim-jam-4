using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class RewinderController : MonoBehaviour
{

    [SerializeField]
    private float snapSpeed = 1f;

    [SerializeField]
    private Spawner playerSpawner;

    [SerializeField]
    private new ParticleSystem particleSystem;

    public void Init(GameObject checkpointObject) {

        ParticleSystem.MainModule main = particleSystem.main;
        main.duration = snapSpeed;

        particleSystem.Play();

        transform.DOMove(checkpointObject.transform.position, snapSpeed)
                 .SetEase(Ease.InOutCubic)
                 .OnComplete(() => {
                    Destroy(checkpointObject);
                    playerSpawner.Spawn();
                 });
    }
}
