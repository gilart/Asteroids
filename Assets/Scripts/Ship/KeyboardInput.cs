using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : InputBase
{
    protected override void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.Rotate(1f);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.Rotate(-1f);
        }
    }   

    protected override void ProcessThurst()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.Move();
        }
    }

    protected override void ProcessShooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.Shoot();
        }
    }
}
