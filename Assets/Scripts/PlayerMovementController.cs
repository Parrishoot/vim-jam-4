using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private new Rigidbody2D rigidbody;

    [SerializeField]
    private int allowedJumpsBetweenFloorHits = 2;

    [SerializeField]
    private FloorChecker floorChecker;

    /*
        0   = None
        1   = Right
        -1  = Left
    */
    private int horizontalMovement = 0;

    private bool jumpedSinceLastFixedUpdate = false;

    private int jumpsLeft;

    void Start() {
        ResetJumps();
        floorChecker.AddOnFloorEnteredEvent(ResetJumps);
    }

    public void SetHorizontalMovement(int horizontalMovement) {
        this.horizontalMovement = horizontalMovement;
    }

    public void Jump() {
        if(jumpsLeft > 0) {
            jumpedSinceLastFixedUpdate = true;
        }
    }

    private void FixedUpdate() {
        
        rigidbody.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime * movementSpeed, rigidbody.velocity.y);
        
        if(jumpedSinceLastFixedUpdate) {

            jumpedSinceLastFixedUpdate = false;
            jumpsLeft--;

            // Reset Y velocity
            rigidbody.velocity = rigidbody.velocity * Vector2.right;
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            
        }
    }

    public void ResetJumps() {
        jumpsLeft = allowedJumpsBetweenFloorHits;
    }
}
