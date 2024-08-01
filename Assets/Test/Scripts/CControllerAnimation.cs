using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CControllerAnimation : MonoBehaviour
{
    #region public º¯¼ö
    public Transform trigger;
    public Transform bumper;
    public Transform buttonA;
    public Transform buttonB;
    public Transform stick;
    public UnityEngine.XR.Content.Interaction.LaunchProjectile launch;

    public bool isLeft;
    #endregion

    public void TriggerActivate(bool isPush)
    {
        if (isLeft)
        {
            trigger.transform.Rotate(isPush ? -10.0f : 10.0f, 0.0f, 0.0f);
        }

        else
        {
            trigger.transform.Rotate(isPush ? 10.0f : -10.0f, 0.0f, 0.0f);
        }

        if (launch is not null && isPush)
        {
            launch.Fire();
        }
    }

    public void BumperActivate(InputAction.CallbackContext context)
    {
        bumper.transform.Translate(context.performed ? 0.002f : -0.002f, 0.0f, 0.0f);
    }

    public void ButtonAActivate(InputAction.CallbackContext context)
    {
        buttonA.transform.Translate(0.0f, context.performed ? -0.001f : 0.001f, 0.0f);
    }

    public void ButtonBActivate(InputAction.CallbackContext context)
    {
        buttonB.transform.Translate(0.0f, context.performed ? -0.001f : 0.001f, 0.0f);
    }

    public void TranslateAnchorActivate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 rotation = context.action.ReadValue<Vector2>();
            stick.Rotate(-rotation.y * 20.0f, 0.0f, rotation.x * 20.0f);
        }

        else
        {
            stick.localRotation = Quaternion.identity;
        }
    }
}
