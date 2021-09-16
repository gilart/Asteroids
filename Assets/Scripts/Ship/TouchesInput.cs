using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchesInput : InputBase
{
    private FixedJoystick fixedJoystick;
    private Button actionButton;

    private bool buttonClicked;

    protected override void Start()
    {
        base.Start();

        fixedJoystick = FindObjectOfType<FixedJoystick>();
        actionButton = GameObject.FindGameObjectWithTag("ActionButton").GetComponent<Button>();
        actionButton.onClick.AddListener(OnActionButtonClicked);
    }

    private void OnActionButtonClicked()
    {
        buttonClicked = true;
    }

    protected override void ProcessRotation()
    {
        if (fixedJoystick.Horizontal <= -0.3f)
        {
            this.Rotate(1f);
        }
        else if (fixedJoystick.Horizontal >= 0.3f)
        {
            this.Rotate(-1f);
        }
    }

    protected override void ProcessShooting()
    {
        if(buttonClicked)
        {
            Shoot();
            buttonClicked = false;
        }
    }

    protected override void ProcessThurst()
    {
        if (fixedJoystick.Vertical >= 0.3f)
        {
            this.Move();
        }
        else
        {
            this.StopMoving();
        }
    }
}
