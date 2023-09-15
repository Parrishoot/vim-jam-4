using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private KeyController heldKey;

    public void HoldKey(KeyController keyController) {
        
        heldKey = keyController;

        if(HasKey()) {
            keyController.PickUp(gameObject);
        }
    }

    public bool HasKey() {
        return heldKey != null;
    }

    public void RemoveKey() {
        if(HasKey()) {
            heldKey = null;
        }
    }

    public KeyController GetKey() {
        return heldKey;
    }
}
