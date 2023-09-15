using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    [SerializeField]
    private Floater keyFloater;

    [SerializeField]
    private Follower keyFollower;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(keyFollower.IsFollowing() || other.gameObject.tag != "Player") {
            return;
        }

        other.gameObject.GetComponentInChildren<KeyHolder>().HoldKey(this);
    }

    public void PickUp(GameObject playerGameObject) {
        keyFloater.StopFloat();
        keyFollower.SetObjectToFollow(playerGameObject);
    }
}
