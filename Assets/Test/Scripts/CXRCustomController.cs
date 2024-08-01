using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// ��Ʈ�ѷ� �Է¿� �߰� �׼��� �ϵ��� ����� ������Ʈ
/// </summary>
[RequireComponent(typeof(ActionBasedController))]
public class CXRCustomController : MonoBehaviour
{
    #region private ����
    ActionBasedController targetContoller;
    InputActionReference activateReference; // ���� Ʈ����
    InputActionReference selectReference; // ���� ���� ��ư
    CControllerAnimation controllerAnimation;
    #endregion

    #region public ����
    public InputActionReference buttonAReference;
    public InputActionReference buttonBReference;
    public InputActionReference translateAnchorReference;
    #endregion

    void Awake()
    {
        targetContoller = GetComponent<ActionBasedController>();
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        controllerAnimation = GetComponentInChildren<CControllerAnimation>();

        activateReference = targetContoller.activateAction.reference;
        selectReference = targetContoller.selectAction.reference;

        // ��������Ʈ (���� �޼���)
        activateReference.action.performed += delegate (InputAction.CallbackContext context)
        {
            controllerAnimation.TriggerActivate(context.performed);
        };

        // ���ٽ�
        activateReference.action.canceled += (InputAction.CallbackContext context) => { controllerAnimation.TriggerActivate(context.performed); };


        // InputAction.CallbackContext�� �Ķ���ͷ� �޴� �޼����� ��� ����޼��带 ������� �ʰ� �ٷ� �߰��� �� �ִ�.
        if (controllerAnimation.isLeft)
        {
            selectReference.action.performed += controllerAnimation.BumperActivate;
            selectReference.action.canceled += controllerAnimation.BumperActivate;
        }

        if (controllerAnimation.isLeft)
        {
            buttonAReference.action.performed += controllerAnimation.ButtonAActivate;
            buttonAReference.action.canceled += controllerAnimation.ButtonAActivate;
        }

        if (controllerAnimation.isLeft)
        {
            buttonBReference.action.performed += controllerAnimation.ButtonBActivate;
            buttonBReference.action.canceled += controllerAnimation.ButtonBActivate;
        }

        if (controllerAnimation.isLeft)
        {
            translateAnchorReference.action.performed += controllerAnimation.TranslateAnchorActivate;
            translateAnchorReference.action.canceled += controllerAnimation.TranslateAnchorActivate;
        }
    }
}