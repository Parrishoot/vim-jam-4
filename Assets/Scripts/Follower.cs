using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    [SerializeField]
    private GameObject followObject;

    [SerializeField]
    private float followSpeed;

    [SerializeField]
    private Vector2 offset = new Vector2(0, 1);

    // Update is called once per frame
    void Update()
    {
        if(!IsFollowing()) {
            return;
        }

        Vector2 dist = (Vector2) followObject.transform.position + offset - (Vector2) transform.position;
        transform.Translate(dist / (1 /followSpeed) * Time.deltaTime);
    }

    public void SetObjectToFollow(GameObject objectToFollow) {
        followObject = objectToFollow;
    }

    public bool IsFollowing() {
        return followObject != null;
    }
}
