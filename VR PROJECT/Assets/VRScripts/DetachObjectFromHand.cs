using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class DetachObjectFromHand : MonoBehaviour
{
    private Interactable interactableComponent;

    private void Start()
    {
        interactableComponent = GetComponent<Interactable>();
    }

    public void DoDetach()
    {
 
        interactableComponent.attachedToHand.DetachObject(interactableComponent.attachedToHand.currentAttachedObject);
    }


}
