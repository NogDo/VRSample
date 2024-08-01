using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CEventTest : MonoBehaviour
{
    #region private 변수
    XRBaseControllerInteractor interactor;

    int count = 0;
    #endregion

    private void Awake()
    {
        interactor = GetComponent<XRBaseControllerInteractor>();

        interactor.selectEntered.AddListener
            (
                // 파라미터를 여러개 받고 싶을 때 사용할 수 있는 방식
                (args) => 
                {
                    XREventCall(args, count++);
                }
            );
    }

    public void XREventCall(BaseInteractionEventArgs args, int count)
    {
        print($"{args.interactorObject.transform.name} called {count} times");
    }
}