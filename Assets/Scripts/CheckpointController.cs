using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField]
    private float flashBackTime = 3;

    [SerializeField]
    private Spawner rewinderSpawner;

    [SerializeField]
    private RewindLineController rewindLineController;

    private GameObject playerGameObject;

    private Timer timer;

    // Update is called once per frame
    void Update()
    {
        timer.DecreaseTime(Time.deltaTime);
    }

    public void Init(GameObject playerGameObject) {
        this.playerGameObject = playerGameObject;

        rewindLineController.SetLineStartTransform(transform);
        rewindLineController.SetLineEndTransform(playerGameObject.transform);

        timer = new Timer(flashBackTime);
        timer.AddOnTimerFinishedEvent(FlashBack);
    }

    public void FlashBack() {

        Destroy(playerGameObject);

        RewinderController rewinderController = rewinderSpawner.Spawn(playerGameObject.transform.position).GetComponent<RewinderController>();
        rewinderController.Init(gameObject);
        rewindLineController.SetLineEndTransform(rewinderController.transform);
    }
}