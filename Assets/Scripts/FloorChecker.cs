using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChecker : MonoBehaviour
{
    public delegate void OnFloorEnteredEvent();

    private OnFloorEnteredEvent onFloorEnteredEvent;


    public void AddOnFloorEnteredEvent(OnFloorEnteredEvent newFloorEnteredEvent) {
        onFloorEnteredEvent += newFloorEnteredEvent;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Floor") {
            onFloorEnteredEvent();
        }
    }
}
