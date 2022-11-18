using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteractEvent;
    public UnityEvent OnReadyToInteract;

    public UnityEvent OnUnableTointeract;

    // Start is called before the first frame update
    public IInteractable Interact(){
        OnInteractEvent?.Invoke();
        return this;
    }

    public void ShowReadyToInteract(){
        OnReadyToInteract?.Invoke();
    }

    public void UnableTointeract(){
        OnUnableTointeract?.Invoke();
    }
    
}
