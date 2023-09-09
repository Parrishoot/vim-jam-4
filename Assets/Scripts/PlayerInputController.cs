using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    private KeyCode moveLeftKey = KeyCode.A;

    [SerializeField]
    private KeyCode moveRightKey = KeyCode.D;

    [SerializeField]
    private KeyCode flashBackKey = KeyCode.E;

    [SerializeField]
    private PlayerMovementController playerMovementController;

    [SerializeField]
    private Spawner flashBackSpawner;

    private CheckPointController activeCheckpointController;

    private void Update() {

        int horizontalMovement = 0;

        if(Input.GetKey(moveLeftKey)) {
            horizontalMovement--;
        }

        if(Input.GetKey(moveRightKey)) {
            horizontalMovement++;
        }

        playerMovementController.SetHorizontalMovement(horizontalMovement);

        if(Input.GetKeyDown(jumpKey)) {
            playerMovementController.Jump();
        }

        if(Input.GetKeyDown(flashBackKey)) {
            
            if(activeCheckpointController == null) {
                activeCheckpointController = flashBackSpawner.Spawn().GetComponent<CheckPointController>();
                activeCheckpointController.Init(gameObject);
            }
            else {
                activeCheckpointController.FlashBack();
            }

        }
    }
}
