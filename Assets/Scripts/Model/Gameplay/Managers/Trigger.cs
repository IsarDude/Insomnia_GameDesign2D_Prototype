using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour {
    private bool _isActive;
    private void Start () {
        _isActive = true;
    }
    public UnityEvent OntriggerActivated;
    private void OnTriggerEnter2D (Collider2D other) {
        if (_isActive) {
            OntriggerActivated?.Invoke ();
            _isActive = false;
        }
    }

    public void SetActive(){
        _isActive = true;
    }
}