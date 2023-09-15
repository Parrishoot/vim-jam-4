using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{

    [SerializeField]
    private PortalAnimationController portalAnimationController;

    private bool won = false;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player" && !won) {
            won = true;
            LevelManager.Instance.WinLevel();
            other.gameObject.GetComponent<PlayerMovementController>().Freeze();
            portalAnimationController.TransitionOut();
        }
    }
}
