using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehavior
{
    public float Speed = 50f;
    public float RunMultiplier = 2f;
    public bool Running;

	void Update ()
    {
        Running = false;

        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);

        if (right || left)
        {
            var tmpSpeed = Speed;

            if(run && RunMultiplier > 0)
            {
                tmpSpeed *= RunMultiplier;
                Running = true;
            }

            var velX = tmpSpeed * (float)inputState.direction;

            body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }

    }
}
