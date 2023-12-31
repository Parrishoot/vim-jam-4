using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField]
    private float flashBackTime = 10;

    [SerializeField]
    private Spawner rewinderSpawner;

    [SerializeField]
    private RewindLineController rewindLineController;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private KeyHolder keyHolder;

    private bool flashbackInitiated = false;

    private GameObject playerGameObject;

    private Timer timer;

    // Update is called once per frame
    void Update()
    {
        timer.DecreaseTime(Time.deltaTime);
    }

    public void Init(GameObject playerGameObject) {

        this.playerGameObject = playerGameObject;
        transform.localScale = playerGameObject.transform.localScale;

        spriteRenderer.sprite = playerGameObject.GetComponentInChildren<SpriteRenderer>().sprite;

        KeyHolder playerKeyHolder = playerGameObject.GetComponentInChildren<KeyHolder>();
        keyHolder.HoldKey(playerKeyHolder.GetKey());
        playerKeyHolder.RemoveKey();

        rewindLineController.SetLineStartTransform(transform);
        rewindLineController.SetLineEndTransform(playerGameObject.transform);

        timer = new Timer(flashBackTime);
        timer.AddOnTimerFinishedEvent(FlashBack);
    }

    public void FlashBack() {

        if(flashbackInitiated) {
            return;
        }

        RewinderController rewinderController = rewinderSpawner.Spawn(playerGameObject.transform.position).GetComponent<RewinderController>();
        rewinderController.Init(gameObject);
        rewindLineController.SetLineEndTransform(rewinderController.transform);

        KeyHolder playerKeyHolder = playerGameObject.GetComponentInChildren<KeyHolder>();
        keyHolder.HoldKey(playerKeyHolder.GetKey());
        playerKeyHolder.RemoveKey();

        Destroy(playerGameObject);

        flashbackInitiated = true;
    }
}
