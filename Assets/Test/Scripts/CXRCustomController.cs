using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// 컨트롤러 입력에 추가 액션을 하도록 만드는 컴포넌트
/// </summary>
[RequireComponent(typeof(ActionBasedController))]
public class CXRCustomController : MonoBehaviour
{
    #region private 변수
    ActionBasedController targetContoller;
    InputActionReference activateReference; // 검지 트리거
    InputActionReference selectReference; // 중지 범퍼 버튼
    CControllerAnimation controllerAnimation;
    #endregion

    #region public 변수
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

        // 델리게이트 (무명 메서드)
        activateReference.action.performed += delegate (InputAction.CallbackContext context)
        {
            controllerAnimation.TriggerActivate(context.performed);
        };

        // 람다식
        activateReference.action.canceled += (InputAction.CallbackContext context) => { controllerAnimation.TriggerActivate(context.performed); };


        // InputAction.CallbackContext를 파라미터로 받는 메서드의 경우 무명메서드를 사용하지 않고 바로 추가할 수 있다.
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