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

    [SerializeField]
    private Spawner shockWaveSpawner;

    [SerializeField]
    private Ease ease;

    [SerializeField]
    private new Rigidbody2D rigidbody;

    public void Init(GameObject checkpointObject) {

        rigidbody.DOMove(checkpointObject.transform.position, snapSpeed)
                 .SetEase(ease)
                 .OnComplete(() => {
                    Destroy(checkpointObject);
                    
                    playerSpawner.Spawn();
                    shockWaveSpawner.Spawn();

                    CameraController.Instance.Shaker.SetShake(strength: .6f, time: .1f, vibrato:100);

                    Destroy(gameObject);
                 });
    }
}
