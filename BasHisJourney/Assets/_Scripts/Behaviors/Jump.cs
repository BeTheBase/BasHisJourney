using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehavior
{

    public float JumpSpeed = 200f;
    public float JumpDelay = .1f;
    public int JumpCount = 2;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;
	
	void Update ()
    {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if(collisionState.standing)
        {
            if (canJump && holdTime < .1f)
            {
                jumpsRemaining = JumpCount - 1;
                OnJump();
            }
        }
        else
        {
            if (canJump && holdTime < .1f && Time.time - lastJumpTime > JumpDelay)
            {
                if (jumpsRemaining > 0)
                {
                    OnJump();
                    jumpsRemaining--;
                }
            }
        }
	}

    protected virtual void OnJump()
    {
        var vel = body2d.velocity;
        lastJumpTime = Time.time;
        body2d.velocity = new Vector2(vel.x, JumpSpeed);
    }
}
