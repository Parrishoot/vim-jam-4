using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableDoorTriggerController : TriggerController
{
    protected override void OnTriggerEnter2D(Collider2D other) {

        if(IsValidObjectToTrigger(other.gameObject)) {
            Destroy(other.gameObject);
        }

        base.OnTriggerEnter2D(other);
    }
}
