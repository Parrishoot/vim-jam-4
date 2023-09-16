using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private new  Rigidbody2D rigidbody;

    [SerializeField]
    private PlayerMovementController playerMovementController;

    private float velocityThreshold = .01f;

    // Update is called once per frame
    void Update()
    {

        if(Mathf.Abs(rigidbody.velocity.y) > velocityThreshold) {

            if(playerMovementController.JumpsAllowed()) {
                animator.Play("Jump");
            }
            else {
                animator.Play("DoubleJump");
            }
            
        }
        else if(Mathf.Abs(rigidbody.velocity.x) > velocityThreshold) {
            animator.Play("Run");
        }
        else {
            animator.Play("Idle");
        }

        if(Mathf.Abs(rigidbody.velocity.x) >= velocityThreshold) {
            transform.localScale = new Vector3(Mathf.Sign(rigidbody.velocity.x), 1, 1);
        }
    }
}
