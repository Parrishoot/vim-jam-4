using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onTriggerEnterEvent;

    [SerializeField]
    private UnityEvent onTriggerExitEvent;

    [SerializeField]
    private List<String> acceptableTags;

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        
        if(!IsValidObjectToTrigger(other.gameObject)) {
            return;
        }

        onTriggerEnterEvent?.Invoke();
    }

    protected void OnTriggerExit2D(Collider2D other) {
        
        if(!IsValidObjectToTrigger(other.gameObject)) {
            return;
        }

        onTriggerExitEvent?.Invoke();
    }

    protected bool IsValidObjectToTrigger(GameObject otherGameObject) {
        return acceptableTags.Count != 0 && acceptableTags.Contains(otherGameObject.tag);
    } 
}
