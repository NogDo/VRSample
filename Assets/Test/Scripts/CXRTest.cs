using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CXRTest : MonoBehaviour
{
    public void Print(string message) => print(message);

    public void FirstSelectEnterEvent(SelectEnterEventArgs args)
    {
        print($"{args.interactableObject.transform.name} first selected by {args.interactorObject.transform.parent.name}");
    }

    public void LastSelectExitEvent(SelectExitEventArgs args)
    {
        print($"{args.interactableObject.transform.name} last exited by {args.interactorObject.transform.parent.name}");
    }

    public void SelectEnterEvent(SelectEnterEventArgs args)
    {
        print($"{args.interactableObject.transform.name} selected by {args.interactorObject.transform.parent.name}");
    }

    public void SelectExitEvent(SelectExitEventArgs args)
    {
        print($"{args.interactableObject.transform.name} exited by {args.interactorObject.transform.parent.name}");
    }

    public void ActivateEvent(BaseInteractionEventArgs args)
    {
        if (args.GetType() == typeof(ActivateEventArgs))
        {
            print("»§");
        }

        else if (args.GetType() == typeof(DeactivateEventArgs))
        {
            print("ÂûÄ¬");
        }

        else
        {
            print("");
        }
    }
}