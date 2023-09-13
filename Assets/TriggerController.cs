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

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(acceptableTags.Count == 0 || !acceptableTags.Contains(other.gameObject.tag)) {
            return;
        }

        onTriggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if(acceptableTags.Count == 0 || !acceptableTags.Contains(other.gameObject.tag)) {
            return;
        }

        onTriggerExitEvent?.Invoke();
    }
}
