using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Interactable _interactableinRange;
    private void Update() {
        if(_interactableinRange != null && Input.GetButton("Interact")){
            _interactableinRange.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.GetComponent<Interactable>()){
            
            _interactableinRange = other.gameObject.GetComponent<Interactable>();
            _interactableinRange.ShowReadyToInteract();
            Debug.Log(_interactableinRange);
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
         Debug.Log("Exit");
        if(_interactableinRange != null && other.gameObject.GetComponent<Interactable>()){
            _interactableinRange.UnableTointeract();
            _interactableinRange = null;
            Debug.Log(_interactableinRange);
        } 
    }
}
