using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CEventTest : MonoBehaviour
{
    #region private ����
    XRBaseControllerInteractor interactor;

    int count = 0;
    #endregion

    private void Awake()
    {
        interactor = GetComponent<XRBaseControllerInteractor>();

        interactor.selectEntered.AddListener
            (
                // �Ķ���͸� ������ �ް� ���� �� ����� �� �ִ� ���
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