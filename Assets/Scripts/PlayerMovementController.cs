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
    private int allowedAirJumps = 1;

    [SerializeField]
    private FloorChecker floorChecker;

    [SerializeField]
    private float freezeTime = .1f;

    private Timer freezeTimer;

    /*
        0   = None
        1   = Right
        -1  = Left
    */
    private int horizontalMovement = 0;

    private bool jumpedSinceLastFixedUpdate = false;

    private int jumpsLeft;

    private float gravityScale;

    void Start() {
        ResetJumps();
        floorChecker.AddOnFloorEnteredEvent(ResetJumps);

        gravityScale = rigidbody.gravityScale;

        if(!floorChecker.OnGround()) {
            freezeTimer = new Timer(freezeTime);
            freezeTimer.AddOnTimerFinishedEvent(() => {
                ResetGravity();
            });

            rigidbody.gravityScale = 0f;
        }
    }
 
    public void SetHorizontalMovement(int horizontalMovement) {
        this.horizontalMovement = horizontalMovement;
    }

    public void Jump() {
        if(JumpsAllowed()) {
            jumpedSinceLastFixedUpdate = true;
        }
    }

    private void FixedUpdate() {

        freezeTimer?.DecreaseTime(Time.fixedDeltaTime);
        
        rigidbody.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime * movementSpeed, rigidbody.velocity.y);
        
        if(jumpedSinceLastFixedUpdate) {

            jumpedSinceLastFixedUpdate = false;

            if(!floorChecker.OnGround()) {
                jumpsLeft--;
            }

            // Reset Y velocity
            rigidbody.velocity = rigidbody.velocity * Vector2.right;
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            
        }

        CheckResetGravity();
    }

    public bool JumpsAllowed() {
        
        if(floorChecker.OnGround()) {
            return true;
        }

        if(jumpsLeft > 0) {
            return true;
        }

        return false;
    }

    public void ResetJumps() {
        jumpsLeft = allowedAirJumps;
    }

    public void Freeze() {
        rigidbody.velocity = Vector2.zero;
        enabled = false;
    }

    private void ResetGravity() {
        rigidbody.gravityScale = gravityScale;
    }

    private void CheckResetGravity() {
        if(rigidbody.gravityScale.Equals(0f) &&
            (Mathf.Abs(rigidbody.velocity.x) > .001f) ||
            (Mathf.Abs(rigidbody.velocity.y) > .001f)) {
            ResetGravity();
        }
    }
}
