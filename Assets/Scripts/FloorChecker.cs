using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChecker : MonoBehaviour
{
    public delegate void OnFloorEnteredEvent();

    private OnFloorEnteredEvent onFloorEnteredEvent;

    private bool onGround = false;

    public void AddOnFloorEnteredEvent(OnFloorEnteredEvent newFloorEnteredEvent) {
        onFloorEnteredEvent += newFloorEnteredEvent;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Floor") {
            onFloorEnteredEvent();
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Floor") {
            onGround = false;
        }
    }

    public bool OnGround() {
        return onGround;
    }

}
