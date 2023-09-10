using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawnController : MonoBehaviour
{
    [SerializeField] 
    private Spawner ghostSpawner;

    [SerializeField]
    private float spawnRate = .05f;

    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGhost();
    }

    // Update is called once per frame
    void Update()
    {
        timer.DecreaseTime(Time.deltaTime);
    }

    private void ResetGhostSpawnTimer() {
        timer = new Timer(spawnRate);
        timer.AddOnTimerFinishedEvent(SpawnGhost);
    }

    private void SpawnGhost() {
        ghostSpawner.Spawn();
        ResetGhostSpawnTimer();
    } 
}
